using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public GameObject player;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < 120.0f)
        {
            SoundManager.instance.playBGM(SoundManager.BGM.강가물소리);
        }
    }
}
