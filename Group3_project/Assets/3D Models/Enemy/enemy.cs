using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public Animator animator;
    public float speed = 3;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
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
        else if ( currentState == "AttackState")
        {

        }
    }
}
