using System.Collections;
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
    public float timer = 60f;
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
    private Text animal_text;
    private Text wallet_text;
    private Text cloth_text;
    private Text trivia_text;
    private Text key_text;
    private Text broken_text;
    private Text timer_text;
    private Text time_minus;
    private float time_slower = 1f;
    private GameObject item_panel;
    private GameObject pop_up_Achievement;
    

    private void Awake()
    {
        total_count = 0;
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
        pop_up_Achievement = GameObject.Find("Pop_up_Achievement");
        item_panel = GameObject.Find("Items_UI");
        item_panel.SetActive(false);
        pop_up_Achievement.SetActive(false);

#if UNITY_EDITOR
        item_panel.SetActive(true);
        animal_text = GameObject.Find("Animal_Counter").GetComponent<Text>();
        wallet_text = GameObject.Find("Wallet_Counter").GetComponent<Text>();
        cloth_text = GameObject.Find("Cloth_Counter").GetComponent<Text>();
        key_text = GameObject.Find("Key_Counter").GetComponent<Text>();
        trivia_text = GameObject.Find("Trivia_Counter").GetComponent<Text>();
        broken_text = GameObject.Find("Broken_Counter").GetComponent<Text>();
#endif
        timer_text = GameObject.Find("timer_txt").GetComponent<Text>();
        time_minus = GameObject.Find("time_minus").GetComponent<Text>();
        momentum_Img = GameObject.Find("Momentum_Counter").GetComponent<Image>();
        momentum_Img.fillAmount = 0.5f;



    }


    void Update () {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        timer_text.text = "Time left :" + Mathf.Round(timer).ToString();
        momentum_Img.color = new Color((-(momentum_Img.fillAmount) + 1), momentum_Img.fillAmount, 0);
        if(momentum_Img.fillAmount == 0 && timer > 0)
        {
            time_minus.text = "-5";
            time_minus.color = new Color(1, 0, 0);
            timer -= .07f;
        }
        else if (momentum_Img.fillAmount > 0)
        {
            time_minus.text = "-1";
            time_minus.color = new Color(0, 1, 0);
            time_slower = 0;
        }
        // Update is called once per frame
#if UNITY_EDITOR
        animal_text.text = "Animal:" + animal_count.ToString();
        wallet_text.text = "Wallet:" + wallet_count.ToString();
        cloth_text.text = "Cloth:" + cloth_count.ToString();
        key_text.text = "Key:" + key_count.ToString();
        trivia_text.text = "Trivia:" + trivia_count.ToString();
        broken_text.text = "Broken:" + broken_item_count.ToString();
#endif

        if(timer <= 0 || endState == true)
        {
            if(endState == true)
            {
                Invoke("Score", 3f);

            }
            if (timer <= 0)
            {
                total_count = -1;
                Invoke("Score", 2f);
            }
        }

        if (broken_item_count == 20)
        {
            pop_up_Achievement.SetActive(true);
            /*award = "Take this!";
            Award_Des_txt.text = "Break a lot of thing in the house";*/
        }
    }

    void Score()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
