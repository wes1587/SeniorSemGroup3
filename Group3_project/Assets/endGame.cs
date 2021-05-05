using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public GameObject winText;
    public GameObject PauseMenu;
    AudioSource PlayAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayAudioSource = GetComponent<AudioSource>();
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            // show congratz
            GetComponent<AudioSource>().Play();
            winText.SetActive(true);            
        }
    }
}
