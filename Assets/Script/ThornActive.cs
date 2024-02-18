using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornActive : MonoBehaviour
{
    public int actButt = 0;
    public GameObject thornObj;
    public GameObject Hook;

    public int resetObj = 0;
    public bool reset = false;
    public bool thorn = false;

    private void Update()
    {
        if (actButt >= 4&&!thorn)
        {
            thorn = true;
            StartCoroutine(ThornActivate(0.5f));
        }

        if(resetObj>=127 && reset)
        {
            reset = false;
            resetObj = 0;
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

    public void BoxReset()
    {
        reset = true;
        Hook.GetComponent<Transform>().position = new Vector2(1.25f, -9.14f);
    }
}
