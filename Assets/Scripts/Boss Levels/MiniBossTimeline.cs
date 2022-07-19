using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossTimeline : MonoBehaviour
{
    [Header("Basic")]
    public PlayerMovement pm;
    public CameraShake cs;
    public GameObject miniBoss;

    [Header("Audio")]
    public AudioSource stompFx;
    public AudioSource bossMusic;


    [Header("Dialogue")]
    public Dialogue dialogueScript;
    public GameObject dialogueBox;
    public GameObject dialogueContinueButton;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        dialogueContinueButton.SetActive(false);

        StartCoroutine(MiniBossTime());
    }

	private void Update()
	{
		if (dialogueScript.isDone)
		{
            StartCoroutine(BossMovement());
		}
	}

	IEnumerator MiniBossTime()
    {
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
        miniBoss.transform.position = new Vector3(5.59f, -0.73f, -1);
        yield return new WaitForSeconds(1);

        //Dialog
        dialogueBox.SetActive(true);
        dialogueContinueButton.SetActive(true);
    }

    IEnumerator BossMovement()
    {
        //Prevents the loop from being spammed
        dialogueScript.isDone = false;

        yield return new WaitForSeconds(1);

        //Start the boss music
        bossMusic.Play();
        pm.EnableControls();

        //Boss movement
    }
}
