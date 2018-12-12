using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeIn : MonoBehaviour
{
	
	private static fadeIn instance;
	public static fadeIn Instance
	{
		get
		{
			return instance;
		}
	}

	protected virtual void Awake()
	{
		instance = this;
	}
	
	public GameObject fadeObj;
	private float fadeSpeed = 0.9f;
	private float transferSpeed = 4.0f;
	private bool transState;
	public bool openTrans;
	private bool startFade = true;
	public bool endFade;

	// Update is called once per frame
	void Update () {
		if (startFade)
		{
			Color newColor = GetComponent<SpriteRenderer>().color;
			newColor.a = Mathf.Lerp(newColor.a, 0, fadeSpeed * Time.fixedDeltaTime);
			GetComponent<SpriteRenderer>().color = newColor;
			if (GetComponent<SpriteRenderer>().color.a < 0.01f)
			{
				GetComponent<SpriteRenderer>().enabled = false;
				startFade = !startFade;
			}
		}

		if (openTrans)
		{
			Transfer();
		}

		if (endFade)
		{
			EndFade();
		}
	}

	void Transfer()
	{
		if (!transState)
		{
			GetComponent<SpriteRenderer>().enabled = true;
			Color newColor = fadeObj.GetComponent<SpriteRenderer>().color;
			newColor.a = Mathf.Lerp(newColor.a, 1, transferSpeed * Time.deltaTime);
			fadeObj.GetComponent<SpriteRenderer>().color = newColor;
			if (fadeObj.GetComponent<SpriteRenderer>().color.a > 0.99f)
			{
				transState = !transState;
			}
		}
		else
		{
			Color newColor = fadeObj.GetComponent<SpriteRenderer>().color;
			newColor.a = Mathf.Lerp(newColor.a, 0, transferSpeed * Time.deltaTime);
			fadeObj.GetComponent<SpriteRenderer>().color = newColor;
			if (fadeObj.GetComponent<SpriteRenderer>().color.a <0.01f)
			{
				transState = !transState;
				openTrans = !openTrans;
				GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		
	}

	void EndFade()
	{
		GetComponent<SpriteRenderer>().enabled = true;
		Color newColor = fadeObj.GetComponent<SpriteRenderer>().color;
		newColor.a = Mathf.Lerp(newColor.a, 1, transferSpeed * Time.fixedDeltaTime);
		fadeObj.GetComponent<SpriteRenderer>().color = newColor;
		if (fadeObj.GetComponent<SpriteRenderer>().color.a > 0.99f)
		{
			endFade = !endFade;
			SceneManager.LoadScene(0);
		}
	}
}
