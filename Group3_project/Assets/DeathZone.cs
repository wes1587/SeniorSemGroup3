using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    public AudioClip death1;
    public AudioClip death2;
    public AudioClip[] audioList;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audioList = new AudioClip[]{(AudioClip) Resources.Load("Player_Death_Noise"),
                                    (AudioClip) Resources.Load("Player_Death_Noise2") };
        death1 = audioList[0];
        death2 = audioList[1];
    }

    void OnCollisionEnter(){
        int number = Random.Range(0, 1);
        if (number == 1){
            GetComponent<AudioSource>().clip = death1;
            GetComponent<AudioSource>().Play();
        }
        
        else {
            GetComponent<AudioSource>().clip = death2;
            GetComponent<AudioSource>().Play();
        }
            
        player.transform.position = new Vector3(-8,1,5);
    }
}
