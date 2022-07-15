using UnityEngine;

public class GoLink : MonoBehaviour
{
    public string URL;
    public void Open()
    {
        Application.OpenURL(URL);
    }
}
