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
    public int bgmChannels;     //�ѹ��� ����Ǵ� bgm �ִ� ����
    public AudioSource[] bgmPlayers;
    int bgmChannelIndex;        //���� �������� bgm ����

    [Header("#SFX")]    //ȿ����
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int sfxChannels;     //�ѹ��� ����Ǵ� ȿ���� �ִ� ����
    public AudioSource[] sfxPlayers;
    int sfxChannelIndex;        //���� �������� ȿ���� ����
    
    public enum SFX
    {
        ����, ��_����, �ȴ¼Ҹ�, ��ũ����, ���������̳���_Ʋ������
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

    //���� �ʱ�ȭ �Լ�
    void Init()
    {
        //bgm �ʱ�ȭ
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

        //sfx �ʱ�ȭ
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

    //sfx ��� �Լ�
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


    //sfx audio source�� ��ȯ�ϴ� �Լ�
    public AudioSource getSFXPlayer(SFX sfx)
    {
        return sfxPlayers[(int)sfx];
    }
}
