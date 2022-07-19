using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletColorGet : MonoBehaviour
{
	public SpriteRenderer spriteRend;

	public void Start()
	{
		GetPelletColor();
	}

	public void GetPelletColor()
	{
		Color color;
		ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("PelletColor", "EC968E"), out color);

		spriteRend.color = color;
		Debug.Log("Updated color!");
	}
}
