using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    private Vector2 actualPosition;
    public Vector2 velocity;
    public float speed;
    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigibody.velocity = new Vector2(-speed, myRigibody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigibody.velocity = new Vector2(speed, myRigibody.velocity.y);
        }
    }
}
