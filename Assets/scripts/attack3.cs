using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack3 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Enemy"){
            skeleton target = obj.GetComponent<skeleton>();
            target.updateHealth(100);
        }
    }
}
