using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Controller : MonoBehaviour {

    private Canvas main_menu;
    private Canvas achievement_canvas;
    private Canvas credits;
    private string title;
    private string text;
    public static List<bool> achievements;

    // Use this for initialization
    void Start () {

        if (achievements == null)
        {
            achievements = new List<bool>();
            for (int i = 0; i < 16; i++)
            {
                achievements.Add(false);
            }
        }

        main_menu = GetComponent<Canvas>();
        Time.timeScale = 1;
        achievement_canvas = GameObject.Find("Achievement").GetComponent<Canvas>();
        credits = GameObject.Find("Credits").GetComponent<Canvas>();


    }
	
	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(achievement_canvas.enabled == true)
        {
            for (int i = 0; i < achievements.Count; i++)
            {
                if(achievements[i] == true)
                {
                    GameObject.Find("Achievement" + i).transform.GetChild(0).GetComponent<Text>().color = Color.white;
                    GameObject.Find("Achievement" + i).transform.GetChild(1).GetComponent<Text>().color = Color.white;
                }
                if (i == 0)
                {
                    title = "Mona Lisa";
                    text = "Steal every painting in the house.";
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
                if(i == 10)
                {
                    title = "Hidden";
                    text = "It's well hidden in the game... Can you find it?";
                }
                if(i == 11)
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


                GameObject.Find("Achievement" + i).transform.GetChild(0).GetComponent<Text>().text = title;
                GameObject.Find("Achievement" + i).transform.GetChild(1).GetComponent<Text>().text = text;
            }
        }
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenAchievement()
    {
        main_menu.enabled = false;
        achievement_canvas.enabled = true;
    }

    public void OpenCredits()
    {
        credits.enabled = true;
        main_menu.enabled = false;
    }

    public void Back()
    {
        if(achievement_canvas.enabled)
        {
            achievement_canvas.enabled = false;
        }
        else if (credits.enabled)
        {
            credits.enabled = false;
        }
        main_menu.enabled = true;

    }
}
