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
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip[] audioList;

    void Start(){
        // gets the distance from players center to feet
        distToGround = GetComponent<Collider>().bounds.extents.y;
        anim = GetComponent<Animator>();
        //Audio
        AudioSource audio = GetComponent<AudioSource>();
        audioList = new AudioClip[]{(AudioClip) Resources.Load("Player_Jump"),
                                    (AudioClip) Resources.Load("Player_Land_Jump") };
        jumpSound = audioList[0];
        landSound = audioList[1];
    }

    void Update (){
        isGroundedUpdate();
        //Jumping?
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
            if(isGrounded || numJumped < totalJumps){
                GetComponent<AudioSource>().clip = jumpSound;
                GetComponent<AudioSource>().Play();
                GetComponent<Rigidbody> ().velocity = new Vector2 (GetComponent<Rigidbody> ().velocity.x, jump);
                isGrounded = false;
                numJumped = numJumped + 1;
            }
        }

        moveVelocity = 0;

        //Left Right Movement?
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
             moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
            moveVelocity = speed;
            anim.SetBool("Walking",true);
        }
        if (!(Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))){
            anim.SetBool("Walking",false);   
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
        if (col.gameObject.name == "Ground" && distToGround > 0.1){
            GetComponent<AudioSource>().clip = landSound;
            GetComponent<AudioSource>().Play();
        }
        
    }
    
    
}