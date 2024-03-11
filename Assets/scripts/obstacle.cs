using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : gameEnder{
    public EndMenuScript endMenu;

    override protected string endOnTouch {
        get {return "Player";}
    }

    override protected void OnGameEnd(){
        endMenu.hasWon = false;
        endMenu.Enable();
    }
}