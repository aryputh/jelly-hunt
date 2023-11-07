using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayJellyCoins : MonoBehaviour
{
    public TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        display.text = PlayerPrefs.GetInt("jellyScore", 0).ToString();
    }

    public void UpdateCoins()
    {
        display.text = PlayerPrefs.GetInt("jellyScore", 0).ToString();
    }
}
