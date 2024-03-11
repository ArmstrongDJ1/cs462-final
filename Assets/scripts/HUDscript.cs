using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    public Slider healthSlider;
    public Slider manaSlider;
    // Start is called before the first frame update
    public void setHealth(int health){
        healthSlider.value = health;
    }
    public void setMana(int mana){
        manaSlider.value = mana;
    }
}
