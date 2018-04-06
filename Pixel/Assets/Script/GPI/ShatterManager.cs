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

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Item")
            {
                Debug.Log("Bitch");
                if (Vector3.Distance(transform.position, player.transform.position) < 2f && player.GetComponent<Smash>().breaking)
                {
                    isBreakable = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            isBreakable = true;
            GameController.broken_item_count++;
            GameController.total_count++;
        }
    }
}
