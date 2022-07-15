using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    private GameObject[] enemies;
    public GameObject goal;
    public Text corruptedBlobText;

    // Start is called before the first frame update
    void Start()
    {
        goal.SetActive(false);
        StartCoroutine(CountCorrupted());
    }

    IEnumerator CountCorrupted()
    {
        yield return new WaitForSeconds(0.2f);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        corruptedBlobText.text = enemies.Length.ToString();

        if (enemies.Length <= 0)
        {
            goal.SetActive(true);
        }

        StartCoroutine(CountCorrupted());
    }
}
