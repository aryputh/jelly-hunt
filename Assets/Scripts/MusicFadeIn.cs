using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicFadeIn : MonoBehaviour
{
    public int fadeInTime = 10;
    private AudioSource audio;
    public float finalMusicVolume = 1;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (audio.volume < finalMusicVolume)
        {
            audio.volume = audio.volume + (Time.deltaTime / (fadeInTime + finalMusicVolume));
        }
        else
        {
            Destroy(this);
        }
    }
}