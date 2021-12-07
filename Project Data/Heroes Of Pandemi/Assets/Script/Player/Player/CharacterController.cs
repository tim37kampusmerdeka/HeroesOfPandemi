using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 3;

    Animator animator;
    Vector2 movement;
    private Rigidbody2D rb;

    // Try Grid Movement
    public Transform movePoint;
    public Transform[] limitArea;
    bool canMove;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        movePoint.parent = null;
        canMove = true;
    }
    void Update()
    {
        GridMovement();
    }
    void GridMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= .5f && canMove)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            }
        }
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
