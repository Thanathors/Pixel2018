﻿using System.Collections;
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

    private void Start()
    {
        Award_txt = GameObject.Find("Award_text").GetComponent<Text>();
        Award_Des_txt = GameObject.Find("Award_Description").GetComponent<Text>();
        obj_collected_text = GameObject.Find("Object_Collected_text").GetComponent<Text>();
        obj_destroyed_text = GameObject.Find("Object_Destroyed_text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        obj_collected_text.text = (GameController.total_count).ToString();
        obj_destroyed_text.text = GameController.broken_item_count.ToString();

        if (GameController.total_count == 1)
        {
            award = "Gotta go fast!";
            Award_Des_txt.text = "Leave the house without picking anything.";
        }
        if(GameController.total_count == -1)
        {
            award = "Nobody care anymore...";
            Award_Des_txt.text = "Take too much time to storm-out.";
        }
        //script needed
        if (GameController.total_count == 10000)
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
            //Baby Storm
        }
        else if(score >=3 && score < 5)
        {
            //Storm Out
        }
        else if (score >= 5 && score < 7)
        {
            //Ok Storm
        }
        else if (score >= 7 && score < 9)
        {
            //Good Storm
        }
        else if(score ==9)
        {
            //Epic Storm
        }else if(score == 10)
        {
            //Perfect Storm
        }

        if (timer > 5)
        {
            SceneManager.LoadScene(0);
        }
    }
}
