using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMoving : MonoBehaviour
{
	public float speed = 30.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.back,speed*Time.deltaTime,Space.Self);
	}
}
