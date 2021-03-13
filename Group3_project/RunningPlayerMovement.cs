using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
float Speed = 8;
 
void Update()
{
    
 
    if (Input.GetKey("right"))
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
    }
    else if (Input.GetKey("left"))
    {
        
        transform.position += Vector3.left * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
    }
    else if (Input.GetKey("up")){
        transform.position += Vector3.up * Speed * Time.deltaTime;

    }
    if ((Input.GetKey("up")) && (Input.GetKey("left"))){
        transform.position += Vector3.up * Speed * Time.deltaTime;
        transform.position += Vector3.left * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,270f,0f);
    }
    if ((Input.GetKey("up")) && (Input.GetKey("right"))){
        transform.position += Vector3.up * Speed * Time.deltaTime;
        transform.position += Vector3.right * Speed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f);
    }
    
}
}
