using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomHelpMessage : MonoBehaviour
{
    public Text messageText;
    public string[] messages;

    // Start is called before the first frame update
    void Start()
    {
        messageText.text = messages[Random.Range(0, messages.Length)];
    }
}
