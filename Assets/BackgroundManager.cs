using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject animation;
    public bool changeScenes;
    public int sceneToChangeTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animation.SetActive(true);
            StartCoroutine(ChangeScenes());
        }
    }

    public IEnumerator ChangeScenes()
    {
        if(changeScenes == true)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadSceneAsync(sceneToChangeTo);
        }
    }
}
