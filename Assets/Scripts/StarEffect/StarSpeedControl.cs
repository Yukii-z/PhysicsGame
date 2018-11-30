using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpeedControl : MonoBehaviour
{
	private float maxVel=2.5f;
	private float minVel=0.5f;
	public float properSpeed;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity=new Vector2(Random.Range(0f,0.5f),Random.Range(0f,0.5f));
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
		{
			properSpeed=Mathf.Min(GetComponent<Rigidbody2D>().velocity.magnitude, maxVel);
			properSpeed=Mathf.Max(properSpeed, minVel);
			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * properSpeed;
		}
	}
}
