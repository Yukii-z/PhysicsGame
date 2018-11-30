using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityScript.Lang;

public class StarArrow : MonoBehaviour {
	private static StarArrow instance;
	public static StarArrow Instance
	{
		get
		{
			return instance;
		}
	}

	protected virtual void Awake()
	{
		instance = this;
	}
	
    private List<GameObject> capturedStarList = new List<GameObject>();
	public GameObject[] skyStarList;
	public GameObject linkStar;

	private void Start()
	{
		skyStarList = GameObject.FindGameObjectsWithTag("UniverseStars");
	}

	public void LinkStarUpdate(GameObject newStar)
	{
		capturedStarList.Add(newStar);
		linkStar = newStar;
	}

	public void ShuffleLinkStar()
	{
		int i = Random.Range(0,capturedStarList.Count);
		//原先的star变得不那么亮
		linkStar = capturedStarList[i];
		//新的star变亮
		//起头的星星变亮或者变别的颜色
	}

	public void StarReset()
	{
		int i;
		for (i = 0; i < capturedStarList.Count; i++)
		{
			Destroy(capturedStarList[i]);
		}
		capturedStarList.Clear();
	}
}
