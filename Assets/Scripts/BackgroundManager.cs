using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject animation;
    public AudioSource flowerReachedSound;
    public bool changeScenes;
    public int sceneToChangeTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animation.SetActive(true);
            flowerReachedSound.Play();
            StartCoroutine(ChangeScenes());
        }
    }

    public IEnumerator ChangeScenes()
    {
        if(changeScenes)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadSceneAsync(sceneToChangeTo);
        }
    }
}
