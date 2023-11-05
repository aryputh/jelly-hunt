using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsLayoutGet : MonoBehaviour
{
	public Button leftButton;
	public Button rightButton;
	public Button jumpButton;
	public Button shootButton;

	private int layout;

    void Awake()
    {
        layout = PlayerPrefs.GetInt("LayoutStyle", 1);
    }

	void Start()
	{

		RectTransform leftrect = (RectTransform)leftButton.transform;
		RectTransform rightrect = (RectTransform)rightButton.transform;
		RectTransform jumprect = (RectTransform)jumpButton.transform;
		RectTransform shootrect = (RectTransform)shootButton.transform;

		if (layout == 1)
		{
			leftrect.anchorMin = new Vector2(0, 0);
			leftrect.anchorMax = new Vector2(0, 0);
			leftrect.anchoredPosition = new Vector2(30, 30);

			rightrect.anchorMin = new Vector2(0, 0);
			rightrect.anchorMax = new Vector2(0, 0);
			rightrect.anchoredPosition = new Vector2(125, 30);

			jumprect.anchorMin = new Vector2(1, 0);
			jumprect.anchorMax = new Vector2(1, 0);
			jumprect.anchoredPosition = new Vector2(-220, 30);

			shootrect.anchorMin = new Vector2(1, 0);
			shootrect.anchorMax = new Vector2(1, 0);
			shootrect.anchoredPosition = new Vector2(-120, 30);

			//Debug.Log("setup buttons - 1");
		}
		else if(layout == 2)
		{
			leftrect.anchorMin = new Vector2(1, 0);
			leftrect.anchorMax = new Vector2(1, 0);
			leftrect.anchoredPosition = new Vector2(-220, 30);

			rightrect.anchorMin = new Vector2(1, 0);
			rightrect.anchorMax = new Vector2(1, 0);
			rightrect.anchoredPosition = new Vector2(-120, 30);

			jumprect.anchorMin = new Vector2(0, 0);
			jumprect.anchorMax = new Vector2(0, 0);
			jumprect.anchoredPosition = new Vector2(30, 30);

			shootrect.anchorMin = new Vector2(0, 0);
			shootrect.anchorMax = new Vector2(0, 0);
			shootrect.anchoredPosition = new Vector2(125, 30);

			//Debug.Log("setup buttons - 2");
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
