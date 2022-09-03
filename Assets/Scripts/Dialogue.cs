using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] lines;
    public Color[] colors;
    public float textSpeed;
    public bool isDone;
    public AudioSource typeSound1;
    public AudioSource typeSound2;
    public GameObject[] ObjectsToActivateWhenDone;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        dialogueText.color = colors[index];

        isDone = false;

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.color = colors[index];
                dialogueText.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;

        StartCoroutine(TypeAnim());
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;

            dialogueText.color = colors[index];
            dialogueText.text = string.Empty;

            StartCoroutine(TypeAnim());
        }
        else
        {
            isDone = true;

			for (int i = 0; i < ObjectsToActivateWhenDone.Length; i++)
			{
                ObjectsToActivateWhenDone[i].SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeAnim()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;

            if(Random.Range(1, 2) == 1)
			{
                typeSound1.PlayOneShot(typeSound1.clip);
            }
			else
			{
                typeSound2.PlayOneShot(typeSound2.clip);
            }

            yield return new WaitForSeconds(textSpeed);
        }
    }
}
