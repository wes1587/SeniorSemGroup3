using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfCharacter : MonoBehaviour
{
    //Movement
    public float speed;
    public float jump;
    public float totalJumps;
    float moveVelocity = 0;
    float numJumped;

    //Grounded Vars
    bool isGrounded = true;

    void Update () 
    {
         //Jumping
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
        {
            if(isGrounded || numJumped < totalJumps)
            {
                GetComponent<Rigidbody> ().velocity = new Vector2 (GetComponent<Rigidbody> ().velocity.x, jump);
                isGrounded = false;
                numJumped = numJumped + 1;
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
             moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = speed;
        }
        else
        {
            if(moveVelocity > 0){
                moveVelocity--;
            }
        }

        GetComponent<Rigidbody> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody> ().velocity.y);
    }

    //Check if Grounded
     void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        numJumped = 0;
    }
}