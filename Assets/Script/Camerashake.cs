using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camerashake : MonoBehaviour
{
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;

    Quaternion m_originRot;
    float shakeStartTime;
    bool earthquake =  false;


    // Start is called before the first frame update
    void Start()
    {
        m_originRot = transform.rotation;
        shakeStartTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.parent.position;

        if (playerPosition.x >= -10f && playerPosition.x <= -7f &&
            playerPosition.y >= 160f && playerPosition.y <= 162f&& earthquake==false)
        {
            StartCoroutine(ShakeCoroutine());
            shakeStartTime = Time.time;
            Debug.Log("소리 재생");
            SoundManager.instance.earthquakesound.Play();
            earthquake = true;

        }
        else if (earthquake ==true && Time.time - shakeStartTime >= 2f)
        {
            StopAllCoroutines();
            StartCoroutine(Reset());
            
        }
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 t_originEuler = transform.eulerAngles;
        while(true)
        {
            float t_rotX = Random.Range(-m_offset.x, m_offset.x);
            float t_rotY = Random.Range(-m_offset.y, m_offset.y);

            Vector3 t_randomRot = t_originEuler + new Vector3(t_rotX, t_rotY);
            Quaternion t_rot = Quaternion.Euler(t_randomRot);

            while(Quaternion.Angle(transform.rotation,t_rot)>0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;

            }
            yield return null;

        }


    }

    IEnumerator Reset()
    {
        while(Quaternion.Angle(transform.rotation, m_originRot)>0f)
        {
            SoundManager.instance.earthquakesound.Stop();
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_originRot, m_force * Time.deltaTime);
            yield return null;   
        }

    }
}
