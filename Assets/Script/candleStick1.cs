using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleStick1 : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D candleLight;
    public GameObject ghosts;

    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        candleLight = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (candleLight.enabled && !open)
        {
            open = true;
            Transform[] ghost = ghosts.GetComponentsInChildren<Transform>(true);
            foreach (Transform g in ghost)
            {
                g.gameObject.SetActive(true);
            }
        }
    }
}
