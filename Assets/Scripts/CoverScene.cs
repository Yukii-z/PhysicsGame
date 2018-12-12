using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoverScene : MonoBehaviour
{
	private bool fade;
	public GameObject fadeObj;
	private bool bookAud;
	public float fadeSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			fade = true;
			if (!bookAud)
			{
				GetComponent<AudioSource>().Play();
				bookAud = !bookAud;
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
