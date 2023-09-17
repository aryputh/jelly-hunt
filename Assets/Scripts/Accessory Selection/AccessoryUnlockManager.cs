using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryUnlockManager : MonoBehaviour
{
    [SerializeField] private int scoreRequirement;
    [SerializeField] private Button equipButton;

    // Start is called before the first frame update
    void Start()
    {
        CheckReq();
    }

    // OnEnable is called when the object is enabled
    void OnEnable()
    {
        CheckReq();
    }

    void CheckReq()
    {
        if (scoreRequirement > PlayerPrefs.GetInt("jellyScore", 0))
        {
            equipButton.interactable = false;
        }
        else
        {
            equipButton.interactable = true;
        }
    }
}
