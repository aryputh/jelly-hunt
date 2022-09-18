using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Set : MonoBehaviour
{
    public void EnablePostprocessing()
	{
		PlayerPrefs.SetInt("PostProcess", 1);
	}

	public void DisablePostprocessing()
	{
		PlayerPrefs.SetInt("PostProcess", 0);
	}
}
