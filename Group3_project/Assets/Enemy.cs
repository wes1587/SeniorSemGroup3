using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject foe;
    private GameObject Boss;
    public AudioSource BossDeathAudioSource;
    AudioClip BossDeathSound;

    void Start()
    {
        BossDeathAudioSource = GetComponent<AudioSource>();
        BossDeathSound = (AudioClip)Resources.Load("Boss_Death");
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        transform.position = new Vector3(0, 90, 0);
        Instantiate(foe, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().clip = BossDeathSound;
        GetComponent<AudioSource>().Play();
        Destroy(Boss);
    }

}
