using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/IngredientScriptableObject")]
public class IngredientScriptableObject : ScriptableObject
{
    public Ingredient.IngredientType ingredientType;
    public string ingredientName;
    public Sprite ingredientSprite;
}
