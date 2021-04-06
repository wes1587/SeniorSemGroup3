using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballDamage : MonoBehaviour
{
    public int damage = 40;

    void Start()
    {

    }

    void OnTriggerEnter(Collider hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
