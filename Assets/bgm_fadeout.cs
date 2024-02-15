using System.Collections;
using UnityEngine;

public class bgm_fadeout : MonoBehaviour
{
    public float fadeOutDelay = 20.0f; // 페이드 아웃이 시작되는 딜레이 시간
    public float fadeOutDuration = 5.0f; // 페이드 아웃 소요 시간
    private AudioSource backgroundMusic;

    void Start()
    {
        // 메인 카메라에 있는 AudioSource 컴포넌트 찾기
        backgroundMusic = GetComponent<AudioSource>();

        // 배경음이 점점 작아지는 코루틴 시작
        StartCoroutine(FadeOutBackgroundMusic());
    }

    // 배경음이 점점 작아지는 코루틴
    IEnumerator FadeOutBackgroundMusic()
    {
        // 페이드 아웃 시작을 대기
        yield return new WaitForSeconds(fadeOutDelay);

        // 초기 볼륨 값 저장
        float initialVolume = backgroundMusic.volume;

        // 현재 시간
        float currentTime = 0;

        while (currentTime < fadeOutDuration)
        {
            // 시간 증가
            currentTime += Time.deltaTime;

            // 현재 시간에 따라 볼륨 조절
            backgroundMusic.volume = Mathf.Lerp(initialVolume, 0, currentTime / fadeOutDuration);

            // 한 프레임 기다림
            yield return null;
        }

        // 배경음 멈추기
        backgroundMusic.Stop();
    }
}