using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    public AudioSource DeathAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayDeathSound()
    {
        DeathAudioSource.Play();
    }

    void OnCollisionEnter(){
        player.transform.position = new Vector3(-8,1,5);
        PlayDeathSound();
    }
}
