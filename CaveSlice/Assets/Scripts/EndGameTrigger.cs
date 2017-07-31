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
	public GameObject camera;
	public GameObject backgroundMusic;
	public GameObject playerHead;

	public float timeToEnd;
	private float timer;

	void FixedUpdate(){
		if (Time.time - timer > timeToEnd && hasTriggered==true) {
			Application.Quit();
			//UnityEditor.EditorApplication.isPlaying = false;
		}

		if (hasTriggered == true) {
			if (playerHead.transform.eulerAngles.x != 0) {
				//playerHead.transform.Rotate (-0.05f, 0, 0);
				playerHead.transform.localRotation = Quaternion.Slerp (playerHead.transform.localRotation, Quaternion.identity, 0.008f); 
			}
		}

	}

	public void OnTriggerEnter(Collider other){
			if (other.tag == "Player" && hasTriggered==false) {
			hasTriggered = true;
			other.GetComponent<PlayerController> ().enabled = false;
			other.GetComponent<FollowCamera> ().enabled = true;
			other.GetComponent<CapsuleCollider> ().enabled = false;
			other.GetComponent<Rigidbody> ().velocity = Vector3.zero;

			camera.GetComponent<Animator> ().SetTrigger ("EndStart");
			follower.GetComponent<Animator> ().SetTrigger ("EndStart");
			panel.GetComponent<Animator> ().SetTrigger ("EndStart");
			wind.GetComponent<AudioSource> ().Play ();
			wind.GetComponent<Animator> ().SetTrigger ("EndStart");
			cave.GetComponent<Animator> ().SetTrigger ("EndStart");

			backgroundMusic.GetComponent<MusicControl> ().growth = -backgroundMusic.GetComponent<MusicControl> ().growth;
			backgroundMusic.GetComponent<MusicControl> ().expGrowth = -backgroundMusic.GetComponent<MusicControl> ().expGrowth;

			timer = Time.time;
			}
	}

}
