using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornActive : MonoBehaviour
{
    public int actButt = 0;
    public GameObject thornObj;
    public bool thorn = false;

    private void Update()
    {
        if (actButt >= 4&&!thorn)
        {
            thorn = true;
            StartCoroutine(ThornActivate(0.5f));
        }
    
    }
    IEnumerator ThornActivate(float delay)
    {
        thornObj.SetActive(true);
        actButt = 0;
        yield return new WaitForSeconds(delay);
        thornObj.SetActive(false);
        thorn = false;
    }
}
