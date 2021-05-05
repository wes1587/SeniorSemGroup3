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
        RealEnemy enemy = hitInfo.GetComponent<RealEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        Enemy boss = hitInfo.GetComponent<Enemy>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
