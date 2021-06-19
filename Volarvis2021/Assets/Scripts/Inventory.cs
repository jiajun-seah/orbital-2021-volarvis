using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler onIngredientListChanged;

    private List<Ingredient> ingredients;

    public Inventory()
    {
        ingredients = new List<Ingredient>();       

        Debug.Log("New inventory created");
    }

    public void addIngredient(Ingredient ingredient)
    {
        if (ingredient.isStackable())
        {
            bool ingredientAlreadyInInventory = false;
            foreach (Ingredient inventoryIngredient in ingredients)
            {
                if (inventoryIngredient.ingredientScriptableObject == ingredient.ingredientScriptableObject)
                {
                    inventoryIngredient.amount += ingredient.amount;
                    ingredientAlreadyInInventory = true;
                }
            }
            if (!ingredientAlreadyInInventory)
            {
                ingredients.Add(ingredient);
            }
        }
        else
        {
            ingredients.Add(ingredient);
        }
        onIngredientListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log(ingredient.ToString() + " was added.");
}

    public List<Ingredient> getIngredients()
    {
        return ingredients;
    }
}
