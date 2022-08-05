using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossCollisionDetector : MonoBehaviour
{
	public UnityEvent whatToDo;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Pellet"))
		{
			whatToDo.Invoke();
		}
	}
}
