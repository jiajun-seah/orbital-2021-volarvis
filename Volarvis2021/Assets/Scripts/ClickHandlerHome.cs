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

  
}
