using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/IngredientScriptableObject")]
public class IngredientScriptableObject : ScriptableObject, IComparable<IngredientScriptableObject>
{
    public int dexNum;
    public Ingredient.IngredientType ingredientType;
    public string ingredientName;
    public Sprite ingredientSprite;
    public int price;

    int IComparable<IngredientScriptableObject>.CompareTo(IngredientScriptableObject other)
    {
        return String.Compare(this.ingredientName, other.ingredientName);
    }
}
