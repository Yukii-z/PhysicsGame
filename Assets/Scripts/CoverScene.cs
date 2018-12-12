using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoverScene : MonoBehaviour
{
	private bool startFade=false;
	private bool fade;
	public GameObject fadeObj;
	private bool bookAud;
	public float fadeSpeed = 4.0f;
	private GameObject mainCam;
	// Use this for initialization
	void Start ()
	{
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			fade = true;
			if (!bookAud)
			{
				mainCam.GetComponent<AudioSource>().Play();
				bookAud = !bookAud;
			}
		}

		if (!startFade)
		{
			Color newColor = fadeObj.GetComponent<SpriteRenderer>().color;
			newColor.a = Mathf.Lerp(newColor.a, 1, fadeSpeed * Time.fixedDeltaTime);
			fadeObj.GetComponent<SpriteRenderer>().color = newColor;
			if (fadeObj.GetComponent<SpriteRenderer>().color.a < 0.01f)
			{
				startFade = !startFade;
			}
		}
		
		if (fade)
		{Debug.Log("input");
			fadeObj.GetComponent<SpriteRenderer>().color = new Color(0,0,0,
				Mathf.Lerp(fadeObj.GetComponent<SpriteRenderer>().color.a,1.0f,fadeSpeed * Time.deltaTime));
			if (fadeObj.GetComponent<SpriteRenderer>().color.a >0.99f)
			{
				fade = false;
				SceneManager.LoadScene(1);
			}
		}
	}
}
