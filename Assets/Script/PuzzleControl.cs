using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class PuzzleControl : MonoBehaviour
{
    public GameObject activationObject;
    public Transform newPlayerPosition;
    private GameObject player; // 플레이어를 저장할 변수
    public AudioSource wrongAudioSource;

    private void Start()
    {
        // 플레이어를 할당
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌했을 때
        if (other.CompareTag("Player"))
        {
            wrongAudioSource.Play();
            // 플레이어의 위치를 새로운 위치로 이동
            MovePlayerToNewPosition(player, newPlayerPosition.position);

            // 특정 게임오브젝트를 2초간 활성화하고 비활성화
            StartCoroutine(ActivateAndDeactivate(activationObject, 1f));    
        }
    }


    IEnumerator ActivateAndDeactivate(GameObject obj, float duration)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(duration);

        obj.SetActive(false);

    }

    void MovePlayerToNewPosition(GameObject player, Vector3 newPosition)
    {
        player.transform.position = newPosition;
    }
}