using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowColorSelectionOnSettings : MonoBehaviour
{
    public string hexcode;
    public GameObject selectionSprite;

    // Update is called once per frame
    void Update()
    {
        ManuallyUpdate();
    }

    // Manually updates splatter status
    public void ManuallyUpdate()
    {
        if (PlayerPrefs.GetString("PelletColor", "EC968E") == hexcode)
        {
            selectionSprite.SetActive(true);
        }
        else
        {
            selectionSprite.SetActive(false);
        }
    }
}
