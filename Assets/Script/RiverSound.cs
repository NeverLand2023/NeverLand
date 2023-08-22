using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSound : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public float volume;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        volume = 3f - distance * 0.1f;
        if (SoundManager.instance.bgmPlayer.clip != null && SoundManager.instance.bgmPlayer.clip.name == "강가물소리")
        {
            //SoundManager.instance.bgmPlayer.volume = 3f - distance * 0.1f;
            SoundManager.instance.bgmPlayer.volume = volume;
            if (SoundManager.instance.bgmPlayer.volume > 0.6f)
                SoundManager.instance.bgmPlayer.volume = 0.6f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            SoundManager.instance.playBGM(SoundManager.BGM.강가물소리);
            SoundManager.instance.bgmPlayer.volume = 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            SoundManager.instance.bgmPlayer.clip = null;
            SoundManager.instance.bgmPlayer.volume = SoundManager.instance.bgmVolume;
        }
    }

}
