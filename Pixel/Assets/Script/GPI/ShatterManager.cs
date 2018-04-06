using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterManager : MonoBehaviour {

    public bool isBreakable;
    public GameObject shatteredObject;

	void Start ()
    {
		
	}

    void Update()
    {
        if (isBreakable)
        {
            Instantiate(shatteredObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
