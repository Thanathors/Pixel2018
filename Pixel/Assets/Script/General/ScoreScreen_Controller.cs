using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen_Controller : MonoBehaviour {

    private float timer = 0;
    private string award;
    private Text Award_txt;
    private Text Award_Des_txt;

    private void Start()
    {
        Award_txt = GameObject.Find("Award_text").GetComponent<Text>();
        Award_Des_txt = GameObject.Find("Award_Description").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (GameController.total_count == 1)
        {
            award = "Gotta go fast!";
            Award_Des_txt.text = "Leave the house without picking anything.";
        }
        if (GameController.wallet_count == 1 && GameController.key_count == 1 && GameController.cloth_count == 5)
        {
            award = "Gone for good...";
            Award_Des_txt.text = "Key,wallet and some cloth...";
        }
        if (GameController.animal_count == 1 && GameController.total_count == 2)
        {
            award ="It's my Cat!";
            Award_Des_txt.text = "Leave the house with only your cat.";
        }
        if (GameController.broken_item_count > 10 && GameController.total_count < 10)
        {
            award ="Take this!";
            Award_Des_txt.text = "Break a lot of thing in the house";
        }
        if(GameController.total_count == -1)
        {
            award = "Nobody care anymore...";
            Award_Des_txt.text = "Take to much time to storm-out";
        }
        Award_txt.text = award;

        if (timer > 2)
        {
            SceneManager.LoadScene(0);
        }
    }
}
