using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource PlayAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int number = Random.Range(0, 2500);
        if (number == 25)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
