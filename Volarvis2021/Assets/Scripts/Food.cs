using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public FoodScriptableObject foodScriptableObject;
    public int amount;

    public Sprite getSprite()
    {
        return foodScriptableObject.foodSprite;
    }

    public override string ToString()
    {
        return foodScriptableObject.foodName;
    }

    public bool isStackable()
    {
        return true;
    }

    public IngredientScriptableObject[] getRecipe()
    {
        return new IngredientScriptableObject[] {
        foodScriptableObject.ingredient1,
        foodScriptableObject.ingredient2,
        foodScriptableObject.ingredient3,
        foodScriptableObject.ingredient4,
        };
    }


}
