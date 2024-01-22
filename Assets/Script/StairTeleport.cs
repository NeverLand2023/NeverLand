using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTeleport : MonoBehaviour
{
    public Transform arriveTrans;
    private GameObject Hook;

    private void Start()
    {
        Hook = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 newPosition = arriveTrans.position;
        newPosition.z = Hook.transform.position.z; // Hook�� ���� Z ���� �����ϵ��� ����
        Hook.transform.position = newPosition;
    }
}