using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Management")]
    private Rigidbody2D rb;
    public float speed = 1;
    public float jumpForce = 1;
    public SpriteRenderer player;
    public bool moveLeft, moveRight;
    public float maxSpeed;

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

    [Header("Death")]
    public Animator playerDieAnim;

    private float coyoteTime = 0.2f;
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

    private void LateUpdate()
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
            rb.gravityScale = 1.5f;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 2f;
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
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                coyoteTimeCounter = 0f;
            }
            else if(coyoteTimeCounter > 0f)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                coyoteTimeCounter = 0f;
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
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    public IEnumerator Restart()
    {
        controlsOn = false;

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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

            playerDieAnim.SetTrigger("playerDead");

            StartCoroutine(Restart());
        }
    }
}
