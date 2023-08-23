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

    private bool PlayerIn;
    private bool isShowing;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerIn = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerIn = false;
        }
    }

}
