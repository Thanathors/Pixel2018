﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    GameObject item;
    Animator m_Anim;
    [HideInInspector]
    public bool animated = false;
    private GameObject dir;
    [Range(0, 30)]
    public float ThrowForce;

    void Start ()
    {
        dir = GameObject.Find("ThrowDirection");
        m_Anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && animated == false && GetComponent<Item_Pick_Drop>().hand_Used)
        {
            animated = true;
            m_Anim.SetTrigger("Throwing");
        }
	}
    
    public void Trower()
    {
        if (gameObject.transform.GetChild(0).GetChild(0).childCount != 0)
        {
            item = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.gameObject.transform.parent = null;
            item.GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward) * ThrowForce, ForceMode.Impulse);
            item.GetComponent<Item_Manager>().IsThrown = true;
        }
        animated = false;
    }
}
