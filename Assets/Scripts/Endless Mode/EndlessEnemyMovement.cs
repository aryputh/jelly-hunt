using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemyMovement : MonoBehaviour
{
    public GameObject enemySkin;
    public GameObject friendlySkin;

    public float speed;

    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 2);

        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
		{
            transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
        else
		{
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("EndlessSwapDirection"))
		{
            if(direction == 1)
			{
                direction = 0;
			}
			else
			{
                direction = 1;
            }
		}
	}
}
