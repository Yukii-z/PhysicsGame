using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTurnOff : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Physics2D.gravity = new Vector2(0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
