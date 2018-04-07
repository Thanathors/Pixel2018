using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Controller : MonoBehaviour {

    private Canvas main_menu;
    private Canvas achievement_canvas;
    private Canvas credits;
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
