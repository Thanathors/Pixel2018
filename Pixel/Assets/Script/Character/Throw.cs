using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    GameObject item;
    private bool animated = false;
    private GameObject dir;

	// Use this for initialization
	void Start () {
        dir = GameObject.Find("ThrowDirection");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0) && animated == false)
        {
            animated = true;
            Invoke("Delayer", 0.5f);
        }

	}
    
    void Delayer()
    {
        if (gameObject.transform.GetChild(0).GetChild(0).childCount != 0)
        {
            item = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.gameObject.transform.parent = null;
            item.GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward) * 10, ForceMode.Impulse);
        }
        animated = false;
    }
}
