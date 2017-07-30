using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class EndGameTrigger : MonoBehaviour {

	private bool hasTriggered=false;

	public GameObject follower;
	public Image panel;
	public GameObject wind;
	public GameObject cave;

	public float timeToEnd;
	private float timer;

	void Update(){
		if (Time.time - timer > timeToEnd && hasTriggered==true) {
			Application.Quit();
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}

	public void OnTriggerEnter(Collider other){
			if (other.tag == "Player" && hasTriggered==false) {
			hasTriggered = true;
			other.GetComponent<PlayerController> ().enabled = false;
			other.GetComponent<FollowCamera> ().enabled = true;
			other.GetComponent<CapsuleCollider> ().enabled = false;
			other.GetComponent<Rigidbody> ().velocity = Vector3.zero;

			follower.GetComponent<Animator> ().SetTrigger ("EndStart");
			panel.GetComponent<Animator> ().SetTrigger ("EndStart");
			wind.GetComponent<AudioSource> ().Play ();
			wind.GetComponent<Animator> ().SetTrigger ("EndStart");
			cave.GetComponent<Animator> ().SetTrigger ("EndStart");

			timer = Time.time;
			}
	}

}
