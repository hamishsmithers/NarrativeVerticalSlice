using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	private GameObject Cam;
	private Vector3 _originalPos;

	public float duration;
	public float amount;


	// Use this for initialization
	void Start () {
		Cam = this.gameObject;
		_originalPos = this.transform.localPosition;
		Shake (duration);
	}
		

	public void Shake (float duration) {
		_originalPos = this.transform.localPosition;
		this.StopAllCoroutines();
		this.StartCoroutine(cShake(duration));
	}
	public IEnumerator cShake (float duration) {
		float endTime = Time.time + duration;
		while (Time.time < endTime) {
			Cam.transform.localPosition = _originalPos + Random.insideUnitSphere * amount;
			duration -= Time.deltaTime;
			yield return null;
		}
		Cam.transform.localPosition = _originalPos;
	}
}
