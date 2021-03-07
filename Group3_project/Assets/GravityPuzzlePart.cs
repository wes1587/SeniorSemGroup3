using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPuzzlePart : MonoBehaviour
{
    public bool isActive = false;
    // public float spellDuration;
    // float spellTempTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive){
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().velocity = new Vector2 (GetComponent<Rigidbody>().velocity.x, Physics.gravity.y);
        }
        else{
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = new Vector2 (GetComponent<Rigidbody>().velocity.x, -Physics.gravity.y);
        }

        if (Input.GetKeyDown (KeyCode.Q)) {
            isActive = !isActive;
        }
    }

    ////update gravity if hit by gravity "spell"
    //  void OnCollisionEnter(Collision object) {
    //     if(object.gameObject.name == "Player");
    //     {
    //         GetComponent<Rigidbody>().useGravity = false;
    //         GetComponent<Rigidbody>().velocity = new Vector2 (GetComponent<Rigidbody>().velocity.x, -Physics.gravity.y);
    //         spellTempTime = spellDuration;   
    //     }
    // }
}
