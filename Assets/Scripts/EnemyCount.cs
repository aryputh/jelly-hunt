using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCount : MonoBehaviour
{
    private GameObject[] enemies;
    public GameObject goal;
    public TMP_Text corruptedBlobText;

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
        
        if(enemies.Length == 1)
		{
            corruptedBlobText.text = enemies.Length + " blob";
        }
		else
		{
            corruptedBlobText.text = enemies.Length + " blobs";
        }

        if (enemies.Length <= 0)
        {
            goal.SetActive(true);
        }

        StartCoroutine(CountCorrupted());
    }
}
