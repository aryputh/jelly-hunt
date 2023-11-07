using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongratsDialogueBox : MonoBehaviour
{
    [Header("Basic Values")]
    public TMP_Text message;
    public GameObject box;

    [Header("Customization")]
    public float repeatRate;
    [Range(0, 100)]
    public float chanceToHide;
    public string[] listOfMessages;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeBoxProperties", 0.01f, repeatRate);
    }

    void ChangeBoxProperties()
	{
        if(Random.Range(0, 101) <= chanceToHide)
		{
            box.SetActive(false);
		}
		else
		{
            box.SetActive(true);
        }

        message.text = listOfMessages[Random.Range(0, listOfMessages.Length)];
	}
}
