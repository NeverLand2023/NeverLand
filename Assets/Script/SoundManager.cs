using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource slimeattacksound;
    public AudioSource slimediesound;
    public AudioSource bossSlimeAttackSound;
    public AudioSource bossSlimeDeadSound;

    [Header("#BGM")]    //bgm
    public AudioClip[] bgmClip;
    public float bgmVolume;
    public AudioSource bgmPlayer;

    [Header("#SFX")]    //효과음
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int sfxChannels;     //한번에 실행되는 효과음 최대 개수
    public AudioSource[] sfxPlayers;
    int sfxChannelIndex;        //현재 실행중인 효과음 개수

    public enum BGM
    {
        집, 강가물소리
    }
    public enum SFX
    {
        뉴스, 집_에러, 걷는소리, 후크공격, 거짓말쟁이나무_틀렸을때, 보물상자, 종이_펼치기
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
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

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

    //bgm 재생 함수
    public void playBGM(BGM bgm)
    {
        bgmPlayer.clip = bgmClip[(int)bgm];
        bgmPlayer.Play();
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
