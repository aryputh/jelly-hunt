using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JellyCoinTextManager : MonoBehaviour
{
    public Text currentJellyScoreText;
    public Text highJellyScoreText;
    private int currentJellyCoins;
    private int highJellyScore;

    // Start is called before the first frame update
    void Start()
    {
        highJellyScore = PlayerPrefs.GetInt("jellyScore", 0);
        currentJellyCoins = 0;

        currentJellyScoreText.text = "0";
        highJellyScoreText.text = highJellyScore.ToString();
    }

    public void SavedABlob()
	{
        currentJellyCoins += 5;

        currentJellyScoreText.text = currentJellyCoins.ToString();

        if (currentJellyCoins > highJellyScore)
        {
            PlayerPrefs.SetInt("jellyScore", currentJellyCoins);
            highJellyScore = PlayerPrefs.GetInt("jellyScore", 0);

            highJellyScoreText.text = highJellyScore.ToString();
        }
    }
}
