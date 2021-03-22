using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementOfCharacter2 : MonoBehaviour
{
 public float counter = 0;
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
    counter  = 0;
}
private void Move (){
    // code take it from youtube
    isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

    if((isGrounded && velocity.y < 0)){
        velocity.y = -2f;
    }
    


     float moveZ = Input.GetAxis("Horizontal");
     moveDirection = new Vector3(moveZ,0 , 0);
     //

     if(isGrounded){
        if ( moveDirection != Vector3.zero && !Input.GetKey("left")){
         //walking
         Walk();
     }
     else if ( moveDirection != Vector3.zero && !Input.GetKey("right")){
         Walk();
         
     }
     else if ( moveDirection != Vector3.zero && !Input.GetKey("right") && Input.GetKey(KeyCode.Space)){
         Jump();
         counter++;
     }
      else if ( moveDirection != Vector3.zero && !Input.GetKey("left") && Input.GetKey(KeyCode.Space)){
         Jump();
         counter++;
     }
     else if (moveDirection != Vector3.zero && Input.GetKey("left")){
         // Running
         Run();

     }
     if (moveDirection != Vector3.zero && Input.GetKey("left") && Input.GetKey(KeyCode.Space)){
         // Running
         Jump();
         counter++;

     }
     else if (moveDirection == Vector3.zero){
         //Idle
         Idle();
     }
     moveDirection *= walkSpeed;
     if(Input.GetKey(KeyCode.Space)){
         Jump();
         counter++;
     }
     }
    

     
// take it from youtube
     moveDirection *= moveSpeed;

     controller.Move(moveDirection * Time.deltaTime);

     velocity.y += gravity * Time.deltaTime;
     controller.Move(velocity * Time.deltaTime);
//
}
private void Idle(){
 anim.SetFloat("Speed",1);
}
private void Walk(){
    moveSpeed = walkSpeed;
    
      if (Input.GetKey("right"))
    {
        anim.SetFloat("Speed",0.6666667f,0.1f, Time.deltaTime);
        // transform.position += Vector3.right * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
    }
    else if (Input.GetKey("left"))
    {
        anim.SetFloat("Speed",0.6666667f,0.1f, Time.deltaTime);
        // transform.position += Vector3.left * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
    }
}
private void Run(){
    moveSpeed = runSpeed;
    anim.SetFloat("Speed",0.3333333f,0.1f, Time.deltaTime);
}
private void Jump(){
    if ( counter> 2){
     jumpHeight = jumpHeight*2;
     velocity.y = Mathf.Sqrt(jumpHeight * -4 *  gravity);
    anim.SetFloat("Speed",0f);   
    }
    velocity.y = Mathf.Sqrt(jumpHeight * -2 *  gravity);
    anim.SetFloat("Speed",0f);
}

}
