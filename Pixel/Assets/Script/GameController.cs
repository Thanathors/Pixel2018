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

        if(timer <= 0)
        {
            //GameOverScreen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
