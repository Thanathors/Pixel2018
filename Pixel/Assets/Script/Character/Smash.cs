using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour {

    Animator m_Anim;

    public float hitRate;
    [ReadOnly]
    public bool breaking;

    [ReadOnly]
    public int mCombo;
    float nextHit;

    void Start ()
    {
        m_Anim = GetComponent<Animator>();
	}

    void Update()
    {
        //BreakCheck();
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && Time.time > nextHit && Time.timeScale == 1)
        {
            if (mCombo == 0)
            {
                nextHit = Time.time + hitRate;
                m_Anim.SetTrigger("Smash");
                mCombo = 1;
            }

            else if(mCombo == 1)
            {
                nextHit = Time.time + hitRate;
                m_Anim.SetTrigger("Slap");
                mCombo = 0;
            }
        }
    }

    void BreakCheck()
    {
        if (m_Anim.GetBool("Smash") == true || m_Anim.GetBool("Slap") == true)
        {
            breaking = true;
        }

        else
        {
            breaking = false;
        }
    }
}
