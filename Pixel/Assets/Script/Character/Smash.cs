using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour {

    Animator m_Anim;
    [ReadOnly]
    public bool breaking;

	void Start ()
    {
        m_Anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        BreakCheck();
        if (Input.GetKeyUp(KeyCode.Mouse0) && m_Anim.GetBool("Smash") == false)
        {
            m_Anim.SetBool("Smash", true);
        }
	}

    void BreakCheck()
    {
        if (m_Anim.GetBool("Smash") == true)
        {
            breaking = true;
        }

        else
        {
            breaking = false;
        }
    }

    public void SmashToFalse()
    {
        m_Anim.SetBool("Smash", false);
    }
}
