using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge
{
    public event EventHandler onFoodListChanged;

    private List<Food> foods;

    public Fridge()
    {
        foods = new List<Food>();
        //addFood(new Food {foodScriptableObject = FoodManager.instance.avocadoToastScriptable, amount = 1 });
        
        Debug.Log("New fridge created");
    }

    public void addFood(Food food)
    {
        if (foods.Count > 20) { }

        else { 
            foods.Add(food);
            onFoodListChanged?.Invoke(this, EventArgs.Empty);

            Debug.Log(food.ToString() + " was added to fridge.");
        }
    }

    public void removeFood(Food food)
    {
        
        foreach (Food fridgeFood in foods)
        {
            if (fridgeFood.foodScriptableObject == food.foodScriptableObject)
            {
                fridgeFood.amount -= 1;
                if (fridgeFood.amount == 0)
                {
                    foods.Remove(fridgeFood);
                }
                break;
            }
        }

        onFoodListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log(food.ToString() + " was removed.");
    }

    public List<Food> getFoods()
    {
        return foods;
    }
}
