using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public Text text;

    [ReadOnly]
    public bool isUsed;

    [ReadOnly]
    public bool isEnabled;

    Animator m_Anim;

    void Start ()
    {
        m_Anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        if (isEnabled && Input.GetKeyDown(KeyCode.E) && GetComponent<Renderer>().isVisible)
        {
            isUsed = !isUsed;
        }

        if(m_Anim != false)
        {
		    if(isUsed)
            {
                m_Anim.SetBool("Used", true);
            }

            if (!isUsed)
            {
                m_Anim.SetBool("Used", false);
            }
        }

        if(isUsed)
        {
            text.text = "Press E to close";
        }

        if(!isUsed)
        {
            text.text = "Press E to open";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isEnabled = true;
            if(text != null)
            {
                m_Anim.SetBool("isEnabled", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnabled = false;
            if(text != null)
            {
                m_Anim.SetBool("isEnabled", false);
            }
        }
    }
}
