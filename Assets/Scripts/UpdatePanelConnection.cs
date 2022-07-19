using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePanelConnection : MonoBehaviour
{
    public string URL = "";
    public GameObject updatePanel;
    
    void Awake()
    {
        StartCoroutine(loadData(URL));
    }

    IEnumerator loadData(string url)
    {
		//using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
		//{
		//	Request and wait for the desired page.
		//   yield return webRequest.SendWebRequest();

		//	if (webRequest.isNetworkError)
		//	{
		//		Debug.Log("Error: " + webRequest.error);
		//	}
		//	else
		//	{
		//		if (webRequest.downloadHandler.text == Application.version)
		//		{
		//			updatePanel.SetActive(false);
		//		}
		//	}
		//}

		using (UnityWebRequest webReq = UnityWebRequest.Get(URL))
		{
            yield return webReq.SendWebRequest();

            if(webReq.result == UnityWebRequest.Result.ConnectionError)
			{
                Debug.Log("ERROR: " + webReq.error);
			}
			else
			{
                if (webReq.downloadHandler.text == Application.version)
                {
                    updatePanel.SetActive(false);
                }
            }
		}
    }

	public void CheckForUpdates()
	{
		StartCoroutine(loadData(URL));
	}
}
