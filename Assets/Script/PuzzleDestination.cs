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
    private GameObject player; // �÷��̾ ������ ����

    public bool final;

    private void Start()
    {
        // �÷��̾ �Ҵ�
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // �÷��̾�� �浹���� ��
        if (other.CompareTag("Player"))
        {

            CompletedPuzzle.SetActive(false);

            // Ư�� ���ӿ�����Ʈ�� 2�ʰ� Ȱ��ȭ�ϰ� ��Ȱ��ȭ
            StartCoroutine(ActivateAndDeactivate(activationObject, 1f));
        }
    }


    IEnumerator ActivateAndDeactivate(GameObject obj, float duration)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(duration);

        obj.SetActive(false);
        NextPuzzle.SetActive(true);

        // �÷��̾��� ��ġ�� ���ο� ��ġ�� �̵�
        MovePlayerToNewPosition(player, newPlayerPosition.position);

        if (!final)
        {
            NextDest.SetActive(true);
            gameObject.SetActive(false);
        }
        else {
            //���� ���� ��Ȱ��ȭ
        }
        
    }

    void MovePlayerToNewPosition(GameObject player, Vector3 newPosition)
    {
        player.transform.position = newPosition;
    }
}