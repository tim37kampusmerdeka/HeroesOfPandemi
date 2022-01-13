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
    public bool canMove = true;
    private bool isIdle = true;


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
        if (canMove)
        {
            var horizontal = joystick.Horizontal;
            var vertical = joystick.Vertical;

            gameObject.transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
            
            if(vertical == 0 && horizontal == 0)
            {
                if (isIdle == false)
                {
                    isIdle = true;
                    PlayingAnimation("PlayerIdle");
                }
            }
            else
            {
                if (isIdle == true)
                {
                    isIdle = false;
                    PlayingAnimation("PlayerWalking_alternative2");
                }
            }
        
        }
    }

    void PlayingAnimation(string animationName)
    {
        //animator.animation.Play((animationName));
        animator.animation.FadeIn(animationName, 0.25f, 0);
    }
}
