using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDisplayManager : MonoBehaviour
{
    public PlayerMovement playerMan;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMan.health == 3)
		{
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
		}
        else if (playerMan.health == 2)
		{
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (playerMan.health == 1)
		{
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
		else
		{
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }
}
