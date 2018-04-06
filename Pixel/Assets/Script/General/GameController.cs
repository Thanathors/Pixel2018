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

    public float timer = 10f;
    private float ini_timer;
    private Image timer_Img;
    public static int animal_count;
    public static int wallet_count;
    public static int cloth_count;
    public static int trivia_count;
    public static int key_count;
    private Text animal_text;
    private Text wallet_text;
    private Text cloth_text;
    private Text trivia_text;
    private Text key_text;

    private void Awake()
    {
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
        timer -= Time.deltaTime;
        timer_Img.fillAmount = timer / ini_timer;

        animal_text.text = "Animal:" + animal_count.ToString();
        wallet_text.text = "Wallet:" + wallet_count.ToString();
        cloth_text.text = "Cloth:" + cloth_count.ToString();
        key_text.text = "Key:" + key_count.ToString();
        trivia_text.text = "Trivia:" + trivia_count.ToString();

        if(timer <= 0)
        {
            //GameOverScreen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
