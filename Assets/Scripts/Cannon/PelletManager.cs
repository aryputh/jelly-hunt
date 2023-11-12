using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletManager : MonoBehaviour
{
	public float speed = 10;
	public GameObject splatterParticles;

	GameObject boss;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
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
				DestroyBullet();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Enemy"))
		{
            DestroyBullet();
			other.tag = "Friendly";
		}

		if (other.CompareTag("EndlessEnemy"))
		{
            DestroyBullet();
			other.tag = "Friendly";
		}

		if (other.CompareTag("Boss"))
		{
            DestroyBullet();
		}
	}

	private void DestroyBullet()
    {
		Instantiate(splatterParticles, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);

		Destroy(gameObject, 0.02f);
	}
}
