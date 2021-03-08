using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject gate;

    bool isOpen = false;
    void OnTriggerEnter(Collider col)
    {
        if (!isOpen)
        {
            gate.transform.position += new Vector3(0, 4, 0);
        }

    }
    void OffTriggerExit(Collider col)
    {
        if (!isOpen)
        {
            gate.transform.position += new Vector3(0, -4, 0);
        }
    }
}
