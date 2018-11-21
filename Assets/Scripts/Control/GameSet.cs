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
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && gameSituation == EGameProcess.StopGame)
		{
			Reset();
			gameSituation = EGameProcess.PreparedGame;
		}

		if (Input.GetMouseButtonDown(0) && gameSituation == EGameProcess.PreparedGame)
		{
			gameSituation = EGameProcess.PlayGame;
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
