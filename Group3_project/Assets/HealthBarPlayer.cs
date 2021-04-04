﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour
{

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(20);
        }
           
        
    }

    void Damage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}