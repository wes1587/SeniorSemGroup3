using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObject : MonoBehaviour
{
    //Movement
    public float speed;
    public float jump;
    public float totalJumps;
    float moveVelocity = 0f;
    float jumpVelocity = 0f;
    float numJumped;
    float distToGround;
    bool isGrounded = true;
    // Controll bool
    public bool canMove;

    void Start(){
        // gets the distance from players center to feet
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update (){

        //control item stoof
        if (Input.GetKeyDown (KeyCode.F)){
            canMove = !canMove;
        }

        //Jumping?
        isGroundedUpdate();
        jumpVelocity = 0f;
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
            if(isGrounded || numJumped < totalJumps){
                isGrounded = false;
                numJumped = numJumped + 1;
                jumpVelocity = jump;
            }
        }

        moveVelocity = 0;

        //Left Right Movement?
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
             moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
             moveVelocity = speed;
        }
        else{
            if(moveVelocity > 0){
                moveVelocity--;
            }
        }
        //actually move
        if(canMove){
            GetComponent<Rigidbody> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody> ().velocity.y + jumpVelocity);
        }
    }

    //Check if Grounded
     public void isGroundedUpdate() {
        if(Physics.Raycast(transform.position, -Vector3.up, distToGround+ 0.1f)){
            isGrounded = true;
            numJumped = 0;
        }
        else{
            isGrounded = false;
        }
    }
}
