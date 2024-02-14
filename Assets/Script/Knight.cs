using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;  //������ ź���� ���� ������
    public float attackRate = 2f;  //�����ֱ�
    private Transform target;  //�߻��� ���
    private float timeAfterAttack;  //�ֱ� ���� �������� ���� �ð�

    void Start()
    {
        timeAfterAttack = 0f; //�ֱ� ���� ���� ���� �ð��� 0���� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAttack += Time.deltaTime;
        if (timeAfterAttack >= attackRate) 
        {
            timeAfterAttack = 0f;  //������ �ð� ����
            //bulletPrefab�� �������� transform.position��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
