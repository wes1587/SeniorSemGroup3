using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battack : MonoBehaviour
{
    public int damage = 20;

    void Start()
    {

    }

    void OnTriggerEnter(Collider hitInfo)
    {
        HealthBarPlayer HBP = hitInfo.GetComponent<HealthBarPlayer>();
        if (HBP != null)
        {
            HBP.TakeDamage(20);
        }
        Destroy(gameObject);
    }

}
