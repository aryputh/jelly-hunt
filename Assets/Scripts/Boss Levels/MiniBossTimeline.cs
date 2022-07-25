using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossTimeline : MonoBehaviour
{
    [Header("Basic")]
    public PlayerMovement pm;
    public CameraShake cs;
    public GameObject miniBoss;
    public int health;

    [Header("Audio")]
    public AudioSource stompFx;
    public GameObject bossMusic;
    public AudioSource regMusic;

    [Header("Dialogue")]
    public Dialogue dialogueScript;
    public GameObject dialogueBox;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        health = 10;

        StartCoroutine(MiniBossTime());
    }

	private void Update()
	{
		if (dialogueScript.isDone)
		{
            StartCoroutine(BossMovement());
		}

        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }

	IEnumerator MiniBossTime()
    {
        Debug.Log("MiniBossTime");

        //Initial setup.
        pm.controlsOn = false;
        yield return new WaitForSeconds(2);

        //Camera shake and stomp sounds play. Also, animate boss coming into screen.
        stompFx.Play();
        cs.StartCamShake();
        yield return new WaitForSeconds(1.7f);

        stompFx.Play();
        cs.StartCamShake();
        yield return new WaitForSeconds(1.7f);

        stompFx.Play();
        cs.StartCamShake();
        miniBoss.transform.position = new Vector3(5.59f, -0.2096012f, -0.05f);
        yield return new WaitForSeconds(1);

        //Dialog
        dialogueBox.SetActive(true);
    }

    IEnumerator BossMovement()
    {
        Debug.Log("BossMovement");

        //Prevents the loop from being spammed
        dialogueScript.isDone = false;

        yield return new WaitForSeconds(1);

        //Start the boss music
        bossMusic.SetActive(true);
        regMusic.Pause();
        pm.EnableControls();

        //Boss movement
    }
}
