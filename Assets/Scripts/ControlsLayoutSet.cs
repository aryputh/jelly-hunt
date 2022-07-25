using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsLayoutSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseLayout(int layout)
	{
        PlayerPrefs.SetInt("LayoutStyle", layout);
	}
}
