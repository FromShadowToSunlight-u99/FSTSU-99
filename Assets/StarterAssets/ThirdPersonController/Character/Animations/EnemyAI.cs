using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Example logic: if the enemy is chasing the player, play the chase animation
        if (IsChasingPlayer())
        {
            animator.SetBool("IsChasing", true);
        }
        else
        {
            animator.SetBool("IsChasing", false);
        }
    }

    public bool IsChasingPlayer()
    {
        // Add your own logic to determine if the enemy is chasing the player
        // For example, you might check if the player is within a certain distance from the enemy
        return false;
    }

}

