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
	// Use this for initialization
	void Start ()
	{
		timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
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
				i++;
				if (starChange[i])
				{
					StarArrow.Instance.ShuffleLinkStar();
				}
			}
		}

		if (i > backgroundChange.Length - 1)
		{
			GameSet.Instance.gameSituation = EGameProcess.StopGame;
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
