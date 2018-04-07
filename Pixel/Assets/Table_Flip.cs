using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Flip : MonoBehaviour {


    private bool is_flipped = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(GameController.table_flipped);
        if (is_flipped == false)
        {
            if (gameObject.transform.rotation.x > 0.1f || gameObject.transform.rotation.x < -0.1f)
            {
                GameController.table_flipped++;
                is_flipped = true;
            }
            if (gameObject.transform.rotation.z > 0.1f || gameObject.transform.rotation.z < -0.1f)
            {
                GameController.table_flipped++;
                is_flipped = true;
            }
        }
	}
}
