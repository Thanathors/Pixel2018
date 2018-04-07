using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterManager : MonoBehaviour {

    public bool isBreakable;
    public GameObject shatteredObject;
    [ReadOnly]
    public float speed;
    AudioSource m_audio;
    public AudioClip SoundToPlayWhenBreaking;
    
    void Start()
    {
        if(!GetComponent<AudioSource>())
        {
            m_audio = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (isBreakable)
        {
            Instantiate(shatteredObject, transform.position, transform.rotation);
            if(!m_audio.isPlaying)
            {
                m_audio.clip = SoundToPlayWhenBreaking;
                m_audio.Play();
            }
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (GetComponent<Rigidbody>())
        {
            speed = GetComponent<Rigidbody>().velocity.magnitude;
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Item" || hit.transform.gameObject.tag == "Debris")
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 2f && player.GetComponent<Smash>().breaking)
                {
                    isBreakable = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Item" || collision.gameObject.tag == "Debris")
        {
            isBreakable = true;
            GameController.broken_item_count++;
        }

        if (speed > 10f)
        {
            isBreakable = true;
            GameController.broken_item_count++;
        }
    }
}
