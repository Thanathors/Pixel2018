using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {

    public GameObject pausePanel;

    public bool isPaused;

	void Start ()
    {
        isPaused = false;
	}

    void Update()
    {
        if (isPaused)
        {
            PauseGame (true);
        }

        else
        {
            PauseGame(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SwitchPause();
        }
    }

    void PauseGame (bool state)
    {
        if (state)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }

    }

    public void SwitchPause ()
    {
         if (isPaused)
         {
             isPaused = false;
         }

         else
         {
             isPaused = true;
         }
    }
}