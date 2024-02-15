using System.Collections;
using UnityEngine;

public class bgm_fadeout : MonoBehaviour
{
    public float fadeOutDelay = 20.0f; // ���̵� �ƿ��� ���۵Ǵ� ������ �ð�
    public float fadeOutDuration = 5.0f; // ���̵� �ƿ� �ҿ� �ð�
    private AudioSource backgroundMusic;

    void Start()
    {
        // ���� ī�޶� �ִ� AudioSource ������Ʈ ã��
        backgroundMusic = GetComponent<AudioSource>();

        // ������� ���� �۾����� �ڷ�ƾ ����
        StartCoroutine(FadeOutBackgroundMusic());
    }

    // ������� ���� �۾����� �ڷ�ƾ
    IEnumerator FadeOutBackgroundMusic()
    {
        // ���̵� �ƿ� ������ ���
        yield return new WaitForSeconds(fadeOutDelay);

        // �ʱ� ���� �� ����
        float initialVolume = backgroundMusic.volume;

        // ���� �ð�
        float currentTime = 0;

        while (currentTime < fadeOutDuration)
        {
            // �ð� ����
            currentTime += Time.deltaTime;

            // ���� �ð��� ���� ���� ����
            backgroundMusic.volume = Mathf.Lerp(initialVolume, 0, currentTime / fadeOutDuration);

            // �� ������ ��ٸ�
            yield return null;
        }

        // ����� ���߱�
        backgroundMusic.Stop();
    }
}