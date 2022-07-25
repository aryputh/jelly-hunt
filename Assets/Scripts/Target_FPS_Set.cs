using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_FPS_Set : MonoBehaviour
{
    public int targetFps;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
