using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarryMusicWithinScenes : MonoBehaviour
{
    private static CarryMusicWithinScenes instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (!instance.GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void turnMusicOff()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            instance = null;
        }
    }
}
