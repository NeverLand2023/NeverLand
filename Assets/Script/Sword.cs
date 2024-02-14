using UnityEngine;

public class Sword : MonoBehaviour
{
    void Start()
    {
        // 3초 후에 자기 자신을 파괴
        Destroy(gameObject, 3f);
    }
}