using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_controller : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    public GameObject robotCamera;
    public EndMenuScript endMenu;
    public HUDscript HUD;
    public GameObject atk1;
    public GameObject atk2;
    public GameObject atk3;
    public float walkSpeed = 1f;
    private float input_right = 0;
    private float input_forward = 0;
    public float jumpStrength;
    private int onGround = 0;
    private bool input_jump = false;
    public int health = 100;
    public int mana = 100;
    public Transform firePoint;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input_right = Input.GetAxis("Horizontal");
        input_forward = Input.GetAxis("Vertical");

        if(onGround > 0 && Input.GetButtonDown("Jump")){
            input_jump = true;
        }
        if(health <= 0){
            endMenu.Enable();
        }
        if (Input.GetMouseButtonDown(0))
        {
            attack1();
        }
        if (Input.GetMouseButtonDown(1) && mana >= 5)
        {
            attack2();
        }
        if (Input.GetMouseButtonDown(2) && mana >=50)
        {
            attack3();
        }
        HUD.setHealth(health);
        HUD.setMana(mana);
    }

    void FixedUpdate(){
        Vector3 forward = Vector3.ProjectOnPlane(robotCamera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(robotCamera.transform.right, Vector3.up).normalized;;

        Vector3 movement = input_right*right + input_forward*forward;
        movement = walkSpeed * movement.normalized;
        bool isMoving = movement.magnitude > 0;

        rigidBody.MovePosition(rigidBody.position + movement*Time.deltaTime);

        if(isMoving){
            transform.LookAt(transform.position + forward);
        }

        animator.SetBool("isWalking", isMoving);

        Vector3 up = transform.up;
        if(input_jump){
            rigidBody.AddForce(jumpStrength*up, ForceMode.Impulse);
            input_jump = false;
            animator.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter(Collision collision){
        GameObject obj = collision.gameObject;
        if(obj.tag == "Ground"){
            onGround += 1;
            animator.SetBool("isJumping", false);
        }
        if(obj.tag == "health"){
            updateHealth(10);
            Destroy(obj);
        }
        if(obj.tag == "mana"){
            updateMana(10);
            Destroy(obj);
        }
    }

    void OnCollisionExit(Collision collision){
        GameObject obj = collision.gameObject;
        if(obj.tag == "Ground"){
            onGround -= 1;
            if(onGround < 0) onGround = 0;
        }
    }

    public void updateHealth(int update){
        health += update;
        if(health >= 100){
            health = 100;
        }
    }

    public void updateMana(int update){
        mana += update;
        if(mana >= 100){
            mana = 100;
        }
        if(mana <= 0){
            mana = 0;
        }
    }

    public void updateScore(int update){
        score += update;
    }

    void attack1()
    {
        // Instantiate a new ball at the fire point
        GameObject newBall = Instantiate(atk1, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the ball
        Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (ballRigidbody != null)
        {
            // Fire the ball in the forward direction with a specified force
            ballRigidbody.AddForce(firePoint.forward * 10f, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the ball prefab.");
        }
    }
    void attack2()
    {
        updateMana(-5);
        GameObject newBall = Instantiate(atk2, firePoint.position, firePoint.rotation);
    }

    void attack3(){
        updateMana(-50);
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameObject anchor = Instantiate(atk3, enemy.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        Destroy(anchor, 3f);
    }
}
