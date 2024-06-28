using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;
    public Ease ease = Ease.OutBack;

    [Header("Animation Setup")]
    public float JumpScaleY = 1.5f;
    public float JumpScaleX = .7f;
    public float animationDuration = .1f;
    private float _currentSpeed;


    [Header("Animation Player")]
    public string triggerRun = "Run";
    public Animator animator;
    public float swipeDuration = .1f;
    private void HandleMoviment()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speedRun = 15.0f;
            _currentSpeed = speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            animator.SetBool(triggerRun, true);
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
            if (myRigibody.transform.localScale.x != -1)
            {
                myRigibody.transform.DOScaleX(-1, swipeDuration);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
        
            animator.SetBool(triggerRun, true);
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
            if (myRigibody.transform.localScale.x != -1)
            {
                myRigibody.transform.DOScaleX(1, swipeDuration);
            }
        }
        else
        {
            animator.SetBool(triggerRun, false);
        }



        if (myRigibody.velocity.x > 0)
            myRigibody.velocity -= friction;
        else
            myRigibody.velocity += friction;
    }

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigibody.velocity = Vector2.up * forceJump;
            myRigibody.transform.localScale = Vector2.one;
            HandleScaleJump();
            DOTween.Kill(myRigibody.transform);
        }
    }
    private void HandleScaleJump()
    {
        myRigibody.transform.DOScaleY(JumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigibody.transform.DOScaleX(JumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}


