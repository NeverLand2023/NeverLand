using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCheck : MonoBehaviour
{
    public GameObject PointLight;
    public GameObject Light;
    public GameObject[] switchButtons = new GameObject[4];
    private SwitchButton[] btn = new SwitchButton[4];
    public GameObject switchObj;


    // Start is called before the first frame update
    void Start()
    {
        btn[0] = switchButtons[0].GetComponent<SwitchButton>();
        btn[1] = switchButtons[1].GetComponent<SwitchButton>();
        btn[2] = switchButtons[2].GetComponent<SwitchButton>();
        btn[3] = switchButtons[3].GetComponent<SwitchButton>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchUpdate();
    }

    public void SwitchUpdate()
    {
      
        if (!btn[0].isUpState && btn[1].isUpState && btn[2].isUpState && !btn[3].isUpState)
        {
            Main_Hook.attackAvailable = true;
            Light.SetActive(true);

            Collider colliderComponent = switchObj.GetComponent<Collider>();
            if (colliderComponent != null)
            {
                colliderComponent.enabled = false;
            }

            Destroy(PointLight);
            Destroy(gameObject);
        }
    }
}
