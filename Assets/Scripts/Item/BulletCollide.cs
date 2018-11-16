using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	public void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("touch");
		Destroy(this.gameObject);
	}
}
