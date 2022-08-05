using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossMovement : MonoBehaviour
{
    [Header("General")]
    public SpriteRenderer spriteRend;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public Animator anim;
    public GameObject miniBossParent;

    [Header("Sideways Movement")]
    public Transform pos1;
    public Transform pos2;

    [HideInInspector]
    public bool startMovement;

    private bool doFlipX;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        doFlipX = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (startMovement)
		{
            Debug.Log("Starting boss movement...");
            MoveBoss();
		}

        //if (startMovement)
        //{
        //    startMovement = false;
        //
        //    InvokeRepeating("ApplyJumpForce", 0, 2);
        //}
    }

    public void MoveBoss()
	{
        if(doFlipX == false && transform.position.x != -4.9f)
		{
            transform.position = Vector3.Lerp(pos1.position, pos2.position, timer / 5);
        }
        //this is the line giving me problems. the player initially starts at x = 4.85 but is tped to 4.9 st the start of the lerp.
        else if (doFlipX == false && transform.position.x == -4.9f)
		{
            doFlipX = true;
            timer = 0;
            Debug.Log("Flipped boss to face right.");
        }
        
        if (doFlipX == true && transform.position.x != 4.9f)
        {
            transform.position = Vector3.Lerp(pos2.position, pos1.position, timer / 5);
        }
        else if (doFlipX == true && transform.position.x == 4.9f)
        {
            doFlipX = false;
            timer = 0;
            Debug.Log("Flipped boss to face left.");
        }

        spriteRend.flipX = doFlipX;
    }

    public void ApplyJumpForce()
	{
        anim.Play("Colored_Boss", -1, 0);
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
	}
}
