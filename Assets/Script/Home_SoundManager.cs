using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_SoundManager : MonoBehaviour
{
    public static Home_SoundManager instance;
    public AudioSource homeBGM;
    public AudioSource newsSound;
    public AudioSource errorSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
}
