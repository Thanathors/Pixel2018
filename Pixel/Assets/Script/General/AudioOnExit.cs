using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnExit : MonoBehaviour {


    public AudioSource sound;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTirggerExit(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            sound.Play();
        }
    }
}
