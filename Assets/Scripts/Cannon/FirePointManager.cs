using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointManager : MonoBehaviour
{
    //private bool m_FacingRight = true;
    public PlayerMovement pm;

    // Update is called once per frame
    void Update()
    {
        //// If the input is moving the player right and the player is facing left...
        //if (Input.GetAxis("Horizontal") > 0 && !m_FacingRight)
        //{
        //    // ... flip the player.
        //    Flip();
        //}
        //// Otherwise if the input is moving the player left and the player is facing right...
        //else if (Input.GetAxis("Horizontal") < 0 && m_FacingRight)
        //{
        //    // ... flip the player.
        //    Flip();
        //}

        if(pm.moveRight)
        {
            gameObject.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(pm.moveLeft)
        {
            gameObject.GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //private void Flip()
    //{
    //    // Switch the way the player is labelled as facing.
    //    m_FacingRight = !m_FacingRight;

    //    transform.Rotate(0f, 180f, 0f);
    //}
}
