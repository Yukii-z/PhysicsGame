using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityScript.Lang;

public class RotateWithGravity : MonoBehaviour
{

	public GameObject Earth;
	public float speed=30.0f;
	public float startGrav= 0.02f;
	private Vector3 centrolPos;
	private Vector3 nomVec;
	private Vector3 vertVec;
	private float startDis;

	private Vector3 objPosNoZ;
	// Use this for initialization
	void Start ()
	{
		
		//set up for center
		//centrolPos = VecEarth.transform.position, noAxisZ)
		centrolPos = Earth.transform.position;
		
		//set first position
        objPosNoZ = transform.position;
		startDis = (centrolPos - objPosNoZ).magnitude;
		
		//set first gravity
		nomVec=(centrolPos - objPosNoZ).normalized;
		GetComponent<Rigidbody2D>().AddForce(startGrav * nomVec,ForceMode2D.Impulse);
		//set first speed
		vertVec=Vector3.Cross(nomVec,new Vector3(0,0,-1)).normalized *speed;
		GetComponent<Rigidbody2D>().velocity = vertVec;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		objPosNoZ = transform.position;
		nomVec=(centrolPos - objPosNoZ).normalized;
		GetComponent<Rigidbody2D>().AddForce(startGrav * nomVec * Mathf.Pow(startDis/(centrolPos - objPosNoZ).magnitude,2.0f),ForceMode2D.Impulse);
	}
}
