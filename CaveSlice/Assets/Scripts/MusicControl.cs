using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

	public AudioSource audioSource;
	public AudioLowPassFilter audioFilter;
	[Range(0f,1f)]
	public float baseVolume;
	[Range(0f,1f)]
	public float maxVolume;
	[Range(0f,10000f)]
	public float baseFilter;
	[Range(0f,10000f)]
	public float maxFilter;

	[Range(1f,100f)]
	public float open;

	public float growth;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioFilter = GetComponent<AudioLowPassFilter> ();

		open = 0;
	}
	
	// Update is called once per frame
	void Update () {
		audioSource.volume = (maxVolume / 100) * open + baseVolume;
		audioFilter.cutoffFrequency = (maxFilter / 100) * open + baseFilter;
	}

	void FixedUpdate(){
		open += growth;
	}
}
