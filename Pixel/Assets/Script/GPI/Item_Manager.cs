using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Item_Manager : MonoBehaviour {

    public ItemList category;
    private GameObject player;
    private Shader base_shader;
    private Shader highlight_shader;
    public AudioClip SoundToPlayWhenPunched;
    AudioSource m_audio;

    void Start ()
    {
        if (!GetComponent<AudioSource>())
        {
            m_audio = gameObject.AddComponent<AudioSource>();
        }

        else
        {
            m_audio = GetComponent<AudioSource>();
        }

        player = GameObject.FindGameObjectWithTag("Player");
        base_shader = Shader.Find("Standard");
        highlight_shader = Shader.Find("Outlined/Silhouetted Diffuse");
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 5)
        {
            if (gameObject.GetComponent<Renderer>())
            {
                gameObject.GetComponent<Renderer>().material.shader = highlight_shader;
            }

        }

        else
        {
            if (gameObject.GetComponent<Renderer>())
            {
                gameObject.transform.gameObject.GetComponent<Renderer>().material.shader = base_shader;
            }
        }

        //RaycastHit hit;
        //Vector3 rayDirection = player.transform.position - transform.position;
        //if (Physics.Raycast(transform.position, rayDirection, out hit))
        //{
        //    if (hit.transform.tag == "player")
        //    {
        //        Debug.Log("Seen");
        //    }

        //    else
        //    {
        //        Debug.Log("Unseen");
        //    }
        //}

        //if (gameObject.transform.parent != null || gameObject.tag != "Debris")
        //{
        //    gameObject.transform.position = gameObject.transform.parent.position;
        //    gameObject.transform.gameObject.GetComponent<Renderer>().material.shader = base_shader;
        //}
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Item" || hit.transform.gameObject.tag == "Debris")
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 2f && player.GetComponent<Smash>().breaking)
                {
                    Invoke("PushPunch", 0f);
                }
            }
        }
    }

    void PushPunch()
    {
        GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward) * 7.5f, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce((Camera.main.transform.up) * 2f, ForceMode.Impulse);
        if(!m_audio.isPlaying && SoundToPlayWhenPunched != null)
        {
            m_audio.clip = SoundToPlayWhenPunched;
            m_audio.Play();
        }
    }
}
