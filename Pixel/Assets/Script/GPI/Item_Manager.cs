using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour {

    public ItemList category;
    private GameObject player;
    private Shader base_shader;
    private Shader highlight_shader;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base_shader = Shader.Find("Standard");
        highlight_shader = Shader.Find("Outlined/Silhouetted Diffuse");
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 5)
        {
            gameObject.GetComponent<Renderer>().material.shader = highlight_shader;
        }
        else
        {
            gameObject.transform.gameObject.GetComponent<Renderer>().material.shader = base_shader;
        }

        if (gameObject.transform.parent != null)
        {
            gameObject.transform.position = gameObject.transform.parent.position;
            gameObject.transform.gameObject.GetComponent<Renderer>().material.shader = base_shader;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Item")
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 2f && player.GetComponent<Smash>().breaking)
                {
                    GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward) * 7.5f, ForceMode.Impulse);
                    GetComponent<Rigidbody>().AddForce((Camera.main.transform.up) * 2f, ForceMode.Impulse);
                }
            }
        }
    }
}
