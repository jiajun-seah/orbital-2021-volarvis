using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FoodScriptableObject")]
public class FoodScriptableObject : ScriptableObject
{
    [Range(0, 62)]
    public int dexNum;
    public string foodName;

    [Range(0, 100)]
    public int hungerVal;

    [Range(0, 100)]
    public int happinessVal;

    public int price;

    [Range(0, 6)]
    public float rarity;

    //recipe
    public IngredientScriptableObject ingredient1;
    public IngredientScriptableObject ingredient2;
    public IngredientScriptableObject ingredient3;
    public IngredientScriptableObject ingredient4;

    //trait values
    public int fieryVal;
    public int icyVal;
    public int magicalVal;
    public int nauticalVal;
    public int aerialVal;
    public int terraVal;

    public Sprite foodSprite;
    public Sprite foodShadowSprite;
}