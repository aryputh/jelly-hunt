using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Show : MonoBehaviour
{
    public GameObject splatterGameobject;
    public int id;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PostProcess", 0) == id)
        {
            splatterGameobject.SetActive(true);
        }
        else
        {
            splatterGameobject.SetActive(false);
        }
    }
}
