using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour {

    public ItemList category;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.parent != null)
        {
            if (gameObject.transform.parent.tag == "Player")
            {
                gameObject.transform.position = gameObject.transform.parent.position;
            }
        }

	}
}
