using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnObject : MonoBehaviour {

    public AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject)
        {
            sound.Play();
        }
    }
}
 