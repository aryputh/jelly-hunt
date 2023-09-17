using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelectionGet : MonoBehaviour
{
    public string accessoryCode;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("AccessoryCode") != accessoryCode)
        {
            gameObject.SetActive(false);
        }
    }

    // Called when the object is enabled
    void OnEnable()
    {
        if (PlayerPrefs.GetString("AccessoryCode") != accessoryCode)
        {
            gameObject.SetActive(false);
        }
    }
}
