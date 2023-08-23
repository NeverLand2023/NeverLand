using System.Collections;
using UnityEngine;

public class news_caption : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;

    private void Start()
    {
        secondObject.SetActive(false); 
       StartCoroutine(ShowFirstObjectAndDisappear());
        
    }

    IEnumerator ShowFirstObjectAndDisappear()
    {
        firstObject.SetActive(true); // ù ��° ������Ʈ�� Ȱ��ȭ�Ͽ� ��Ÿ���� �մϴ�.
        yield return new WaitForSeconds(4f); // 4�� ���� ���

        firstObject.SetActive(false);
        secondObject.SetActive(true);// ù ��° ������Ʈ�� ��Ȱ��ȭ�Ͽ� ������� �մϴ�.
    }

    /*IEnumerator ShowSecondObjectAfterDelay()
    {
        yield return new WaitForSeconds(4f); // 4�� ����

        secondObject.SetActive(true); // �� ��° ������Ʈ�� Ȱ��ȭ�Ͽ� ��Ÿ���� �մϴ�.
    }*/
}