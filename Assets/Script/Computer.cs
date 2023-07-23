using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject error_light;

    public void Error()
    {
        error_light.SetActive(true);
    }
}
