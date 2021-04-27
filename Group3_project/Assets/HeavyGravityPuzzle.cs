using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGravityPuzzle : MonoBehaviour
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
            GetComponent<Rigidbody>().velocity = new Vector2 (GetComponent<Rigidbody>().velocity.x, 30);
        }
        else{
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = new Vector2 (GetComponent<Rigidbody>().velocity.x, -30);
        }

        if (Input.GetKeyDown (KeyCode.Q)) {
            isActive = !isActive;
        }
    }
}