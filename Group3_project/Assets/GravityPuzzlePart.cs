using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPuzzlePart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //update gravity if hit by gravity spell
     void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Player");
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = new Vector2 (GetComponent<Rigidbody> ().velocity.x, -Physics.gravity.y);    
        }
    }
}
