using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCount : MonoBehaviour
{
    // Start is called before the first frame update
    public static int fire = 0;
    public static bool fireAdd = false;
    public GameObject[] EmptyFires;
    public AudioSource fireSound;

    void Update()
    {
        if (fireAdd)
        {
            fireSound.Play();
            EmptyFires[fire - 1].SetActive(false);
            fireAdd = false;
        }
    }
}
