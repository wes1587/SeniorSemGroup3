using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfCharacter : MonoBehaviour
{
float Speed = 5;
 
void Update()
{
    
 
    if (Input.GetKey("right"))
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }
    else if (Input.GetKey("left"))
    {
        transform.position -= transform.right * Speed * Time.deltaTime;
    }
}
}