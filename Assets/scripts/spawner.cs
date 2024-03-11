using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Vector3[] positions;
    public GameObject smolPrefab;
    public GameObject bigPrefab;
    private int totEnemy = 0;
    private int numSmol = 0;
    private int numBig = 0;

    void Start()
    {
        // Accessing and using elements in the array
        positions = new Vector3[4]; // Create an array of size 3

        // Initialize individual elements
        positions[0] = new Vector3(0f, .1f, 8f);
        positions[1] = new Vector3(0f, .1f, -8f);
        positions[2] = new Vector3(8f, .1f, 0f);
        positions[3] = new Vector3(-8f, .1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(totEnemy == 0){
            spawn();
        }
    }

    void spawn(){
        numSmol++;
        if(numSmol >= 5){
            numBig++;
            numSmol = 0;
        }
        for(int i = 0; i < numSmol; i++){
            Instantiate(smolPrefab, positions[Random.Range(0, 4)], Quaternion.identity);
            totEnemy++;
        }
        for(int i = 0; i < numBig; i++){
            Instantiate(bigPrefab, positions[Random.Range(0, 4)], Quaternion.identity);
            totEnemy++;
        }
    }

    public void enemyDefeated(){
        totEnemy--;
    }

}
