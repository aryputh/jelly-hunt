using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour
{
    public GameObject splatterParticle;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;

    // Start is called once furing the first frame
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        splatterParticle.SetActive(true);
        spriteRenderer.enabled = false;
        trailRenderer.emitting = false;
        Destroy(gameObject, 2f);
    }
}
