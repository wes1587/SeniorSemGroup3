using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(){
        player.transform.position = new Vector3(-8,1,5);
    }
}
