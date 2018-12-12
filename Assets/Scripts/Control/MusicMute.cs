using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMute : MonoBehaviour
{
	private AudioSource audios;
	public bool muteStart;
	// Use this for initialization
	void Start ()
	{
		audios = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (muteStart)
		{
			audios.volume = Mathf.Lerp(audios.volume, 0f, 0.5f * Time.fixedDeltaTime);
			if (audios.volume < 0.01f)
			{
				audios.Stop();
				muteStart = !muteStart;
			}
		}

	}
}
