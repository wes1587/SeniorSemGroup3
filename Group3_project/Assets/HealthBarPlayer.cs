using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour
{
    public GameObject player;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //test to see if bar goes down
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
        }   
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            player.transform.position = new Vector3(-8,1,5);
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Boulder")
        {
            TakeDamage(20);
        }

    }
}
