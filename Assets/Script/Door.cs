using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;
    public AudioSource DoorOpen;

    public Tilemap tilemap;
    public Tilemap tilemap2;
    public float fadeSpeed = 7f;
    public GameObject fireEmoji;

    private bool PlayerIn;
    private bool isShowing;

    private bool end = false;
    //private Animator anim;
    // Update is called once per frame


    void Update()
    {



        if (PlayerIn && Input.GetKeyDown(KeyCode.Space) && FireCount.fire == 5)
        {
            DoorOpen.Play();
            animator.SetBool("Open", true);
            isShowing = true;
        }

        if (isShowing)
        {
            tilemap.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(tilemap.color.a, 0f, fadeSpeed * Time.deltaTime));
            tilemap2.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(tilemap.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (tilemap.color.a == 0f&& tilemap2.color.a == 0f)
            {
                Destroy(gameObject);
            }

        }
    }

    private void Destroy_obj()
    {
        animator.SetBool("end", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerIn = true;

            if (FireCount.fire != 5)
            {
                StartCoroutine(ShowEmoji(fireEmoji, 0.8f));
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerIn = false;
        }
    }

    IEnumerator ShowEmoji(GameObject obj, float delayTime)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        obj.SetActive(false);        
    }
}
