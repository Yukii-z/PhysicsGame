using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSet : MonoBehaviour
{
	private static GameSet instance;
	public static GameSet Instance
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
	
	public EGameProcess gameSituation;
	public Text instructionMouse;
	public Text instructionE;
	
	// Use this for initialization
	void Start (){
		gameSituation = EGameProcess.PreparedGame;
		GetComponent<Timer>().enabled = true;
		Time.timeScale = 0;
		//Screen.SetResolution(500, 750, false);

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && gameSituation == EGameProcess.StopGame)
		{
			/*if (highScore)
			{
				gameObject.GetComponent<Timer>().HighScoreRecord();
			}
			else
			{
				gameObject.GetComponent<Timer>().LowScoreRecord();
			}*/

			Reset();
			fadeIn.Instance.endFade = true;
			gameSituation = EGameProcess.PreparedGame;
		}
		
		if (Input.GetMouseButtonDown(0) && gameSituation == EGameProcess.PreparedGame)
		{
			instructionMouse.enabled = true;
			instructionE.enabled = false;
			gameSituation = EGameProcess.PlayGame;
			Time.timeScale = 1;
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();
			GameObject.FindGameObjectWithTag("Starpen").GetComponent<MusicMute>().muteStart = true;
		}

		if (Input.GetKeyDown(KeyCode.E) && gameSituation == EGameProcess.PlayGame)
		{
			/*GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Play();
			instructionMouse.enabled = false;
			instructionE.enabled = true;
			Reset();
			gameSituation = EGameProcess.PreparedGame;*/
			SceneManager.LoadScene(1);
		}
	}


	void Reset()
	{
		gameObject.GetComponent<Timer>().reset();
		GameObject.FindGameObjectWithTag("Starpen").transform.position = 
			GameObject.FindGameObjectWithTag("Starpen").GetComponent<MouseMoveItem>().startPenPos;
		StarArrow.Instance.StarReset();
		GetComponent<SectionChange>().reset();
	}
}

public enum EGameProcess
{
	PlayGame,
	StopGame,
	PreparedGame,
}
