using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allow us to create a variable to store slider

public class HealthBarScript : MonoBehaviour

{
    public Slider slider;  //reference to slider
    public Gradient gradient;
    public Image fill;


    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; //
        slider.value = health; // because slider needs to start at max value (full life)
        fill.color=gradient.Evaluate(1f); //so slider starts green
    }

    

}
