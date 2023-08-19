using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource slimeattacksound;
    public AudioSource slimediesound;

    [Header("#BGM")]    //bgm
    public AudioClip[] bgmClip;
    public float bgmVolume;
    public int bgmChannels;     //한번에 실행되는 bgm 최대 개수
    public AudioSource[] bgmPlayers;
    int bgmChannelIndex;        //현재 실행중인 bgm 개수

    [Header("#SFX")]    //효과음
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int sfxChannels;     //한번에 실행되는 효과음 최대 개수
    public AudioSource[] sfxPlayers;
    int sfxChannelIndex;        //현재 실행중인 효과음 개수
    
    public enum SFX
    {
        뉴스, 집_에러, 걷는소리, 후크공격, 거짓말쟁이나무_틀렸을때
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance =this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Init();
    }

    //사운드 초기화 함수
    void Init()
    {
        //bgm 초기화
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayers = new AudioSource[bgmChannels];

        for(int index = 0; index < bgmPlayers.Length; index++)
        {
            bgmPlayers[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayers[index].playOnAwake = false;
            bgmPlayers[index].loop = true;
            bgmPlayers[index].volume = bgmVolume;
        }

        //sfx 초기화
        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[sfxChannels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    //sfx 재생 함수
    public void playSFX(SFX sfx, bool loop)
    {
        for(int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + sfxChannelIndex) % sfxPlayers.Length;
            if (sfxPlayers[loopIndex].isPlaying)
                continue;
            sfxChannelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopIndex].loop = loop;
            sfxPlayers[loopIndex].Play();
            break;
        }
    }


    //sfx audio source를 반환하는 함수
    public AudioSource getSFXPlayer(SFX sfx)
    {
        return sfxPlayers[(int)sfx];
    }
}
