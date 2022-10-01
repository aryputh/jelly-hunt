using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    public int sceneNumber;
    public GameObject animation;

    public void NextScene()
    {
        animation.SetActive(true);

        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(3);

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncOp.isDone)
        {
            yield return null;
        }
    }
}