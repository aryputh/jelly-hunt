using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic")]
    public ParticleSystem footDust;
    public float jumpDelay = 0.01f;
    public float speed = 2.8f;
    public float jumpForce = 7.2f;
    [HideInInspector] public bool moveLeft, moveRight;
    public float maxSpeed = 5f;
    public int health = 1;
    Rigidbody2D rb;
    SpriteRenderer playerRenderer;
    Animator playerAnim;
    ParticleSystem.EmissionModule emissionModule;

    [Header("Jumping Detection")]
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    bool isGrounded = false;

    [Header("Jumping Physics")]
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 0.7f;
    public float rememberGroundedFor = 0.2f;
    float lastTimeGrounded;

    [Header("Jumping Extras")]
    public float coyoteTime = 0.1f;
    float coyoteTimeCounter;

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

    [Header("Endless Mode")]
    public UnityEvent onEndlessDie;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        emissionModule = footDust.emission;

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

    // FixedUpdate is called every timestep
    private void FixedUpdate()
    {
        //Constantly moves player
        if (moveLeft)
        {
            if (rb.velocity.x <= Mathf.Abs(maxSpeed))
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
            }
        }

        if (moveRight)
        {
            if (rb.velocity.x <= Mathf.Abs(maxSpeed))
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
            }
        }

        // Increase gravity if falling
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 3f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if grounded every 3 frames
        if (Time.frameCount % 3 == 0)
        {
            CheckIfGrounded();
        }

        // Reset coyote time
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Check ammo every 5 frames
        if(Time.frameCount % 5 == 0 && ammoBar.GetComponent<Slider>().value <= 0)
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

    //Controls left movement
    public void MovePlayerLeft()
    {
        if (controlsOn)
        {
            moveLeft = true;
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }
    }

    //Controls right movement
    public void MovePlayerRight()
    {
        if (controlsOn)
        {
            moveRight = true;
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }

    //Stops player movement
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

    //Controls jumping
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

    //Check before jumping
    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        
        if (colliders != null)
        {
            isGrounded = true;
            emissionModule.enabled = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }

            isGrounded = false;
            emissionModule.enabled = false;
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

        if (collision.gameObject.CompareTag("EndlessEnemy"))
        {
            StopMovement();

            health--;

            if (health <= 0)
            {
                playerAnim.SetTrigger("playerDead");

                onEndlessDie.Invoke();
            }
        }
    }
}
