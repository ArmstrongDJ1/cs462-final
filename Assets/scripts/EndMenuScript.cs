using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenuScript : MenuScript
{
    public GameObject winText;
    public GameObject loseText;
    public GameObject background;
    public bool hasWon = false;

    void Start(){
        Disable();
    }

    protected void OnDisable(){
        winText.SetActive(false);
        loseText.SetActive(false);
        background.SetActive(false);
    }

    protected void OnEnable(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        robot_controller playerScript = player.GetComponent<robot_controller>();
        winText.GetComponent<TextMeshProUGUI>().text = "Score: " + playerScript.score;
        background.SetActive(true);
        winText.SetActive(true);
        loseText.SetActive(true);
    }
    
    public void RestartButton(){
        Disable();
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton(){
        Disable();
        Application.Quit();
    }
}
