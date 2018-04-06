﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ItemList
{
    Cloth,
    Animal,
    Key,
    Wallet,
    Trivia
}


public class GameController : MonoBehaviour {

    public static bool endState;
    public float timer = 10f;
    private float ini_timer;
    private Image timer_Img;
    private Image momentum_Img;
    public static int total_count;
    public static int animal_count;
    public static int wallet_count;
    public static int cloth_count;
    public static int trivia_count;
    public static int key_count;
    public static int broken_item_count;
    private int total_count_temp;
    private Text animal_text;
    private Text wallet_text;
    private Text cloth_text;
    private Text trivia_text;
    private Text key_text;
    private Text broken_text;
    private float time_slower = 1f;
    

    private void Awake()
    {
        total_count = 0;
        total_count_temp = total_count;
        endState = false;
        animal_count = 0;
        wallet_count = 0;
        cloth_count = 0;
        trivia_count = 0;
        key_count = 0;
    }

    // Use this for initialization
    void Start () {
        ini_timer = timer;
        animal_text = GameObject.Find("Animal_Counter").GetComponent<Text>();
        wallet_text = GameObject.Find("Wallet_Counter").GetComponent<Text>();
        cloth_text = GameObject.Find("Cloth_Counter").GetComponent<Text>();
        key_text = GameObject.Find("Key_Counter").GetComponent<Text>();
        trivia_text = GameObject.Find("Trivia_Counter").GetComponent<Text>();
        broken_text = GameObject.Find("Broken_Counter").GetComponent<Text>();
        momentum_Img = GameObject.Find("Momentum_Counter").GetComponent<Image>();

        if (GameObject.Find("Timer_Slider"))
        {
            timer_Img = GameObject.Find("Timer_Slider").GetComponent<Image>();
        }
        else
        {
            Debug.Log("There's no canvas in the scene");
        }

	}
	
	// Update is called once per frame
	void Update () {
        timer -= (Time.deltaTime * time_slower);
        timer_Img.fillAmount = (timer / ini_timer);
        if(momentum_Img.fillAmount < .2f)
        {
            time_slower = 1f;
        }
        else if (momentum_Img.fillAmount >= .2f && momentum_Img.fillAmount >= .5f)
        {
            time_slower = 0.8f;
        }
        else if (momentum_Img.fillAmount >= .5f && momentum_Img.fillAmount >= .8f)
        {
            time_slower = 0.7f;
        }
        else if (momentum_Img.fillAmount >= .8f && momentum_Img.fillAmount == 1f)
        {
            time_slower = 0.6f;
        }
        animal_text.text = "Animal:" + animal_count.ToString();
        wallet_text.text = "Wallet:" + wallet_count.ToString();
        cloth_text.text = "Cloth:" + cloth_count.ToString();
        key_text.text = "Key:" + key_count.ToString();
        trivia_text.text = "Trivia:" + trivia_count.ToString();
        broken_text.text = "Broken:" + broken_item_count.ToString();

        if (total_count != total_count_temp)
        {
            total_count_temp = total_count;
            momentum_Img.fillAmount += .10f;
        }

        if(momentum_Img.fillAmount > 0)
        {
            momentum_Img.fillAmount -= Time.deltaTime / 100;
        }

        if (timer <= 0 || endState == true)
        {
            if(endState == true)
            {
                Invoke("Score", 1f);

            }
            if (timer <= 0)
            {
                total_count = -1;
                Invoke("Score", 2f);
            }
        }
	}

    void Score()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
