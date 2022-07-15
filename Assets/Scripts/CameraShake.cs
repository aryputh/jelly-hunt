using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public GameObject cam;
    public float duration, magnitude;

	public void StartCamShake()
    {
        StartCoroutine(CamShake());
    }
    
    public IEnumerator CamShake()
    {
        Vector3 originalPos = cam.transform.position;

        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            cam.transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cam.transform.localPosition = originalPos;
    }
}
