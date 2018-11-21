using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveItem : MonoBehaviour
{
	private Vector3 mousePos;
	public float dragForce = 5.0f;
	public Material lineMat;
	public GameObject startLineObj;
	private Vector3 startLinePos;
	private LineRenderer line;
	public Vector3 startPenPos;
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
			GetComponent<Rigidbody2D>().AddForce(dragForce*(mousePos-transform.position));
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
