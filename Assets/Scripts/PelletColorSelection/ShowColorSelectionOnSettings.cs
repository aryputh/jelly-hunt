using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowColorSelectionOnSettings : MonoBehaviour
{
    public string hexcode;
    public GameObject selectionSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("PelletColor") == hexcode)
        {
            selectionSprite.SetActive(true);
        }
        else
        {
            selectionSprite.SetActive(false);
        }
    }
}
