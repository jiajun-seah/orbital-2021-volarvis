using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class AddingRemovingInventoryTest
{
    //ingredients (scriptable)
    public IngredientScriptableObject bananaScriptable;
    public IngredientScriptableObject basilScriptable;

    [Test]
    public void AddBananaToInventory_Test()
    {
        //ARANGE
        var testInventory = new Inventory();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };

        //ACT
        testInventory.addIngredient(banana);

        //ASSERT
        Assert.That(testInventory.getIngredients().Count == 1);
    }

    [Test]
    public void AddTwoBananasToInventory_Test()
    {
        //ARANGE
        var testInventory = new Inventory();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };

        //ACT
        testInventory.addIngredient(banana);
        testInventory.addIngredient(banana);

        //ASSERT
        Assert.That(testInventory.getIngredients()[0].getQty() == 2);
    }

    [Test]
    public void RemoveFromInventory_Test()
    {
        //ARANGE
        var testInventory = new Inventory();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };
        Ingredient basil = new Ingredient { ingredientScriptableObject = basilScriptable, amount = 1 };
        testInventory.addIngredient(banana);

        //ACT

        testInventory.removeOneIngredient(banana);

        //ASSERT
        Assert.That(testInventory.getIngredients()[0].getQty() == 0);
    }
}
