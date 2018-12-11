using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionChange : MonoBehaviour
{
	private Timer timer;
	private float currentTime;
	public GameObject[] background;
	private int i=0;
	public float[] backgroundChange;
	public bool[] starChange;
	public float fadeSpeed=0.7f;
	public AudioClip[] poetry;
	public AudioClip bookAud;
	// Use this for initialization
	void Start ()
	{
		timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {

		if (i > backgroundChange.Length - 1)
		{
			GameSet.Instance.gameSituation = EGameProcess.StopGame;
			GameSet.Instance.instructionMouse.enabled = false;
			GameSet.Instance.instructionE.enabled = true;
			GetComponent<Timer>().stop(); 
			Time.timeScale = 0;
		}

		currentTime = timer.currentTime;
		if (currentTime > backgroundChange[i])
		{
			background[i].GetComponent<SpriteRenderer>().color = new Color(background[i].GetComponent<SpriteRenderer>().color.r,
				background[i].GetComponent<SpriteRenderer>().color.b,
				background[i].GetComponent<SpriteRenderer>().color.g,
				background[i].GetComponent<SpriteRenderer>().color.a * Mathf.Lerp(background[i].GetComponent<SpriteRenderer>().color.a,0f,fadeSpeed * Time.deltaTime));
			if (background[i].GetComponent<SpriteRenderer>().color.a < 0.01f)
			{
				background[i].GetComponent<SpriteRenderer>().enabled = false;
				if (starChange[i])
				{
					StarArrow.Instance.ShuffleLinkStar();
				}

				GetComponent<AudioSource>().clip = bookAud;
				GetComponent<AudioSource>().Play();
				StartCoroutine(ReadThePoem(i));
				i++;
			}
		}


	}

	IEnumerator ReadThePoem(int x)
	{
		yield return new WaitForSeconds(1.0f);	
		if (poetry[i] != null)
		{
			GetComponent<AudioSource>().clip = poetry[i];
			GetComponent<AudioSource>().Play();
		}
	}
	
	public void reset()
	{
		i = 0;
		for (int x=0; x < background.Length; x++)
		{
			background[x].GetComponent<SpriteRenderer>().enabled = true;
			background[i].GetComponent<SpriteRenderer>().color = new Color(
				background[i].GetComponent<SpriteRenderer>().color.r,
				background[i].GetComponent<SpriteRenderer>().color.b,
				background[i].GetComponent<SpriteRenderer>().color.g, 1);
		}
	}
}
