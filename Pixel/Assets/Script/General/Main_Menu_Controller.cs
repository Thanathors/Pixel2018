using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
