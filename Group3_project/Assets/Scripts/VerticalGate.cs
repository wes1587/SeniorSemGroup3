using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGate : MonoBehaviour
{
    public AudioSource audio;
    [SerializeField]
    GameObject gate;

    bool isOpen = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!isOpen)
        {
            isOpen = true;
            audio.Play();
            gate.transform.position += new Vector3(0, 12, 0);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (isOpen)
        {
            isOpen = false;
            audio.Play();
            gate.transform.position += new Vector3(0, -12, 0);
        }
    }
}
