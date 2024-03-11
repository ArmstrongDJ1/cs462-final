using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class gameEnder : MonoBehaviour{
    abstract protected string endOnTouch {get;}

    abstract protected void OnGameEnd();

    private void OnCollisionEnter(Collision collision){
        GameObject obj = collision.gameObject;

        if(obj.tag == endOnTouch){
            Time.timeScale = 0;
            OnGameEnd();
        }
    }
}
