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
            // 플레이어가 근처에 있고 엔터 키를 누르면 라이트를 켭니다.
            TurnOnLights();

            // 라이트를 켠 후, 지정된 시간이 지나면 라이트를 다시 끕니다.
            Invoke("TurnOffLights", lightOnDuration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌 시 플레이어 근처에 있다고 표시합니다.
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌이 끝나면 플레이어 근처에서 벗어난 것으로 표시합니다.
            playerNearby = false;
        }
    }

    private void TurnOnLights()
    {
        // 물체 기준으로 주변에 있는 모든 조명 컴포넌트를 찾습니다.
        Light[] lights = FindObjectsOfType<Light>();

        // 각 조명 컴포넌트의 범위를 증가시킵니다.
        foreach (Light light in lights)
        {
            light.range += lightRangeIncrease;
        }
    }

    private void TurnOffLights()
    {
        // 물체 기준으로 주변에 있는 모든 조명 컴포넌트를 찾습니다.
        Light[] lights = FindObjectsOfType<Light>();

        // 각 조명 컴포넌트의 범위를 원래대로 복구시킵니다.
        foreach (Light light in lights)
        {
            light.range -= lightRangeIncrease;
        }
    }
}