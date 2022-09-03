using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Management")]
    public ParticleSystem footDust;
    public float jumpDelay;
    private Rigidbody2D rb;
    public float speed = 1;
    public float jumpForce = 1;
    public SpriteRenderer player;
    public bool moveLeft, moveRight;
    public float maxSpeed;
    public int health = 1;

    [Header("Prevents Unlimited Jumps")]
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    [Header("Jump Physics")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;

    [Header("Controls")]
    public bool controlsOn = true;
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public Button fireButton;
    public EventSystem eventSystem;

    [Header("Cannon Management")]
    public GameObject paintCannon;
    public Button shootButton;
    public GameObject ammoBar;

    [Header("Animations")]
    public Animator playerAnim;

    [Header("Coyote Jump")]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;

        eventSystem.SetSelectedGameObject(null);

        if (controlsOn == false)
        {
            leftButton.interactable = false;
            rightButton.interactable = false;
            jumpButton.interactable = false;
            fireButton.interactable = false;
        }
    }

    private void FixedUpdate()
    {
        //Constantly moves player.
        if (moveLeft)
        {
            if (rb.velocity.x <= maxSpeed && rb.velocity.x >= -maxSpeed)
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        }

        if (moveRight)
        {
            if (rb.velocity.x <= maxSpeed && rb.velocity.x >= -maxSpeed)
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = 1f;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(ammoBar.GetComponent<Slider>().value <= 0)
		{
            playerAnim.SetTrigger("playerDead");

            StartCoroutine(Restart());
        }
    }

    //Enables controls
    public void EnableControls()
    {
        controlsOn = true;

        leftButton.interactable = true;
        rightButton.interactable = true;
        jumpButton.interactable = true;

        eventSystem.SetSelectedGameObject(null);
    }

    //Disables controls
    public void DisableControls()
    {
        controlsOn = false;

        leftButton.interactable = false;
        rightButton.interactable = false;
        jumpButton.interactable = false;

        eventSystem.SetSelectedGameObject(null);
    }

    //Controls left movement.
    public void MovePlayerLeft()
    {
        if (controlsOn)
        {
            moveLeft = true;
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }
    }

    //Controls right movement.
    public void MovePlayerRight()
    {
        if (controlsOn)
        {
            moveRight = true;
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

    //Stops player movement.
    public void StopMovement()
    {
        if (controlsOn)
        {
            moveLeft = false;
            moveRight = false;
            //rb.velocity = Vector2.zero;

            eventSystem.SetSelectedGameObject(null);
        }
    }

    //Controls jumping.
    public void Jump()
    {
        if (controlsOn)
        {
            if (isGrounded)
            {
                StartCoroutine(DelayJump());
            }
            else if(coyoteTimeCounter > 0f)
            {
                StartCoroutine(DelayJump());
            }
        }
        
    }

    //Check before jumping.
    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
            footDust.enableEmission = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
            footDust.enableEmission = false;
        }
    }

    public IEnumerator Restart()
    {
        controlsOn = false;

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DelayJump()
	{
        playerAnim.SetBool("playerJumping", true);
        yield return new WaitForSeconds(jumpDelay);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        coyoteTimeCounter = 0f;
        playerAnim.SetBool("playerJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerupActivateCannon"))
        {
            paintCannon.SetActive(true);
            ammoBar.SetActive(true);
            shootButton.interactable = true;
            
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            StopMovement();

            health--;

            if (health <= 0)
            {
                playerAnim.SetTrigger("playerDead");
                
                StartCoroutine(Restart());
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Boss"))
        {
            health--;

            StopMovement();

            if (health <= 0)
            {
                playerAnim.SetTrigger("playerDead");

                StartCoroutine(Restart());
            }

            //What to do...
            if (collision.gameObject.transform.position.x < transform.position.x)
            {
                rb.AddRelativeForce(Vector2.right * 5, ForceMode2D.Impulse);
            }
            else if (collision.gameObject.transform.position.x > transform.position.x)
            {
                rb.AddRelativeForce(Vector2.left * 5, ForceMode2D.Impulse);
            }
        }

        if (collision.gameObject.CompareTag("BossBottom"))
        {
            health = 0;
            playerAnim.SetTrigger("playerDead");

            StartCoroutine(Restart());
        }
    }
}
