using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crockpot
{
    public event EventHandler onCrockpotListChanged;

    public List<Ingredient> ingredients;

    //constants
    private static int CAPACITY = 4;

 
    public Crockpot()
    {
        ingredients = new List<Ingredient>();
        
        //addIngredient(new Ingredient { ingredientScriptableObject = IngredientManager.instance.bananaScriptable, amount = 1 });
       


        Debug.Log("New crockpot created");
    }

    public void addIngredient(Ingredient ingredient)
    {
        if (ingredients.Count > (CAPACITY-1)) { }

        else
        {
            ingredients.Add(ingredient);

            onCrockpotListChanged?.Invoke(this, EventArgs.Empty);

            //Debug.Log(ingredient.ToString() + " was added to pot");
        }
        
    }

    public void removeIngredient(Ingredient ingredient)
    {
        ingredients.Remove(ingredient);

        onCrockpotListChanged?.Invoke(this, EventArgs.Empty);

        //Debug.Log(ingredient.ToString() + " was removed to pot");

    }

    public void returnAllToInventory()
    {
        foreach (Ingredient crockpotIngredient in ingredients)
        {
            Player.instance.inventory.addIngredient(crockpotIngredient);
        }

        ingredients.Clear();

        onCrockpotListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("cleared pot");

    }

    public void clear()
    {
        
        ingredients.Clear();

        onCrockpotListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Cleared Crockpot ingredients");

    }

    public List<Ingredient> getIngredients()
    {
        return ingredients;
    }
}
