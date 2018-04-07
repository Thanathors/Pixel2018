using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pick_Drop : MonoBehaviour {

    [HideInInspector]
    public bool hand_Used = false;
    Animator m_Anim;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Item")
            {
                if (Vector3.Distance(gameObject.transform.position, hit.transform.position) < 5)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1) && hand_Used == false)
                    {
                        hit.transform.parent = gameObject.transform.GetChild(0).GetChild(0).transform;
                        hit.transform.localRotation = new Quaternion(0, 0, 0, 0);
                        hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        Invoke("Unused_hand", 0.1f);
                    }
                }
            }
        }

        if(gameObject.transform.GetChild(0).GetChild(0).childCount == 0)
        {
            hand_Used = false;
        }


        if (Input.GetKeyDown(KeyCode.Mouse1) && hand_Used == true)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false; 
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).transform.parent = null;
            hand_Used = false;
        }

        m_Anim.SetBool("Holding", hand_Used);
    }
    void Unused_hand()
    {
        hand_Used = true;
    }
}
