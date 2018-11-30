using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedStar : MonoBehaviour
{
    private LineRenderer line;
    public Vector3 startStarPos = new Vector3(0f,0f,0f);
    public Vector3 endStarPos;
    private Vector3 realTimePos;
    private float realTimeRatio=0f;
    private float lineDrawSpeed=0.2f;
    private bool starDrawing;
    
    
    private void Start()
    {
        if (GameSet.Instance.gameSituation == EGameProcess.PlayGame)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            //只有设置了材质 setColor才有作用
            GameObject starPen = GameObject.FindGameObjectWithTag("Starpen");
            line.material = starPen.GetComponent<StarPointed>().lineMat;
            line.positionCount=2; //设置两点
            line.startColor=Color.white;
            line.endColor=Color.white;//设置直线颜色
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;//设置直线宽度
            /*if (startStarPos != new Vector3(0f,0f,0f))
            {
                starDrawing = true;
            }*/
            starDrawing = true;
        }
    }

    private void Update()
    {
        if (GameSet.Instance.gameSituation == EGameProcess.PlayGame && starDrawing) 
        {
            realTimeRatio = realTimeRatio + lineDrawSpeed * Time.deltaTime;
            realTimePos = realTimeRatio * (endStarPos - startStarPos) + startStarPos;
            line.SetPosition(0, startStarPos);
            line.SetPosition(1, endStarPos);
            if (realTimeRatio > 0.99)
            {
                starDrawing = false;
            }
        }
    }
}
