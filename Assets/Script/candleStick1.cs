using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleStick1 : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D candleLight;
    public GameObject ghosts;
    public GameObject candleSticks;
    public GameObject artwork;
    private Transform[] ghost;

    private bool first;
    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        ghost = ghosts.GetComponentsInChildren<Transform>(true);
        open = false;
        candleLight = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (candleLight.enabled && !open)
        {
            open = true;
            SoundManager.instance.ghostBGM.Play();
            foreach (Transform g in ghost)
            {
                g.gameObject.SetActive(true);
            }
        }*/

        UnityEngine.Rendering.Universal.Light2D[] lights = candleSticks.GetComponentsInChildren<UnityEngine.Rendering.Universal.Light2D>();

        if (!first)
        {
            if (lights[0].enabled || lights[1].enabled || lights[2].enabled)
            {
                //하나라도 켜지면 유령&브금 생성
                open = true;
                first = true;
                SoundManager.instance.ghostBGM.Play();
                foreach (Transform g in ghost)
                {
                    g.gameObject.SetActive(true);
                }
            }
        }

        if (lights[0].enabled && lights[1].enabled && lights[2].enabled)
        {
            foreach (Transform g in ghost)
            {
                g.gameObject.SetActive(false);
            }
            artwork.gameObject.SetActive(true);
            SoundManager.instance.ghostBGM.Stop();
        }
        
    }
}
