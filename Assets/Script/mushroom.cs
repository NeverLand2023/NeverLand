using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class mushroom : MonoBehaviour
{
    public float lightRangeIncrease = 3f;
    public float lightOnDuration = 30f;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Return))
        {
            // �÷��̾ ��ó�� �ְ� ���� Ű�� ������ ����Ʈ�� �մϴ�.
            TurnOnLights();

            // ����Ʈ�� �� ��, ������ �ð��� ������ ����Ʈ�� �ٽ� ���ϴ�.
            Invoke("TurnOffLights", lightOnDuration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹 �� �÷��̾� ��ó�� �ִٰ� ǥ���մϴ�.
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹�� ������ �÷��̾� ��ó���� ��� ������ ǥ���մϴ�.
            playerNearby = false;
        }
    }

    private void TurnOnLights()
    {
        // ��ü �������� �ֺ��� �ִ� ��� ���� ������Ʈ�� ã���ϴ�.
        Light[] lights = FindObjectsOfType<Light>();

        // �� ���� ������Ʈ�� ������ ������ŵ�ϴ�.
        foreach (Light light in lights)
        {
            light.range += lightRangeIncrease;
        }
    }

    private void TurnOffLights()
    {
        // ��ü �������� �ֺ��� �ִ� ��� ���� ������Ʈ�� ã���ϴ�.
        Light[] lights = FindObjectsOfType<Light>();

        // �� ���� ������Ʈ�� ������ ������� ������ŵ�ϴ�.
        foreach (Light light in lights)
        {
            light.range -= lightRangeIncrease;
        }
    }
}