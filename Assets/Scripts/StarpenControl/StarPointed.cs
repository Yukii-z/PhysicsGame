using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPointed : MonoBehaviour
{
	public Material lineMat;
	private GameObject starPre;
	private RepulsiveForce Area;
	private GameObject copyStars;
	float yMin;
	float yMax;
	float xMin;
	float xMax;

	public float safeDis = 5.0f;
	// Use this for initialization
	void Start ()
	{
		Area = gameObject.GetComponent<RepulsiveForce>();
		yMax = Area.yMax;
		yMin = Area.yMin;
		xMax = Area.xMax;
		xMin = Area.xMin;
		copyStars=GameObject.FindGameObjectWithTag("CopyStars");
	}
	
	public void OnTriggerEnter2D(Collider2D star)
	{
		if (GameSet.Instance.gameSituation == EGameProcess.PlayGame)
		{	
			CopyNewStar(star.gameObject);
			ResetUniverseStar(star.gameObject);
			CreatNewStar();
			Debug.Log("statechange");
		}
	}

	void CopyNewStar(GameObject star)
	{
		GameObject temp=GameObject.Instantiate(star, star.transform.position,star.transform.rotation, copyStars.transform);
        temp.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		temp.GetComponent<Collider2D>().enabled = false;
		RotateWithGravity[] rotScript = temp.GetComponents<RotateWithGravity>();
		for (int i=0; i < rotScript.Length; i++)
		{
			rotScript[i].enabled = false;
		}
		temp.GetComponent<RepulsiveForce>().enabled = false;
		DrawLine(temp);
		ChangeShiningStar(temp);
	}

	void DrawLine(GameObject star)
	{
		star.AddComponent<CapturedStar>();
		Debug.Log("Added");
		if (StarArrow.Instance.linkStar != null)
		{
			star.GetComponent<CapturedStar>().startStarPos = StarArrow.Instance.linkStar.transform.position;
		}
		star.GetComponent<CapturedStar>().endStarPos = star.transform.position;
	}

	void ResetUniverseStar(GameObject uniStar)
	{
		uniStar.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		uniStar.GetComponent<SpriteRenderer>().enabled = false;
		uniStar.GetComponent<Collider2D>().enabled = false;
		RotateWithGravity[] rotScript = uniStar.GetComponents<RotateWithGravity>();
		for (int i=0; i < rotScript.Length; i++)
		{
			rotScript[i].enabled = false;
		}
		uniStar.GetComponent<RepulsiveForce>().enabled = false;
	}
	
	void ChangeShiningStar(GameObject copyStar)
	{
		//StarArrow.Instance.linkStar变暗;
		StarArrow.Instance.LinkStarUpdate(copyStar);
		//tarArrow.Instance.linkStar变亮;
	}

	void CreatNewStar()
	{
		//寻找好的新星星位置
		float x = Random.Range(xMin, xMax);
		float y = Random.Range(yMin, yMax);
		Vector3 tempPos = new Vector3(x, y, -5f);
		while (!DistenceDetect(tempPos))
		{
			x = Random.Range(xMin, xMax);
			y = Random.Range(yMin, yMax);
			tempPos = new Vector3(x, y, -5f);
		}
		//寻找好的新星星本体
		GameObject newStar = FindNewStarObj();
		Debug.Log(newStar);
		//展现star
		newStar.transform.position = tempPos;
		newStar.GetComponent<SpriteRenderer>().enabled = true;
		newStar.GetComponent<Collider2D>().enabled = true;
		RotateWithGravity[] rotScript = newStar.GetComponents<RotateWithGravity>();
		for (int i=0; i < rotScript.Length; i++)
		{
			rotScript[i].enabled = true;
		}
		newStar.GetComponent<RepulsiveForce>().enabled = true;
		//（动画效果切换
		newStar.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		newStar.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.5f,0.5f), Random.Range(-0.5f,0.5f));
	}
	
	bool DistenceDetect (Vector3 aimStarPos)
	{
		bool rightPos=true;
		int i;
		for (i = 0; i < StarArrow.Instance.skyStarList.Length; i++)
		{
			if (StarArrow.Instance.skyStarList[i].GetComponent<SpriteRenderer>().enabled == true && 
			    (StarArrow.Instance.skyStarList[i].transform.position - aimStarPos).magnitude < safeDis)
			{
				rightPos = false;
			}
		}
		return rightPos;
	}

	GameObject FindNewStarObj()
	{
		int i;
		i = Random.Range(0, StarArrow.Instance.skyStarList.Length);
		GameObject star = StarArrow.Instance.skyStarList[i];
		while (StarArrow.Instance.skyStarList[i].GetComponent<SpriteRenderer>().enabled)
		{
			i = Random.Range(0, StarArrow.Instance.skyStarList.Length);
			star = StarArrow.Instance.skyStarList[i];
		}
		return star;
	}
}
