using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 3;

    Animator animator;
    Vector2 movement;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        // Set hadap player
        if (horiz > 0)
        {
            animator.SetBool("IsWalking", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horiz < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("IsWalking", true);
        }else
        {
            animator.SetBool("IsWalking", false);
        }
        movement = new Vector2(horiz, vert).normalized;
        rb.velocity = movement * speed;
    }
}
