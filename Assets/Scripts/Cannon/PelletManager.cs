using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletManager : MonoBehaviour
{
	public float speed = 20;
	public Rigidbody2D rb;
	public GameObject splatter;

	private GameObject boss;

	// Use this for initialization
	void Start()
	{
		boss = GameObject.FindGameObjectWithTag("Boss");
		rb.velocity = transform.right * speed;
		Destroy(gameObject, 2);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != "Player" || collision.gameObject.tag != "Friendly")
		{
			if (collision.gameObject.tag != "WallNotBreakPellet")
			{
				StartCoroutine(DestroyBullet());
			}
		}

		if (collision.gameObject.CompareTag("Boss"))
		{
			StartCoroutine(DestroyBulletAlternate());
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Enemy"))
		{
			StartCoroutine(DestroyBullet());
			other.tag = "Friendly";
		}
	}

	IEnumerator DestroyBullet()
    {
		Instantiate(splatter, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);

		yield return new WaitForSeconds(0.02f);

		Destroy(gameObject);
	}

	IEnumerator DestroyBulletAlternate()
	{
		Instantiate(splatter, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity, boss.transform);

		yield return new WaitForSeconds(0.02f);

		Destroy(gameObject, 1f);
	}
}
