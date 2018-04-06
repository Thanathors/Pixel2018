using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit_Door : MonoBehaviour {

    private GameObject pop_up;

	// Use this for initialization
	void Start () {
        pop_up = GameObject.Find("Pop_up");
        pop_up.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(GameController.key_count == 0)
                {
                    pop_up.SetActive(true);
                    pop_up.transform.GetChild(0).GetComponent<Text>().text = "You need a key!";
                    Invoke("Pop_up_Disable", 2f);
                }
                else
                {
                    GameController.endState = true;
                }
            }
        }
    }

    private void Pop_up_Disable()
    {
        pop_up.SetActive(false);
    }
}
