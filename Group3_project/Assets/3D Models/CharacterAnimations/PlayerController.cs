﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    //movement variables
    public float runSpeed;
    public float walkSpeed;
    Rigidbody myRB;
    Animator myAnim;
    GameObject rightFoot;
    GameObject checkGround;

    bool facingRight;
    // for jumping
    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
        rightFoot = GameObject.Find("mixamorig:RightFoot");
        checkGround = GameObject.Find("checkGroundLocation");

    }

    // Update is called once per frame
    void Update()
    {
        //checkGround.transform.position = rightFoot.transform.position;
    }


    // when working with physics is better to use this method
    void FixedUpdate()
    {

        if (grounded)
        {

            canDoubleJump = true;
        }
        else
        {
           

        }
        if (Input.GetKey(KeyCode.Space)) {
            if (grounded) {
                grounded = false;
                myAnim.SetBool("grounded", grounded);
                myRB.AddForce(new Vector3(0, jumpHeight, 0));
                

            }
            else
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (canDoubleJump)
                    {
                        grounded = false;
                        myAnim.SetBool("grounded", grounded);
                        myRB.AddForce(new Vector3(0, jumpHeight + jumpHeight, 0));
                        canDoubleJump = false;
                    }

                }
            }
        
        }
       

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        myAnim.SetBool("grounded", grounded);




        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));


        float sneaking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("sneaking", sneaking);

        if (sneaking > 0)
        {
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
        }
        else {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
        }

        if (move>0 && !facingRight)
        {
            Flip();
        }
        else if ( move< 0  && facingRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;

    }
}