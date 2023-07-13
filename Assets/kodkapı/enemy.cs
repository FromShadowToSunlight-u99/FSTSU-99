using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public float attackDistance = 2f;
    public float attackDelay = 1f;

    private Transform target;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackDistance)
        {
            if (!isAttacking)
            {
                if (attackTimer >= attackDelay)
                {
                    animator.SetBool("PlayerVisible", true);
                    attackTimer = 0f;
                    isAttacking = true;
                }
                else
                {
                    attackTimer += Time.deltaTime;
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


