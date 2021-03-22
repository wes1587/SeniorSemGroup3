using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerMovement : MonoBehaviour
{

 public  float moveSpeed;
 public  float walkSpeed;
 public float runSpeed;

public  Vector3 moveDirection;
public  Vector3 velocity;

 public  bool isGrounded;
 public  float groundCheckDistance;
 public  LayerMask groundMask; 
public float gravity;

public float jumpHeight;
//References
public CharacterController controller;
public Animator anim;

private void Start (){
    controller = GetComponent<CharacterController>();
    anim = GetComponentInChildren<Animator>();
}
private void Update (){
    Move();
}
private void Move (){
    isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

    if((isGrounded && velocity.y < 0)){
        velocity.y = -2f;
    }


     float moveZ = Input.GetAxis("Horizontal");
     moveDirection = new Vector3(moveZ,0 , 0);

     if(isGrounded){
        if ( moveDirection != Vector3.zero && !Input.GetKey("left")){
         //walking
         Walk();
     }
     else if ( moveDirection != Vector3.zero && !Input.GetKey("right")){
         Walk();
     }
     else if (moveDirection != Vector3.zero && Input.GetKey("left")){
         // Running
         Run();

     }
     else if (moveDirection == Vector3.zero){
         //Idle
         Idle();
     }
     moveDirection *= walkSpeed;
     if(Input.GetKeyDown(KeyCode.Space)){
         Jump();
     }
     }
     //moveDirection *= walkSpeed;

     

     moveDirection *= moveSpeed;

     controller.Move(moveDirection * Time.deltaTime);

     velocity.y += gravity * Time.deltaTime;
     controller.Move(velocity * Time.deltaTime);
}
private void Idle(){
 anim.SetFloat("Speed",1);
}
private void Walk(){
    moveSpeed = walkSpeed;
    
      if (Input.GetKey("right"))
    {
        anim.SetFloat("Speed",0.6666667f);
        // transform.position += Vector3.right * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
    }
    else if (Input.GetKey("left"))
    {
        anim.SetFloat("Speed",0.6666667f);
        
        // transform.position += Vector3.left * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
    }
}
private void Run(){
    moveSpeed = runSpeed;
    anim.SetFloat("Speed",0.3333333f);
}
private void Jump(){
    velocity.y = Mathf.Sqrt(jumpHeight * -2 *  gravity);
    anim.SetFloat("Speed",0f);
}
    // Start is called before the first frame update
// float Speed = 8;
 
// void Update()
// {
    
 
//     if (Input.GetKey("right"))
//     {
//         transform.position += Vector3.right * Speed * Time.deltaTime;
//         this.gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
//     }
//     else if (Input.GetKey("left"))
//     {
        
//         transform.position += Vector3.left * Speed * Time.deltaTime;
//         this.gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
//     }
//     else if (Input.GetKey("up")){
//         transform.position += Vector3.up * Speed * Time.deltaTime;

//     }
//     if ((Input.GetKey("up")) && (Input.GetKey("left"))){
//         transform.position += Vector3.up * Speed * Time.deltaTime;
//         transform.position += Vector3.left * Speed * Time.deltaTime;
//         this.gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
//     }
//     if ((Input.GetKey("up")) && (Input.GetKey("right"))){
//         transform.position += Vector3.up * Speed * Time.deltaTime;
//         transform.position += Vector3.right * Speed * Time.deltaTime;
//         this.gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
//     }
    
// }
}
