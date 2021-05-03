using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour{
   
    //movement variables
    public float runSpeed;
    public float walkSpeed;
    Rigidbody myRB;
    Animator myAnim;
    GameObject rightFoot;
    GameObject checkGround;
    float distToGround;

    bool facingRight;
    // for jumping
    bool isGrounded = true;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    bool canDoubleJump;
    //controll Script 
    public bool canMove;
    
    //Audio
     AudioClip jumpSound;
     AudioClip landSound;
     AudioClip[] audioList;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
        rightFoot = GameObject.Find("mixamorig:RightFoot");
        checkGround = GameObject.Find("checkGroundLocation");
        distToGround = GetComponent<Collider>().bounds.extents.y;
        //Audio
        AudioSource audio = GetComponent<AudioSource>();
        audioList = new AudioClip[]{(AudioClip) Resources.Load("Player_Jump"),
                                    (AudioClip) Resources.Load("Player_Land_Jump") };
        jumpSound = audioList[0];
        landSound = audioList[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            canMove = !canMove;
        }
    }

    // when working with physics is better to use this method
    void FixedUpdate()
    {

        if(canMove){
            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (isGrounded)
                {
                    isGrounded = false;
                    GetComponent<AudioSource>().clip = jumpSound;
                    GetComponent<AudioSource>().Play();
                    myAnim.SetBool("grounded", isGrounded);
                    myRB.AddForce(new Vector3(0, jumpHeight, 0));


                }
                else
                {

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (canDoubleJump)
                        {
                            isGrounded = false;
                            GetComponent<AudioSource>().clip = jumpSound;
                            GetComponent<AudioSource>().Play();
                            myAnim.SetBool("grounded", isGrounded);
                            myRB.AddForce(new Vector3(0, jumpHeight, 0));
                            canDoubleJump = false;
                        }

                    }
                }

            }

            isGroundedUpdate();
            myAnim.SetBool("grounded", isGrounded);

            float move = Input.GetAxis("Horizontal");
            myAnim.SetFloat("speed", Mathf.Abs(move));

            float sneaking = Input.GetAxisRaw("Fire3");
            myAnim.SetFloat("sneaking", sneaking);

            if (sneaking > 0)
            {
                myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
            }
            else
            {
                myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
            }

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;

    }

    public void isGroundedUpdate(){
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.2f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    //Collision check/Distance to ground check, to play Landing Sound
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ground" && distToGround > 0.1)
        {
            GetComponent<AudioSource>().clip = landSound;
            GetComponent<AudioSource>().Play();
        }

    }
}