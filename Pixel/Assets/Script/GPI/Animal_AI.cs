using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal_AI : MonoBehaviour {

    private int waypoint = 0;
    private bool in_air = false;
    public List<Transform> Destinations;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Destinations.Count > 0)
        {
            if (gameObject.transform.parent == null)
            {
                if(in_air == false)
                {
                    Invoke("Delay", 0.4f);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, Destinations[waypoint].position, 3 * Time.deltaTime);
                    transform.LookAt(Destinations[waypoint].position);

                    if (Vector3.Distance(gameObject.transform.position, Destinations[waypoint].position) < 2)
                    {
                        waypoint++;
                    }
                    if (waypoint >= Destinations.Count)
                    {
                        waypoint = 0;
                    }
                }
            }
            else
            {
                in_air = true;
            }
        }
        else
        {
            Debug.Log("No destination set");
        }
	}

    void Delay()
    {
        in_air = true;
    }
}
