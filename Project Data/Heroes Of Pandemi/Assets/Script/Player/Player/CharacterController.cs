using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    public float speed = 3;
    public VariableJoystick joystick;
    PressJoystick pressJoystick;

    private UnityArmatureComponent animator;

    // Try Grid Movement
    public UnityEngine.Transform movePoint;
    public UnityEngine.Transform[] limitArea;
    public bool canMove;
    public bool isPlayingAnimation = false;

    void Start()
    {
        animator = GetComponent<UnityArmatureComponent>();

        pressJoystick = FindObjectOfType<PressJoystick>();
        movePoint.parent = null;
        canMove = true;
        animator.animation.Play(("PlayerIdle"));
    }
    void Update()
    {
        GridMovement();
    }
    void GridMovement()
    {
        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        if (!pressJoystick.press)
        {
            // PlayingAnimation("PlayerIdle");
            canMove = false;
        }
        if (pressJoystick.press)
        {
            canMove = true;
        }
        if (canMove)
        {
            Debug.Log(horizontal + " -- " + vertical);
            gameObject.transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
            // animator.animation.Play(("PlayerWalking_alternative2"), 0);
            //gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
        }

    }
    void PlayingAnimation(string animationName)
    {
        //animator.animation.Play((animationName));
        animator.animation.FadeIn(animationName, 0.25f, 0);
    }
}
