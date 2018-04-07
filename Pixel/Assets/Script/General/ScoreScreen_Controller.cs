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
    private Text obj_collected_text;
    private Text obj_destroyed_text;
    private int score = 0;
    private Slider slider;
    private Text stormRank;
    private GameObject hint;

    private void Start()
    {
        if(Main_Menu_Controller.achievements != null)
        {
            for (int i = 0; i < Main_Menu_Controller.achievements.Count; i++)
            {
                if (Main_Menu_Controller.achievements[i] == true)
                {
                    GameObject.Find(i.ToString()).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }
        }
        hint = GameObject.Find("Hint");
        hint.SetActive(false);
        Award_txt = GameObject.Find("Award_text").GetComponent<Text>();
        Award_Des_txt = GameObject.Find("Award_Description").GetComponent<Text>();
        obj_collected_text = GameObject.Find("Object_Collected_text").GetComponent<Text>();
        obj_destroyed_text = GameObject.Find("Object_Destroyed_text").GetComponent<Text>();
        stormRank = GameObject.Find("Rank_text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        obj_collected_text.text = (GameController.total_count).ToString();
        obj_destroyed_text.text = GameController.broken_item_count.ToString();

        if (GameController.endState == 1)
        {
            award = "To The Point";
            Award_Des_txt.text = "Picked up Wallet and left.";
        }
        if(GameController.endState == 2)
        {
            award = "Lost Credibility";
            Award_Des_txt.text = "Took too much time.";
        }
        //script needed
        if (GameController.endState == 3)
        {
            award = "Alternate Exit";
            Award_Des_txt.text = "Exit through a window.";
        }
        Award_txt.text = award;

        if(GameController.broken_item_count < 1)
        {
            score += 1;
        }
        else if (GameController.broken_item_count >= 1 && GameController.broken_item_count < 2)
        {
            score += 2;
        }
        else if (GameController.broken_item_count >= 1 && GameController.broken_item_count < 2)
        {
            score += 3;
        }
        else if (GameController.broken_item_count >= 2 && GameController.broken_item_count < 3)
        {
            score += 4;
        }
        else if (GameController.broken_item_count >= 3 && GameController.broken_item_count < 4)
        {
            score += 5;
        }

        int value = GameController.total_count;

        if (value < 1)
        {
            score += 1;
        }
        else if(value >= 1 && value < 2)
        {
            score += 2;
        }
        else if (value >= 2 && value < 3)
        {
            score += 3;
        }
        else if (value >= 3 && value < 4)
        {
            score += 4;
        }
        else if (value >= 4 && value < 5)
        {
            score += 5;
        }


        if(score < 3)
        {
            stormRank.text = "Baby Storm"; 
            //Baby Storm
        }
        else if(score >=3 && score < 5)
        {
            stormRank.text = "Storm Out";
            //Storm Out
        }
        else if (score >= 5 && score < 7)
        {
            stormRank.text = "Ok Storm";
            //Ok Storm
        }
        else if (score >= 7 && score < 9)
        {
            stormRank.text = "Good Storm";
            //Good Storm
        }
        else if(score ==9)
        {
            stormRank.text = "Epic Storm";
            //Epic Storm
        }else if(score == 10)
        {
            stormRank.text = "Perfect Storm";
            //Perfect Storm
        }

        if (timer > 10)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void HintVisible(int i)
    {
        string title = "";
        string text = "";
        hint.SetActive(true);

        if(i == 0)
        {
            title = "Art Storm";
            text = "Make 6 Paintings Fall.";
        }
        if (i == 1)
        {
            title = "Strategist";
            text = "Bring some Chess pieces with you.";
        }
        if (i == 2)
        {
            title = "Animal Freak";
            text = "Bring the Cat and Fish with you.";
        }
        if (i == 3)
        {
            title = "Lights out";
            text = "Break all the lamps in the house.";
        }
        if (i == 4)
        {
            title = "Table Flipper";
            text = "Flip all the tables.";
        }
        if (i == 5)
        {
            title = "Break the Ice";
            text = "Break all windows in the house.";
        }
        if (i == 6)
        {
            title = "Sushi Time";
            text = "Bring back both fish.";
        }
        if (i == 7)
        {
            title = "Master of Keys";
            text = "Bring back all three keys.";
        }
        if (i == 9)
        {
            title = "Take This!";
            text = "Break a lot of thing in the house.";
        }
        if (i == 12)
        {
            title = "In fire!";
            text = "Have your momentum to it's maximum.";
        }


        hint.transform.GetChild(0).GetComponent<Text>().text = title;
        hint.transform.GetChild(1).GetComponent<Text>().text = text;
    }
}
