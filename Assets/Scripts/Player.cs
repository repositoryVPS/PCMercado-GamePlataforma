using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;


    private float _currentSpeed;
    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        
        if(Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
        }

        if (myRigibody.velocity.x > 0)
            myRigibody.velocity -= friction;
        else
            myRigibody.velocity += friction;
    }


    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigibody.velocity = Vector2.up * forceJump;
        }
    }
}


