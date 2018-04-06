using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal_AI : MonoBehaviour {

    private int waypoint = 0;
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
                GetComponent<NavMeshAgent>().destination = Destinations[waypoint].position;
                GetComponent<NavMeshAgent>().isStopped = false;

                if (Vector3.Distance(gameObject.transform.position, Destinations[waypoint].position) < 2)
                {
                    waypoint++;
                }
                if (waypoint >= Destinations.Count)
                {
                    waypoint = 0;
                }
            }
            else
            {
                GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
        else
        {
            Debug.Log("No destination set");
        }
	}
}
