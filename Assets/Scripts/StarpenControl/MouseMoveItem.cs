using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveItem : MonoBehaviour
{
	//general control parameters of mouse
	private Vector3 mousePos;
	public float dragForce = 5.0f;
	
	//drawLine
	public Material lineMat;
	public GameObject startLineObj;
	public Vector3 startPenPos;                               	
	private Vector3 startLinePos;
	private LineRenderer line;

	//mouse control details
	public float controDis=5.0f;
	public float slowVel;
	public float slowSpeed=0.5f;
	// Use this for initialization
	void Start ()
	{
		startLinePos = startLineObj.transform.position;
		startPenPos = transform.position;
		line = this.gameObject.AddComponent<LineRenderer>();
		//只有设置了材质 setColor才有作用
		line.material = lineMat;
		line.positionCount=2; //设置两点
		line.startColor=Color.yellow;
		line.endColor=Color.yellow;//设置直线颜色
		line.startWidth = 0.1f;
		line.endWidth = 0.1f;//设置直线宽度
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameSet.Instance.gameSituation==EGameProcess.PlayGame)
		{
			//set velocity
			mousePos = Input.mousePosition;
			//Debug.Log(mousePos);
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			if ((mousePos - transform.position).magnitude < controDis)
			{
				Debug.Log("Move");
				GetComponent<Rigidbody2D>().AddForce(dragForce * (mousePos - transform.position));
			}
			else if(GetComponent<Rigidbody2D>().velocity.magnitude!=0.0f)
			{
				slowVel = Mathf.Lerp(GetComponent<Rigidbody2D>().velocity.magnitude, 0.0f, slowSpeed * Time.deltaTime);
				GetComponent<Rigidbody2D>().velocity = slowVel * GetComponent<Rigidbody2D>().velocity.normalized;
			}
		}
	
		DrawLine(startLinePos,transform.position);
	}

	void DrawLine(Vector3 initPosition, Vector3 newPosition)
	{
		//设置指示线的起点和终点
		line.SetPosition(0, initPosition);
		line.SetPosition(1, newPosition);
	}
}
