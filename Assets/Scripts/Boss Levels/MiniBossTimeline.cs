using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBossTimeline : MonoBehaviour
{
    [Header("Basic")]
    public PlayerMovement pm;
    public CameraShake cs;
    public GameObject miniBoss;
    public GameObject miniBossParent;
    public int health;
    public Slider healthBar;
    public Animator anim;
    public Animator redPanelAnim;
    public GameObject[] pelletSpawners;
    public GameObject pelletPrefab;
    public GameObject goal;
    public GameObject physicalButton1;
    public GameObject physicalButton2;
    public MiniBossMovement miniBossMovement;

    [Header("Audio")]
    public AudioSource stompFx;
    public GameObject bossMusic;
    public AudioSource regMusic;
    public AudioSource bossDefeatedSound;

    [Header("Dialogue")]
    public Dialogue dialogueScript;
    public GameObject dialogueBox;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);

        healthBar.maxValue = health;
        healthBar.value = health;

        StartCoroutine(MiniBossTime());
    }

	private void Update()
	{
		if (dialogueScript.isDone)
		{
            StartCoroutine(BossMovement());
		}

        if (health <= 0)
        {
            bossDefeatedSound.Play();
            miniBossParent.SetActive(false);
            goal.SetActive(true);

            physicalButton1.SetActive(false);
            physicalButton2.SetActive(false);

            StartCoroutine(StartFadeBossMusic(bossMusic.GetComponent<AudioSource>(), 1, 0));
        }
    }

    IEnumerator StartFadeBossMusic(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        gameObject.SetActive(false);
        yield break;
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
        anim.Play("Colored_Boss", -1, 0);
        //miniBoss.transform.position = new Vector3(4.9f, -0.2096012f, -0.05f);
        miniBossParent.transform.position = new Vector3(4.85f, -0.2096012f, -0.05f);
        yield return new WaitForSeconds(1);

        //Dialog
        dialogueBox.SetActive(true);
    }

    public void StartBossMovementButton()
	{
        StartCoroutine(BossMovement());
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

        redPanelAnim.SetTrigger("flash");
        //redPanelAnim.Play("RedFlashingPanel", -1, 0);
        yield return new WaitForSeconds(0.5f);
        miniBossMovement.startMovement = true;
        miniBossMovement.startJumping = true;
    }

    public void SpawnPellets()
	{
        StartCoroutine(SpawnPelletsDelay(0.03f));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//if (collision.gameObject.CompareTag("Pellet"))
		//{
		//	print("Pellet hit boss!");

		//	StartCoroutine(DestroyBulletAlternate());

		//	Destroy(collision.gameObject, 3f);
		//}
	}

    IEnumerator DestroyBulletAlternate()
    {
        yield return new WaitForSeconds(0.01f);

        health--;
        healthBar.value = health;
    }

    IEnumerator SpawnPelletsDelay(float delay)
    {
        for (int i = 0; i < pelletSpawners.Length; i++)
        {
            Vector3 spawnPos = new Vector3(pelletSpawners[i].transform.position.x, pelletSpawners[i].transform.position.y, pelletPrefab.transform.position.z);

            Instantiate(pelletPrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(delay);
        }
    }

    public void PelletHitBoss()
	{
        print("Pellet hit boss!");

        StartCoroutine(DestroyBulletAlternate());

        //Destroy(collision.gameObject, 3f);
    }
}
