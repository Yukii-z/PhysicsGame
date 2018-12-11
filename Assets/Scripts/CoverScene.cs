using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoverScene : MonoBehaviour
{
	private bool fade;
	private GameObject fadeObj;
	public float fadeSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			fade = true;
		}

		if (fade)
		{
			fadeObj.GetComponent<SpriteRenderer>().color = new Color(fadeObj.GetComponent<SpriteRenderer>().color.r,
				fadeObj.GetComponent<SpriteRenderer>().color.b,
				fadeObj.GetComponent<SpriteRenderer>().color.g,
				fadeObj.GetComponent<SpriteRenderer>().color.a * Mathf.Lerp(fadeObj.GetComponent<SpriteRenderer>().color.a,1f,fadeSpeed * Time.deltaTime));
			if (fadeObj.GetComponent<SpriteRenderer>().color.a < 0.01f)
			{
				SceneManager.LoadScene(1);
			}
		}
	}
}
