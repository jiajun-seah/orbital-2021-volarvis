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

        /*
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Water, amount = 3 });

        
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Banana, amount = 3 });
        
        
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Basil, amount = 1 });
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Beans, amount = 1 });
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Beans, amount = 1 });
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Beans, amount = 1 });
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.VanillaBean, amount = 1 });
        
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Beans, amount = 1 });
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 });
        addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 });
        */
        

        Debug.Log("New inventory created");
    }

    public void addIngredient(Ingredient ingredient)
    {
        if (ingredient.isStackable())
        {
            bool ingredientAlreadyInInventory = false;
            foreach (Ingredient inventoryIngredient in ingredients)
            {
                if (inventoryIngredient.ingredientType == ingredient.ingredientType)
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

        Debug.Log(ingredient.ingredientType.ToString() + " was added.");
}

    public List<Ingredient> getIngredients()
    {
        return ingredients;
    }
}
