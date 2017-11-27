using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duga : MonoBehaviour {

	public AudioClip DugaAudio;
	public bool IsLeft;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();

		source.clip = DugaAudio;
		source.pitch = Random.Range(0.76f, 0.91f);
		
		source.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.GetComponent<Rigidbody2D>().rotation += 0.7f * (IsLeft ? 1:-1);
		if(gameObject.transform.position.y < -10){
			Destroy(gameObject);
		}
	}
}
