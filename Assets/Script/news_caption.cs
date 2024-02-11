using System.Collections;
using UnityEngine;

public class news_caption : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;
    public GameObject thirdObject;

    private void Start()
    {
        secondObject.SetActive(false); 
       StartCoroutine(ShowFirstObjectAndDisappear());
        
    }

    IEnumerator ShowFirstObjectAndDisappear()
    {
        firstObject.SetActive(true); // 첫 번째 오브젝트를 활성화하여 나타나게 합니다.
        yield return new WaitForSeconds(4f); // 4초 동안 대기

        firstObject.SetActive(false);
        secondObject.SetActive(true);// 첫 번째 오브젝트를 비활성화하여 사라지게 합니다.
    }

    IEnumerator ShowSecondObjectAfterDelay()
    {
        yield return new WaitForSeconds(4f); // 4초 지연

        secondObject.SetActive(true); // 두 번째 오브젝트를 활성화하여 나타나게 합니다.
        secondObject.SetActive(false);
        thirdObject.SetActive(true);
    }
}