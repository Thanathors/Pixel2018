using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour {

    public ItemList category;
    private GameObject player;
    private Shader base_shader;
    private Shader highlight_shader;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        base_shader = Shader.Find("Standard");
        highlight_shader = Shader.Find("Outlined/Silhouetted Diffuse");
    }
	
	// Update is called once per frame
	void Update () {

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
}
