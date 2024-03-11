using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2 : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;

    void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        target = enemy.transform;
    }

    void Update()
    {
        // Check if the target is set
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Set the velocity to move the ball in the direction of the enemy
            GetComponent<Rigidbody>().velocity = direction * speed;
        }
    }

    // Handle collisions with the ball
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Enemy"){
            skeleton target = obj.GetComponent<skeleton>();
            target.updateHealth(5);
        }
        if(obj.tag != "Player"){
            Destroy(gameObject);
        }
    }
}

