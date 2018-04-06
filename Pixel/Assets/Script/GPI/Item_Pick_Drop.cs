using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pick_Drop : MonoBehaviour {

    private bool hand_Used = false;
    private Shader base_shader;
    private Shader highlight_shader;
    private GameObject[] item_List;

    private void Start()
    {
        base_shader = Shader.Find("Standard");
        highlight_shader = Shader.Find("Outlined/Silhouetted Diffuse");
        
    }

// Update is called once per frame
    void Update () {
        item_List = GameObject.FindGameObjectsWithTag("Item");

        foreach (var item in item_List)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && hand_Used == true)
            {
                item.transform.parent = null;
                Invoke("Unused_hand", 0.2f);
            }

            if (Vector3.Distance(gameObject.transform.position,item.transform.position) <8)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Item")
                    {
                        hit.collider.gameObject.GetComponent<Renderer>().material.shader = highlight_shader;
                        if (Input.GetKeyDown(KeyCode.Mouse1) && hand_Used == false)
                        {
                            item.transform.parent = gameObject.transform.GetChild(0).GetChild(0).transform;
                            item.transform.localRotation = new Quaternion(0, 0, 0, 0);
                            item.GetComponent<Rigidbody>().isKinematic = true;
                            hand_Used = true;
                        }
                    }
                    else
                    {
                        item.gameObject.GetComponent<Renderer>().material.shader = base_shader;
                    }
                }
            }

            if (item.transform.parent == null)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
        }   
    }

    void Unused_hand()
    {
        hand_Used = false;
    }
}
