using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class server_machine : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = boom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "machine_bottom")
        {
            audioSource.Play();
        }
    }
}
