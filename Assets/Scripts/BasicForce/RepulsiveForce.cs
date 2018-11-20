using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsiveForce : MonoBehaviour
{
	public float yMin;
	public float yMax;
	public float xMin;
	public float xMax;
	public float forceStrength;
	private float yCenter;
	private float xCenter;
	private Vector3 centerPos;
	private Vector3 itemPos;
	private Vector3 nomVec;
	private float xWide;
	private float yWide;
	private float dis;
	public float forceLimit;

	// Use this for initialization
	void Start ()
	{
		xCenter = (xMin + xMax) / 2.0f;
		yCenter = (yMin + yMax) / 2.0f;
		centerPos = new Vector3(xCenter,yCenter,0.0f);
		xWide = xMax - xMin;
		yWide = yMax - yMin;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < yMin || transform.position.y > yMax)
		{
			dis = Mathf.Min(Mathf.Abs(yMin - transform.position.y), Mathf.Abs(transform.position.y - yMax));
			if (dis < forceLimit)
			{
				itemPos = new Vector3(transform.position.x, transform.position.y, 0.0f);
				nomVec = new Vector3(0.0f, (centerPos - itemPos).y / Mathf.Abs((centerPos - itemPos).y), 0.0f);
				GetComponent<Rigidbody2D>()
					.AddForce(forceStrength * nomVec * Mathf.Pow((2.0f * dis) / yWide, 2.0f),
						ForceMode2D.Impulse);
			}
		}
		if (transform.position.x < xMin || transform.position.x > xMax)
		{
			dis = Mathf.Min(Mathf.Abs(xMin - transform.position.x), Mathf.Abs(transform.position.x - xMax));
			if (dis < forceLimit)
			{
				itemPos = new Vector3(transform.position.x, transform.position.y, 0.0f);
				nomVec = new Vector3((centerPos - itemPos).x / Mathf.Abs((centerPos - itemPos).x), 0.0f, 0.0f);
				GetComponent<Rigidbody2D>()
					.AddForce(forceStrength * nomVec * Mathf.Pow((2.0f * dis) / xWide, 2.0f),
						ForceMode2D.Impulse);
			}
		}
	}
}
