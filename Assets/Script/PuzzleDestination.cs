using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class PuzzleDestination : MonoBehaviour
{
    public GameObject CompletedPuzzle;
    public GameObject NextPuzzle;
    public GameObject NextDest;

    public GameObject activationObject;
    public Transform newPlayerPosition;
    private GameObject player; // 플레이어를 저장할 변수

    public bool final;

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

            CompletedPuzzle.SetActive(false);

            // 특정 게임오브젝트를 2초간 활성화하고 비활성화
            StartCoroutine(ActivateAndDeactivate(activationObject, 1f));
        }
    }


    IEnumerator ActivateAndDeactivate(GameObject obj, float duration)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(duration);

        obj.SetActive(false);
        NextPuzzle.SetActive(true);

        // 플레이어의 위치를 새로운 위치로 이동
        MovePlayerToNewPosition(player, newPlayerPosition.position);

        if (!final)
        {
            NextDest.SetActive(true);
            gameObject.SetActive(false);
        }
        else {
            //퍼즐끝 퍼즐 비활성화
        }
        
    }

    void MovePlayerToNewPosition(GameObject player, Vector3 newPosition)
    {
        player.transform.position = newPosition;
    }
}