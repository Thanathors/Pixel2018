using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement_Sound : MonoBehaviour {

    public AudioSource achievement;

	
	// Update is called once per frame
	void Start () {
        achievement = GetComponent< AudioSource> ();
	}

    public void OnEnable()
    {
        achievement.Play ();
    }
}
