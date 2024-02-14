using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public static IEnumerator make_wall(GameObject wall)
    {
        //À§¿¡¼­ ¶³¾îÁö±â
        Rigidbody2D[] new_walls = wall.GetComponentsInChildren<Rigidbody2D>();

        foreach(Rigidbody2D w in new_walls)
        {
            w.gravityScale = 1;
        }

        yield return new WaitForSeconds(3);

        foreach (Rigidbody2D w in new_walls)
        {
            w.gravityScale = 0;
            w.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }

    public static IEnumerator random_fall()
    {
        Rigidbody2D[] walls = GameObject.Find("walls").GetComponentsInChildren<Rigidbody2D>();
        int num = Random.Range(0, walls.Length);
        Transform transform = walls[num].transform;

        //¶³¾îÁö±â Àü Èçµé¸²
        float t = 5f;
        float shakePower = 0.05f;
        Vector3 origin = transform.position;

        SoundManager.instance.server_shake.Play();
        while (t > 0f)
        {
            Debug.Log(1);
            t -= 0.05f;
            transform.position = origin + (Vector3)Random.insideUnitCircle * shakePower * t;
            yield return null;
        }
        transform.position = origin;

        yield return new WaitForSeconds(0.5f);
        SoundManager.instance.server_shake.Pause();

        //¶³¾îÁü
        SoundManager.instance.server_fall.Play();
        walls[num].GetComponentInChildren<Collider2D>(true).gameObject.SetActive(true);
        
        walls[num].constraints = RigidbodyConstraints2D.None;
        walls[num].constraints = RigidbodyConstraints2D.FreezeRotation;
        walls[num].constraints = RigidbodyConstraints2D.FreezePositionX;
        walls[num].gravityScale = 1;
        

        yield return new WaitForSeconds(3);
        

        walls[num].GetComponent<Transform>().position = origin;
        walls[num].GetComponentInChildren<Collider2D>(true).gameObject.SetActive(false);
        walls[num].gravityScale = 0;
        walls[num].constraints = RigidbodyConstraints2D.FreezeAll;

    }

    public static void shake(Transform transform, Vector3 origin)
    {
        float t = 3f;
        float shakePower = 80f;
        
        while(t > 0f)
        {
            Debug.Log(1);
            t -= 0.05f;
            transform.position = origin + (Vector3)Random.insideUnitCircle * shakePower * t;
            Debug.Log(transform.position);
        }
        transform.position = origin;
    }

    IEnumerator Shake()
    {
        float t = 10f;
        float shakePower = 0.1f;
        Vector3 origin = transform.position;

        while (t > 0f)
        {
            Debug.Log(1);
            t -= 0.05f;
            transform.position = origin + (Vector3)Random.insideUnitCircle * shakePower * t;
            yield return null;
        }
        transform.position = origin;
    }
}
