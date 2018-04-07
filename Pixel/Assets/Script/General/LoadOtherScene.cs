using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOtherScene : MonoBehaviour {

	// Use this for initialization
	public void LoadScene (string name) {
        Application.LoadLevel(name);
	}
	
}
