using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomHelpMessage : MonoBehaviour
{
    public TMP_Text messageText;
    public string[] messages;

    // Start is called before the first frame update
    void Start()
    {
        messageText.text = messages[Random.Range(0, messages.Length)];
    }
}
