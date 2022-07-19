using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] sentences;
    public float letterDelay;
    public GameObject continueButton;
    public bool isDone;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
        isDone = false;

        StartCoroutine(TypeAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText.text == sentences[index])
		{
            continueButton.SetActive(true);
		}
    }

    IEnumerator TypeAnimation()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }

    public void NextSentence()
	{
        if (index < sentences.Length - 1 && dialogueText.text == sentences[index])
		{
            index++;
            dialogueText.text = "";

            StartCoroutine(TypeAnimation());
		}
		else if(index == sentences.Length - 1)
		{
            dialogueText.text = "";

            isDone = true;

            continueButton.SetActive(false);
            gameObject.SetActive(false);
		}
		else
		{
            dialogueText.text = sentences[index];

        }
	}
}
