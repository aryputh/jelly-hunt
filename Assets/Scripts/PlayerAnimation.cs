using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject player;
    public Sprite player1Sprite;
    public Sprite player2Sprite;

    public float spriteSwitchDelay = 1;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = player1Sprite;

        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(spriteSwitchDelay);
        
        if(sr.sprite == player1Sprite)
        {
            sr.sprite = player2Sprite;
        }
        else
        {
            sr.sprite = player1Sprite;
        }

        StartCoroutine(Animation());
    }
}
