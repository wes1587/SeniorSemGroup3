using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fattack2 : MonoBehaviour
{
    public GameObject fireBall;
    public bool lookingRight;
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

        if (Input.GetKey(KeyCode.A))
        {
            lookingRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            lookingRight = true;
        }
    }

    public void Fthrow()
    {
        if (lookingRight)
        {
            GameObject Fball = Instantiate(fireBall, fireBallPos.position, Quaternion.Euler(0, 0, -90));
            Fball.GetComponent<Rigidbody>().AddForce(fireBallPos.forward * fireBallSpeed);
            Destroy(Fball, 3);
        }

        if (!lookingRight)
        {
            GameObject Fball = Instantiate(fireBall, fireBallPos.position, Quaternion.Euler(0, 0, 90));
            Fball.GetComponent<Rigidbody>().AddForce(fireBallPos.forward * fireBallSpeed);
            Destroy(Fball, 3);
        }
    }
}