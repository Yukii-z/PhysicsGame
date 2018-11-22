using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
	private GameObject centerController;
	private int collideTime = 0;
	public int endCollideTime = 5;
	private GameObject timeCount;
	// Use this for initialization
	void Start () {
		centerController=GameObject.FindGameObjectWithTag("GameController");
		timeCount=GameObject.FindGameObjectWithTag("CountTime");
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (GameSet.Instance.gameSituation == EGameProcess.PlayGame)
		{
			TimeCount();
			if (collideTime == endCollideTime)
			{
				GameEndProcess();
			}
		}
	}

	void TimeCount()
	{
		collideTime++;
		timeCount.GetComponent<Text>().text = collideTime.ToString();
	}

	void GameEndProcess()
	{
		GameSet.Instance.gameSituation = EGameProcess.StopGame;
		centerController.GetComponent<Timer>().stop(); 
		Time.timeScale = 0;
	}
}
