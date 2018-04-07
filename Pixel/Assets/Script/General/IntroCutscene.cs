using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    public GameObject playerbras;
    public Canvas HUD;
    public Animator introText;

    void Start()
    {
        HUD.enabled = false;
        playerbras.SetActive(false);
    }

    private void KillCamera()
    {
        HUD.enabled = true;
        playerbras.SetActive(true);
        introText.enabled = true;
        Camera.main.targetDisplay = 0;
        Destroy(gameObject);
    }
}
