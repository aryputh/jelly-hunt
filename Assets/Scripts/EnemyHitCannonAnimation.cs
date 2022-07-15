using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCannonAnimation : MonoBehaviour
{
    public GameObject friendlyVersion;
    public SpriteRenderer enemyVersion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pellet"))
        {
            friendlyVersion.SetActive(true);
            enemyVersion.color = new Color32(0, 0, 0, 0);
        }
    }
}
