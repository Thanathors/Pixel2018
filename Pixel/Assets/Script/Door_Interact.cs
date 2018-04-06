using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interact : MonoBehaviour {

    private bool Is_open = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(gameObject.transform.position,GameObject.FindGameObjectWithTag("Player").transform.position) < 4 && Is_open == false)
        {
            GetComponent<Animation>().Play();
            Is_open = true;
        }

	}
}
