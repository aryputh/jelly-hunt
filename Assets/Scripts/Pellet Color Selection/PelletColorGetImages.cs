using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PelletColorGetImages : MonoBehaviour
{
	public Image imageRend;

	public void Start()
	{
		GetPelletColor();
	}

	public void GetPelletColor()
	{
		Color color;
		ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("PelletColor", "EC968E"), out color);

		imageRend.color = color;
		Debug.Log("Updated color!");
	}
}
