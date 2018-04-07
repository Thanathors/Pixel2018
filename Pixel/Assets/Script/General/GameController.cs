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

    public static int endState;
    public float timer = 60f;
    private float ini_timer;
    private Image timer_Img;
    private Image momentum_Img;
    public static int total_count;
    public static int painting_fallen;
    public static int chess_count;
    public static int windows_broken;
    public static int animal_count;
    public static int fish_count;
    public static int cat_count;
    public static int lamp_count;
    public static int wallet_count;
    public static int table_flipped;
    public static int cloth_count;
    public static int trivia_count;
    public static int key_count;
    public static int broken_item_count;
    private int total_temp;
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
    private List<bool> achievements;

    private void Awake()
    {
        achievements = new List<bool>();
        if (Main_Menu_Controller.achievements == null)
        {
            for (int i = 0; i <= 16; i++)
            {
                achievements.Add(false);
            }
        }
        else
        {
            achievements = Main_Menu_Controller.achievements;
        }
        total_count = 0;
        endState = 0;
        animal_count = 0;
        cat_count = 0;
        fish_count = 0;
        windows_broken = 0;
        painting_fallen = 0;                                                                                                                                                                                                                                  
        wallet_count = 0;
        chess_count = 0;
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
        total_temp = total_count + broken_item_count;

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
        momentum_Img.fillAmount = 0.2f;
    }


    void Update () {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
            momentum_Img.fillAmount -= 0.001f;
        }
        AchievementChecker();
        timer_text.text = "Time Left:" + Mathf.Round(timer).ToString();
        momentum_Img.color = new Color((-(momentum_Img.fillAmount) + 1), momentum_Img.fillAmount, 0);

        if(total_temp != (total_count + broken_item_count))
        {
            total_temp = total_count + broken_item_count;
            momentum_Img.fillAmount += 0.10f;
        }

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

        if(endState == 1)
        {
            Invoke("Score", 1f);
        }

        if (timer <= 0)
        {
            endState = 2;
            Invoke("Score", 1f);
        }      
    }

    void Score()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void Achievement_FadeOut()
    {
        pop_up_Achievement.SetActive(false);
    }
    
    void AchievementChecker()
    {

        if (painting_fallen == 6 && achievements[0] == false)
        {
            achievements[0] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Art Storm";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Make 6 Paintings Fall.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (chess_count == 5 && achievements[1] == false)
        {
            achievements[1] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Strategist";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Bring some Chess pieces with you.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (cat_count == 1 && fish_count > 0 && achievements[2] == false)
        {
            achievements[2] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Animal Freak";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Bring the Cat and Fish with you.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (lamp_count == 10 && achievements[3] == false)
        {
            achievements[3] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Lights out";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Break all the lamps in the house.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (table_flipped == 2 && achievements[4] == false)
        {
            achievements[4] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Table Flipper";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Flip all the tables.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (windows_broken == 4 && achievements[5] == false)
        {
            achievements[5] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Breaking Out";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Break all windows in the house.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (fish_count == 2 && achievements[6] == false)
        {
            achievements[6] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Sushi Time";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Bring back both fish.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (key_count == 3 && achievements[7] == false)
        {
            achievements[7] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Master of Keys";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Bring back all three keys.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (broken_item_count == 20 && achievements[9] == false)
        {
            achievements[9] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Rampage!";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Break a lot of thing in the house.";
            Invoke("Achievement_FadeOut", 3f);
        }
        if (momentum_Img.fillAmount == 1 && achievements[12] == false)
        {
            achievements[12] = true;
            pop_up_Achievement.SetActive(true);
            pop_up_Achievement.transform.GetChild(0).GetComponent<Text>().text = "Oh you're angry!";
            pop_up_Achievement.transform.GetChild(1).GetComponent<Text>().text = "Raise Momentum to its maximum.";
            Invoke("Achievement_FadeOut", 3f);
        }
    }
}
