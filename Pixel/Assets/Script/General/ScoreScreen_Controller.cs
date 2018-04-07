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
    private int totalScore;
    public AudioSource scoreScreenSongs;


    private void Start()
    {
        scoreScreenSongs = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Main_Menu_Controller.achievements != null)
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

        if (GameController.broken_item_count < 9)
        {
            score += 1;
        }
        else if (GameController.broken_item_count >= 9 && GameController.broken_item_count < 18)
        {
            score += 2;
        }
        else if (GameController.broken_item_count >= 18 && GameController.broken_item_count < 27)
        {
            score += 3;
        }
        else if (GameController.broken_item_count >= 27 && GameController.broken_item_count < 36)
        {
            score += 4;
        }
        else if (GameController.broken_item_count >= 36 && GameController.broken_item_count < 45)
        {
            score += 5;
        }
        else if (GameController.broken_item_count >= 45 && GameController.broken_item_count < 54)
        {
            score += 6;
        }
        else if (GameController.broken_item_count >= 54 && GameController.broken_item_count > 54)
        {
            score += 7;
        }

        totalScore += GameController.key_count * 3;
        totalScore += GameController.animal_count * 13;
        totalScore += GameController.cloth_count * 12;
        totalScore += GameController.wallet_count * 2;
        totalScore += GameController.trivia_count * 1;
        Debug.Log(totalScore);

        int value = totalScore;


        if (value < 35)
        {
            score += 1;
        }
        else if (value >= 35 && value < 70)
        {
            score += 2;
        }
        else if (value >= 70 && value < 105)
        {
            score += 3;
        }
        else if (value >= 105 && value < 140)
        {
            score += 4;
        }
        else if (value >= 175 && value < 210)
        {
            score += 5;
        }
        else if (value >= 210 && value < 245)
        {
            score += 6;
        }
        else if (value >= 280 && value > 280)
        {
            score += 7;
        }

        if (score < 4)
        {
            scoreScreenSongs.Play();
        }
        else if (score >= 4 && score < 7)
        {
            scoreScreenSongs.Play();
        }
        else if (score >= 7 && score < 14)
        {
            scoreScreenSongs.Play();
        }
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

        


        if (score < 2)
        {
            stormRank.text = "Baby Storm";
            //Baby Storm
        }
        else if(score >=2 && score < 3)
        {
            stormRank.text = "Meh Storm";
            //Storm Out
        }
        else if (score >= 3 && score < 4)
        {
            stormRank.text = "Okay Storm";
            //Okay Storm
        }
        else if (score >= 4 && score < 5)
        {
            stormRank.text = "Good Storm";
            //Good Storm
        }
        else if (score >= 5 && score < 6)
        {
            stormRank.text = "Epic Storm";
            //Epic Storm
        }
        else if(score >= 6 && score < 7)
        {
            stormRank.text = "Perfect Storm";
            //Perfect Storm
        }
        else if (score == 14)
        {
            stormRank.text = "Darude Sandstorm";
            //Perfect Storm
        }
    }

    public void HintVisible(int i)
    {
        string title = "";
        string text = "";
        hint.SetActive(true);

        if (i == 0)
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
        if (i == 8)
        {
            title = "Eaten Alive!";
            text = "Feed your cat with something special.";
        }
        if (i == 9)
        {
            title = "Take This!";
            text = "Break a lot of thing in the house.";
        }
        if (i == 10)
        {
            title = "Hidden";
            text = "It's well hidden in the game... Can you find it?";
        }
        if (i == 11)
        {
            title = "Hidden";
            text = "It's well hidden in the game... Can you find it?";
        }
        if (i == 12)
        {
            title = "In fire!";
            text = "It's well hidden in the game... Can you find it?";
        }
        if (i == 13)
        {
            title = "Hidden";
            text = "It's well hidden in the game... Can you find it?";
        }
        if (i == 14)
        {
            title = "Hidden";
            text = "It's well hidden in the game... Can you find it?";
        }
        if (i == 15)
        {
            title = "Hidden";
            text = "It's well hidden in the game... Can you find it?";
        }


        hint.transform.GetChild(0).GetComponent<Text>().text = title;
        hint.transform.GetChild(1).GetComponent<Text>().text = text;
    }
}
