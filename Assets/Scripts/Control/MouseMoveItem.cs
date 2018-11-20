using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveItem : MonoBehaviour
{
	private Vector3 mousePos;
	public float dragForce = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			//set velocity
			mousePos = Input.mousePosition;
			//Debug.Log(mousePos);
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			GetComponent<Rigidbody2D>().AddForce(dragForce*(mousePos-transform.position));
		}
	}
}
