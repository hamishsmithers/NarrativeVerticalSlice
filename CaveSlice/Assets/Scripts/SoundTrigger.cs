using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

	public bool timed;
	public float time;
	private float timer;

	public AudioSource audioSource;

	private bool hasTriggered = false;

	void Start(){
		timer = Time.time;
	}

	void Update(){
		if (timed == true) {
			if (Time.time - timer > time && hasTriggered == false) {
				audioSource.Play ();
				hasTriggered = true;
			}
		}

	}


	public void OnTriggerEnter(Collider other){
		if (timed == false) {
			if (other.tag == "Player" && hasTriggered == false) {
				timer = Time.time;
				timed = true;
				//audioSource.Play ();
				//hasTriggered = true;
			}
		}
	}

}
