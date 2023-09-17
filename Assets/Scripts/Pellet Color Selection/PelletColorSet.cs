using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletColorSet : MonoBehaviour
{
	public Color color;

    public void SetPelletColor()
	{
		PlayerPrefs.SetString("PelletColor", ColorUtility.ToHtmlStringRGB(color));

		//Debug.Log("Set color to: " + ColorUtility.ToHtmlStringRGB(color));
	}
}
