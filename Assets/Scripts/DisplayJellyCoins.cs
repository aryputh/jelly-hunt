using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayJellyCoins : MonoBehaviour
{
    public Text display;

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
