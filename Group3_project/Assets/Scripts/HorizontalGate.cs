using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGate : MonoBehaviour
{
    [SerializeField]
    GameObject gate;

    bool isOpen = false;
    void OnTriggerEnter(Collider col)
    {
        if (!isOpen)
        {
            isOpen = true;
            gate.transform.position += new Vector3(-12, 0, 0);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (isOpen)
        {
            isOpen = false;
            gate.transform.position += new Vector3(-12, 0, 0);
        }
    }
}
