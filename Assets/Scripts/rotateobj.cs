using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateobj : MonoBehaviour
{
    public Vector3 rotate;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotate.x,rotate.y,rotate.z);
    }
}
