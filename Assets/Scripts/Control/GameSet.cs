using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	
	// Use this for initialization
	void Start ()
	{
		gameSituation = EGameProcess.PreparedGame;
		GetComponent<Timer>().enabled = true;
		Time.timeScale = 0;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && gameSituation == EGameProcess.StopGame)
		{
			gameObject.GetComponent<Timer>().HighScoreRecord();
			Reset();
			gameSituation = EGameProcess.PreparedGame;
		}else if (Input.GetMouseButtonDown(0) && gameSituation == EGameProcess.PreparedGame)
		{
			gameSituation = EGameProcess.PlayGame;
			Time.timeScale = 1;
		}
	}

	void Reset()
	{
		gameObject.GetComponent<Timer>().reset();
		GameObject.FindGameObjectWithTag("Starpen").transform.position = 
			GameObject.FindGameObjectWithTag("Starpen").GetComponent<MouseMoveItem>().startPenPos;
	}
}

public enum EGameProcess
{
	PlayGame,
	StopGame,
	PreparedGame,
}
