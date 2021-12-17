using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class CharacterController : MonoBehaviour
{
    public float speed = 3;

    private UnityArmatureComponent animator;
    Vector2 movement;
    private Rigidbody2D rb;

    // Try Grid Movement
    public UnityEngine.Transform movePoint;
    public UnityEngine.Transform[] limitArea;
    public bool canMove = true;
    public bool isPlayingAnimation = false;

    void Start()
    {
        animator = GetComponent<UnityArmatureComponent>();
        rb = GetComponent<Rigidbody2D>();

        movePoint.parent = null;
        canMove = true;
        PlayingAnimation("PlayerIdle");
    }
    void Update()
    {
        GridMovement();
    }
    void GridMovement()
    {
        //transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        //if (Vector3.Distance(transform.position, movePoint.position) <= .5f && canMove)
        //{
        //    if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        //    {
        //        movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        //    }
        //    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        //    {
        //        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        //    }
        //}

        if ( canMove)
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            gameObject.transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
            

            /// ini untuk play animasi ya
            if (Input.GetButtonDown("Horizontal")|| Input.GetButtonDown("Vertical"))
            {
                if(!isPlayingAnimation) isPlayingAnimation = false;
                PlayingAnimation("PlayerWalking_alternative2");

            }
            if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
            {
                PlayingAnimation("PlayerIdle");
            }
        }
    }

    
    void PlayingAnimation(string animationName)
    {
        //animator.animation.Play((animationName));
        animator.animation.FadeIn(animationName, 0.25f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopCollider")
        {
            Vector3 movePos = movePoint.position;
            movePos.x = this.transform.position.x;
            movePos.y = this.transform.position.y - 0.5f;
            movePoint.position = movePos;
        }
        if (collision.gameObject.tag == "RightCollider")
        {
            Vector3 movePos = movePoint.position;
            movePos.x = this.transform.position.x - 0.5f;
            movePos.y = this.transform.position.y;
            movePoint.position = movePos;
        }
        if (collision.gameObject.tag == "BotCollider")
        {
            Vector3 movePos = movePoint.position;
            movePos.x = this.transform.position.x;
            movePos.y = this.transform.position.y + 0.5f;
            movePoint.position = movePos;
        }
    }
}
