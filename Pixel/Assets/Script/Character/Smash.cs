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

    bool isEnabled;

    float timer;

    void Start ()
    {
        m_Anim = GetComponent<Animator>();
	}

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && Time.time > nextHit && Time.timeScale == 1 && !GetComponent<Item_Pick_Drop>().hand_Used && !GetComponent<Throw>().animated)
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

        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Slapping") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Smashing")) 
        {
            breaking = true;
        }

        else
        {
            breaking = false;
        }
    }
}
