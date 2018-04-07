using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour {

    public GameObject playerbras;
    public GameObject cam;
    public GameObject HUD;

    // Use this for initialization
    void Start()
    {
        playerbras.gameObject.SetActive(false);
        HUD.gameObject.SetActive(false);
    }

    private void KillCamera()
    {
        Destroy(cam);
        playerbras.gameObject.SetActive(true);
        HUD.gameObject.SetActive(true);
    }
}
