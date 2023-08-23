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
    public Transform player;

    void Update()
    {
        if (fireAdd)
        {
            fireSound.Play();
            EmptyFires[fire - 1].SetActive(false);
            fireAdd = false;
        }
        if (player.position.y > 95)
        {
            this.gameObject.SetActive(false);
            fire = 0;
        }
    }
}
