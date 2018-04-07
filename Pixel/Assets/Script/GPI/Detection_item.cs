using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_item : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Item" && other.gameObject.transform.parent == null)
        {
            if(other.gameObject.GetComponent<Item_Manager>().category == ItemList.Cloth)
            {
                GameController.cloth_count = GameController.cloth_count + 12;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Key)
            {
                GameController.key_count = GameController.key_count + 3;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Wallet)
            {
                GameController.wallet_count = GameController.wallet_count + 2;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Trivia)
            {
                GameController.trivia_count++;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Animal)
            {
                GameController.animal_count = GameController.animal_count + 13;
            }
            GameController.total_count++;
            other.gameObject.SetActive(false);
        }
    }
}
