using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossTimeline : MonoBehaviour
{
    public PlayerMovement pm;
    public CameraShake cs;
    public AudioSource stompFx;
    public GameObject miniBoss;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MiniBossTime());
    }

    IEnumerator MiniBossTime()
    {
        //Initial setup.
        pm.controlsOn = false;
        yield return new WaitForSeconds(2);

        //Camera shake and stomp sounds play. Also, animate boss coming into screen.
        stompFx.Play();
        cs.StartCamShake();
        yield return new WaitForSeconds(1.7f);

        stompFx.Play();
        cs.StartCamShake();
        yield return new WaitForSeconds(1.7f);

        stompFx.Play();
        cs.StartCamShake();
        yield return new WaitForSeconds(1);

        //Villian dialog commences.
    }
}
