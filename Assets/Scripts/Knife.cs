using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public AudioClip KnifeAudio;
	public float XSpeed;
	public float YSpeed;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();

		source.clip = KnifeAudio;
		source.pitch = Random.Range(0.8f, 1f);
		
		source.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += new Vector3(XSpeed, YSpeed, 0);
		if(transform.position.x > 12 || transform.position.x < -12 ||
			transform.position.y > 12 || transform.position.y < -12){
			Destroy(gameObject);
		}
	}
}
