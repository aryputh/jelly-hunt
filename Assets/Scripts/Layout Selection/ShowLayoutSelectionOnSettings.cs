using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLayoutSelectionOnSettings : MonoBehaviour
{
    public int layoutType;
    public GameObject selectionSprite;

    // Update is called once per frame
    void Update()
    {
        ManuallyUpdate();
    }

    // Manually update the status
    public void ManuallyUpdate()
    {
        if (PlayerPrefs.GetInt("LayoutStyle", 1) == layoutType)
        {
            selectionSprite.SetActive(true);
        }
        else
        {
            selectionSprite.SetActive(false);
        }
    }
}
