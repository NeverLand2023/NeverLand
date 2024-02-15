using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redlight_sound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip Redlight;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = Redlight;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
