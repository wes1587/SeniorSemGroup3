using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfCharacter : MonoBehaviour
{
    //Movement
    public float speed;
    public float jump;
    public float totalJumps;
    float moveVelocity = 0f;
    float numJumped;
    float distToGround;
    bool isGrounded = true;
    public Animator anim;
    //Audio
    public AudioSource PlayerJump;
    public AudioSource PlayerLand;

    void Start(){
        // gets the distance from players center to feet
        distToGround = GetComponent<Collider>().bounds.extents.y;
        anim = GetComponent<Animator>();
    }

    void Update (){
        isGroundedUpdate();
        moveVelocity = 0;
        // user press w or arrow up to jump
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) {
            Jump();
        }

        

        //Left Right Movement?
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
             moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
            if (Input.GetKey(KeyCode.RightArrow)&&(Input.GetKey(KeyCode.LeftArrow))){
            anim.SetBool("Running",true);  
            anim.SetBool("Walking",false);  
            
            moveVelocity = speed * 2;
             }
          
       
        
            else{
                moveVelocity = speed;
                anim.SetBool("Walking",true);
                anim.SetBool("Idle",false);
            }
        }
      
        if (!(Input.GetKey(KeyCode.RightArrow)&&(Input.GetKey(KeyCode.LeftArrow)))){
            anim.SetBool("Running",false);  
            anim.SetBool("Idle",true);
        }

        if (!(Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))){
            anim.SetBool("Walking",false); 
            anim.SetBool("Idle",true); 
        }
         if (Input.GetKey (KeyCode.G)){
            anim.SetBool("Attacking",true);
            anim.SetBool("Idle",false);
            anim.SetBool("Walking",false);  
            anim.SetBool("Running",false); 
        }
        if (!(Input.GetKey (KeyCode.G))){
            anim.SetBool("Attacking",false);
            anim.SetBool("Idle",true);
        }
        else{
            if(moveVelocity > 0){
                moveVelocity--;
            }
        }

        //actually move
        GetComponent<Rigidbody> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody> ().velocity.y);
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
    //Collision check/Distance to ground check, to play Landing Sound
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Ground" && distToGround > 0.1)
            PlayerLand.Play();
    }
    void Jump(){
        if(isGrounded || numJumped < totalJumps){
                PlayerJump.Play();
                GetComponent<Rigidbody> ().velocity = new Vector2 (GetComponent<Rigidbody> ().velocity.x, jump);
                isGrounded = false;
                numJumped = numJumped + 1;
            }
    }
    
    
}