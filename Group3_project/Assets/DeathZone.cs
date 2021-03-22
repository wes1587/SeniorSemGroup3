using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    public AudioSource DeathSound1;
    public AudioSource DeathSound2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(){
        int number = Random.Range(0, 1);
        if (number == 1)
            DeathSound1.Play();
        else
            DeathSound2.Play();
        player.transform.position = new Vector3(-8,1,5);
    }
}
