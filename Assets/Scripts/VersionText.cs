using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
    public Text versionText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Application Version: v" + Application.version);
        versionText.text = "v" + Application.version + " ";
    }
}
