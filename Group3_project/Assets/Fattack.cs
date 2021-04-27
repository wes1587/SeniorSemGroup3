using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fattack : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPos;
    public float fireBallSpeed = 600;
    public int damage = 10;
    public AudioSource fireballAudioSource;
    AudioClip fireBallSound;

    void Start()
    {
        fireballAudioSource = GetComponent<AudioSource>();
        fireBallSound = (AudioClip)Resources.Load("Fireball");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<AudioSource>().clip = fireBallSound;
            GetComponent<AudioSource>().Play();
            Fthrow();
        }
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(damage);
        //}
        //Destroy(gameObject);
        if (hitInfo.tag == "Enemy")
        {
            hitInfo.GetComponent<enemy2>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void Fthrow()
    {
        {

            GameObject Fball = Instantiate(fireBall, fireBallPos.position, Quaternion.Euler(0, 0, -90));
            Fball.GetComponent<Rigidbody>().AddForce(fireBallPos.forward * fireBallSpeed);
            Destroy(Fball, 3);
        }
    }
}
