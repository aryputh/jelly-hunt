using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelectionSet : MonoBehaviour
{
    public string accessoryCode;

    public void SetAccessoryCode()
    {
        PlayerPrefs.SetString("AccessoryCode", accessoryCode);

        //Debug.Log("Set accessory to: " + accessoryCode);
    }
}
