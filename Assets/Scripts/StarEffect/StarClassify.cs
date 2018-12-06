using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarClassify : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GameObject[] trueMoons;
		trueMoons = GameObject.FindGameObjectsWithTag("UniverseStars");
		for (int i = 0; i < trueMoons.Length; i++)
		{
			trueMoons[i].GetComponent<Animator>().SetTrigger("NormalStar");
		}
	}
}
