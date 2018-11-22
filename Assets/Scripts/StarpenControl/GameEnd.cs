using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
	private GameObject centerController;
	// Use this for initialization
	void Start () {
		centerController=GameObject.FindGameObjectWithTag("GameController");
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("GameEnd");
		if (GameSet.Instance.gameSituation == EGameProcess.PlayGame)
		{
			Debug.Log("GameEnd");
			GameSet.Instance.gameSituation = EGameProcess.StopGame;
			centerController.GetComponent<Timer>().stop(); 
			Time.timeScale = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
