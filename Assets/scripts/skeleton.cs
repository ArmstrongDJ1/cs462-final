using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float speed = .8f;
    public float rotationSpeed = 2f;
    private Transform playerTransform;
    public float pushForce = 10f;
    public int damage = -10;
    public int health = 10;
    public int points;
    public robot_controller playerScript;
    public spawner spawn;
    public GameObject healthPickup;
    public GameObject manaPickup;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<robot_controller>();
        GameObject mother = GameObject.FindGameObjectWithTag("Respawn");
        spawn = mother.GetComponent<spawner>();

        if (player != null)
        {
            playerTransform = player.transform;
        }
        points = health;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Rotate to face the player
            RotateTowardsPlayer();
        }
        
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player"){
            Vector3 pushDirection = (transform.position - playerTransform.position).normalized;
            rigidBody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            playerScript.updateHealth(damage);
        }
    }

    public void updateHealth(int damage){
        health -= damage;
        if(health <= 0){
            playerScript.updateScore(points);
            spawn.enemyDefeated();
            int random = Random.Range(1, 101);
            if(random < points/2){
                Instantiate(manaPickup, transform.position, Quaternion.identity);
            }
            else if(random < points){
                Instantiate(healthPickup, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
