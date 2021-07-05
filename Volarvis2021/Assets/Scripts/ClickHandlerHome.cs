using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerHome : MonoBehaviour
{
    public Food food;
    public FoodScriptableObject type;

    public Fridge fridge;

    void Start()
    {
        fridge = Player.instance.fridge;
    }

    public void selectedFood() {
        Feeding.instance.food = food;
        Feeding.instance.type = type;

        Debug.Log("Food is selected");
    }
  
}
