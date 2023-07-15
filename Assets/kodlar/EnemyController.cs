using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * moveSpeed);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}



