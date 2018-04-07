using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit_Door : MonoBehaviour
{

private GameObject pop_up;

void Start()
{
    pop_up = GameObject.Find("Pop_up");
    pop_up.SetActive(false);
}

private void OnTriggerStay(Collider other)
{
    if (other.tag == "Player")
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameController.key_count == 0)
            {
                pop_up.SetActive(true);
                pop_up.transform.GetChild(0).GetComponent<Text>().text = "You need your key!";
                Invoke("Pop_up_Disable", 2f);
            }
        }
    }
}

private void Pop_up_Disable()
{
    pop_up.SetActive(false);
}

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.GetComponent<Item_Manager>())
    {
        if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Key)
        {
            GameController.key_count++;
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
}
