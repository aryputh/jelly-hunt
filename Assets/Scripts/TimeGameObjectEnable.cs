using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGameObjectEnable : MonoBehaviour
{
    //Script setup
    public GameObject gameobject;
    public float delayTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableObject());
    }

    //Update is called every frame
    void Update()
    {
        
    }

    //Toggles the active state after the delay time is complete
    IEnumerator EnableObject()
    {
        gameobject.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        gameobject.SetActive(true);
    }
}
