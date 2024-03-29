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
        ManuallyUpdate();
    }

    // Manually updates splatter status
    public void ManuallyUpdate()
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
