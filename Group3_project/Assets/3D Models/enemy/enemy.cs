using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using enemy;
public class enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public Animator animator;
    public float speed = 3;
    public float attackRange = 2;
    public int health;
    public int maxHealth;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // distance between player and enemy
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState")
        {
            if (distance< chaseRange)
            {
                currentState = "ChaseState";
            }
        }
        else if (currentState== "ChaseState")
        {
            // play the run animation
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if (distance < attackRange)
            {
                currentState = "AttackState";
            }

            //move towards player
            if ( target.position.x > transform.position.x)
            {
                //move right
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                //move left
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        // else if ( currentState == "AttackState")
        // {
        //     animator.SetBool("isAttacking", true);
        //     if ( distance > attackRange)
        //     {
        //         currentState = "ChaseState";
        //     }
        // }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if ( health < 0)
        {
            Die();
        }
    }
    private void Die() {
        // play a die animation
        //disable the script and the collider
        // animator.SetTrigger("isDead");
        // GetComponent<CapsulleCollider>().enabled = false;
        // this.enabled = false;
    }

}