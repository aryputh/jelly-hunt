using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemyHitCannonAnimation : MonoBehaviour
{
    public GameObject friendlyVersion;
    public SpriteRenderer enemyVersion;

    private JellyCoinTextManager jctm;

	void Start()
	{
        jctm = FindObjectOfType<JellyCoinTextManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pellet"))
        {
            jctm.SavedABlob();
            friendlyVersion.SetActive(true);
            enemyVersion.color = new Color32(0, 0, 0, 0);

            Destroy(gameObject, 0.1f);
        }
    }
}
