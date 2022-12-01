using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JellyCoinTextManager : MonoBehaviour
{
    public Text jellyCoinText;
    private int jellyCoins;
    private int totalJellyCoins;

    // Start is called before the first frame update
    void Start()
    {
        jellyCoinText.text = "0";
        jellyCoins = 0;
        totalJellyCoins = PlayerPrefs.GetInt("totalJellyCoins", 0);
    }

    public void SavedABlob()
	{
        jellyCoins += 5;
        totalJellyCoins += 5;

        jellyCoinText.text = jellyCoins.ToString();
        PlayerPrefs.SetInt("totalJellyCoins", totalJellyCoins);

        print(totalJellyCoins);
    }
}
