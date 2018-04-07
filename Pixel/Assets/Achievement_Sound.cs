using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement_Sound : MonoBehaviour {

    AudioSource achievement;
    	
	// Update is called once per frame
	void Awake ()
    {
        achievement = GetComponent<AudioSource>();
	}

    public void OnEnable()
    {
        achievement.Play ();
    }
}
