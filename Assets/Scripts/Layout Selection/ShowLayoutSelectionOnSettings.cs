using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLayoutSelectionOnSettings : MonoBehaviour
{
    public int layoutType;
    public GameObject selectionSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("LayoutStyle") == layoutType)
        {
            selectionSprite.SetActive(true);
        }
        else
        {
            selectionSprite.SetActive(false);
        }
    }
}
