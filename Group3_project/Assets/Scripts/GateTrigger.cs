using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    
    [SerializeField]
    GameObject gate;

    bool isOpen = false;

    void start()
    {
        AudioSource audio = GetComponent<AudioSource>();
}
    void OnTriggerEnter(Collider col)
    {
        if (!isOpen)
        {
            isOpen = true;
            GetComponent<AudioSource>().Play();
            gate.transform.position += new Vector3(0, -12, 0);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (isOpen)
        {
            isOpen = false;
            GetComponent<AudioSource>().Play();
            gate.transform.position += new Vector3(0, 12, 0);
        }
    }
}
