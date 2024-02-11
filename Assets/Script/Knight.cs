using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;  //생성할 탄알의 원본 프리팹
    public float attackRate = 2f;  //공격주기
    private Transform target;  //발사할 대상
    private float timeAfterAttack;  //최근 공격 시점에서 지난 시간

    void Start()
    {
        timeAfterAttack = 0f; //최근 공격 이후 누적 시간을 0으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAttack += Time.deltaTime;
        if (timeAfterAttack >= attackRate) 
        {
            timeAfterAttack = 0f;  //누적된 시간 리셋
            //bulletPrefab의 복제본을 transform.position위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
