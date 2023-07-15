using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai1 : MonoBehaviour
{
    public Animator animator;
    public float detectionRadius = 5f;
    public float attackDistance = 2f;
    public float attackDelay = 1f;

    private GameObject player;
    private bool isAttacking = false;
    private float attackTimer = 1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionRadius)
        {
            if (!isAttacking)
            {
                if (distance <= attackDistance)
                {
                    if (attackTimer >= attackDelay)
                    {
                        animator.SetTrigger("Attack");
                        attackTimer = 0f;
                        isAttacking = true;
                    }
                    else
                    {
                        attackTimer += Time.deltaTime;
                    }
                }
                else
                {
                    animator.SetBool("PlayerVisible", true);
                }
            }
        }
        else
        {
            animator.SetBool("PlayerVisible", false);
            isAttacking = false;
        }
    }
}

