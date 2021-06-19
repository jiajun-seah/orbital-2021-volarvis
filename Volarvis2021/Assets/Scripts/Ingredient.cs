using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public enum IngredientType
    {
        Banana,
        Basil,
        Beans,
        Blueberry,
        Bread,
        Butter,
        Cabbage,
        Carrot,
        Cheese,
        Chilli,
        Chocolate,
        Cream,
        Fish,
        Flour,
        Ice,
        Mushroom,
        Mussels,
        Onion,
        Potato,
        Prawn,
        Rice,
        Sausages,
        SpringOnion,
        Strawberry,
        Sugar,
        VanillaBean,
        Water
    }

    public IngredientScriptableObject ingredientScriptableObject;
    public int amount;

    public Sprite getSprite()
    {
        return ingredientScriptableObject.ingredientSprite;
    }

    public override string ToString()
    {
        return ingredientScriptableObject.ingredientName;
    }
        

    public bool isStackable()
    {
        return true;
    }
}
