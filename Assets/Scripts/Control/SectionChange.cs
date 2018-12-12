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
	private bool bookAudPlay;
	private bool starMute;
	private bool starPenUnable;
	// Use this for initialization
	void Start ()
	{
		timer = GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {

		if (i > backgroundChange.Length - 1)
		{		
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
         	GameObject.FindGameObjectWithTag("Starpen").GetComponent<AudioSource>().Play();
			GameObject.FindGameObjectWithTag("Starpen").GetComponent<AudioSource>().volume = 0.02f;
			GameSet.Instance.gameSituation = EGameProcess.StopGame;

			GameSet.Instance.instructionMouse.enabled = false;
			GameSet.Instance.instructionE.enabled = true;
			GetComponent<Timer>().stop(); 
			Time.timeScale = 0;
		}

		currentTime = timer.currentTime;
		if (currentTime > backgroundChange[i])
		{
			if (i == backgroundChange.Length - 2 && !starPenUnable)
			{
				StartCoroutine(FadeStarpen());
				starPenUnable = !starPenUnable;
			}
			if (!bookAudPlay)
			{
				GetComponent<AudioSource>().clip = bookAud;
				GetComponent<AudioSource>().Play();
				fadeIn.Instance.openTrans = true;
				bookAudPlay = !bookAudPlay;
			}
			/*background[i].GetComponent<SpriteRenderer>().color = new Color(background[i].GetComponent<SpriteRenderer>().color.r,
				background[i].GetComponent<SpriteRenderer>().color.b,
				background[i].GetComponent<SpriteRenderer>().color.g,
				Mathf.Lerp(background[i].GetComponent<SpriteRenderer>().color.a,0 ,fadeSpeed * Time.deltaTime));*/
			Color newColor = background[i].GetComponent<SpriteRenderer> ().color;
			newColor.a = Mathf.Lerp (newColor.a, 0, fadeSpeed * Time.deltaTime);
			background[i].GetComponent<SpriteRenderer> ().color = newColor;

			if (background[i].GetComponent<SpriteRenderer>().color.a < 0.01f)
			{
				background[i].GetComponent<SpriteRenderer>().enabled = false;
				if (starChange[i])
				{
					StarArrow.Instance.ShuffleLinkStar();
				}
				
				StartCoroutine(ReadThePoem(i));
				bookAudPlay = !bookAudPlay;
				i++;
			}
		}

		if (i == backgroundChange.Length-1 && !starMute)
		{
			starMute = !starMute;
			for (int b = 0; b < StarArrow.Instance.skyStarList.Length; b++)
			{
				StarArrow.Instance.skyStarList[b].GetComponent<Animator>().SetBool("allStarFade", true);
				StarArrow.Instance.skyStarList[b].GetComponent<Collider2D>().enabled = false;
			}
			//GameObject.FindGameObjectWithTag("Starpen").SetActive(false);
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
	
	IEnumerator FadeStarpen()
	{
		yield return new WaitForSeconds(0.5f);
		GameObject.FindGameObjectWithTag("Starpen").GetComponent<Collider2D>().enabled=false;
		GameObject.FindGameObjectWithTag("Starpen").GetComponent<SpriteRenderer>().enabled=false;
		GameObject.FindGameObjectWithTag("Starpen").GetComponent<LineRenderer>().enabled=false;
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
