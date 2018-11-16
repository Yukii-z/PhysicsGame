using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ShootBullet : MonoBehaviour
{
	public GameObject center;
	public GameObject bulletPrefab;
	private Vector3 mousePos;
	public float bulletSpeed=0.05f;
	private Vector3 bulletVelo;
	public float bulletZ=-2f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			//set velocity
			mousePos = Input.mousePosition;
			//Debug.Log(mousePos);
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			//Debug.Log(mousePos);
			mousePos= new Vector3(mousePos.x,mousePos.y,center.transform.position.z);
			bulletVelo=(mousePos - center.transform.position) *bulletSpeed;
			
			GameObject temp = GameObject.Instantiate(bulletPrefab,center.transform.position,
				center.transform.rotation, center.transform);
			temp.GetComponent<Rigidbody2D>().velocity = bulletVelo;
		}
	}

}
