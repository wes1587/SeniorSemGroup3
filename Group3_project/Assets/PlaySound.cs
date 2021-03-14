using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audio;
    bool isPlaying;
    bool toggleChange;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true && toggleChange == true)
        {
            audio.Play();
            toggleChange = false;
        }
        if (isPlaying == false && toggleChange == true)
        {
            audio.Stop();
            toggleChange = false;
        }
    }
}
