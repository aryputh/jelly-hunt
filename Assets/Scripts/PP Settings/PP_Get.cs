using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Get : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("PostProcess") == 0)
		{
            gameObject.SetActive(false);
		}
		else
		{
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
