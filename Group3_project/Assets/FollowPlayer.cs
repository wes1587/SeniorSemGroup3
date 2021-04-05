using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Transform Cpuzzle;
    public Vector3 offset;
    public bool spellActive;

    // Update is called once per frame
    void Update(){

        //control item stoof
        if (Input.GetKeyDown (KeyCode.F)){
            spellActive = !spellActive;
        }

        if(spellActive){
            transform.position = Cpuzzle.position + offset;
        }
        else{
            transform.position = player.position + offset;
        }
    }
}
