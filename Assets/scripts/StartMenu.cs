using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MenuScript{
    void Start(){
        Enable();
        Debug.Log("Starting!");
    }

    public void StartButton(){
        Debug.Log("Clicked!");
        // Disable();
        // UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        // Debug.Log("Starting!");
    }

}