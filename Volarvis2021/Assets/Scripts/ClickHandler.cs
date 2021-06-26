using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public Ingredient ingredient;
    public IngredientScriptableObject type;

    public Inventory inventory;
    public Crockpot crockpot;

    void Start()
    {
        inventory = Player.instance.inventory;
        crockpot = Player.instance.crockpot;
    }

    public void moveIngredientToCrockpot()
    {
        if (Player.instance.crockpot.ingredients.Count < 4)
        {
            inventory.removeOneIngredient(ingredient);
            crockpot.addIngredient(new Ingredient { ingredientScriptableObject = type, amount = 1 });
        }

        

        //if (Player.instance.uiInventory != null)
        //{
        //    Player.instance.uiInventory.RefreshInventoryItems();
        //}
    }

    //public void clearSlots() 
    //{
    //    Player.instance.crockpot.returnAllToInventory();
    //}
}
