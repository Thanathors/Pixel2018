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
                GameController.cloth_count++;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Key)
            {
                GameController.key_count++;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Wallet)
            {
                GameController.wallet_count++;
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Trivia)
            {
                GameController.trivia_count++;
                if (other.gameObject.name.Substring(0,5) == "Chess")
                {
                    GameController.chess_count++;
                    
                }

                if (other.gameObject.name.Substring(0, 5) == "Cadre")
                {
                    GameController.painting_fallen++;

                }
            }
            if (other.gameObject.GetComponent<Item_Manager>().category == ItemList.Animal)
            {
                GameController.animal_count++;
                if(other.name == "Fish")
                {
                    GameController.fish_count++;
                    Debug.Log(GameController.fish_count);
                }
                else
                {
                    GameController.cat_count++;
                }
            }
            GameController.total_count++;
            other.gameObject.SetActive(false);
        }
    }
}
