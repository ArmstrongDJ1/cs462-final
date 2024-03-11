using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : gameEnder{
    public EndMenuScript endMenu;

    override protected string endOnTouch {
        get {return "Player";}
    }

    override protected void OnGameEnd(){
        endMenu.hasWon = true;
        endMenu.Enable();
    }
}