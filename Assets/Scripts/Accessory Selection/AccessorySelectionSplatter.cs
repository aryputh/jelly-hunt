using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelectionSplatter : MonoBehaviour
{
    public string accessoryCode;
    public GameObject selectionSprite;

    // Update is called once per frame
    void Update()
    {
        ManuallyUpdate();
    }

    // Manually updates splatter status
    public void ManuallyUpdate()
    {
        if (PlayerPrefs.GetString("AccessoryCode", "") == accessoryCode)
        {
            selectionSprite.SetActive(true);
        }
        else
        {
            selectionSprite.SetActive(false);
        }
    }
}
