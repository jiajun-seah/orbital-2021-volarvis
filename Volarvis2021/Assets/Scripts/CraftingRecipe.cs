using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct IngredientAmount {
    public Ingredient Ingredient;
    public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<IngredientAmount> Materials;
    public List<IngredientAmount> Results;
}
