using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class AddingRemovingCrockpotTest
{
    //ingredients (scriptable)
    public IngredientScriptableObject bananaScriptable;
    public IngredientScriptableObject basilScriptable;
    
    [Test]
    public void AddBananaToCrockpot_Test()
    {
        //ARANGE
        var testCrockpot= new Crockpot();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };

        //ACT
        testCrockpot.addIngredient(banana);

        //ASSERT
        Assert.That(testCrockpot.getIngredients().Count == 1);
    }

    [Test]
    public void AddTwoBananasToCrockpot_Test()
    {
        //ARANGE
        var testCrockpot = new Crockpot();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };

        //ACT
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);

        //ASSERT
        Assert.That(testCrockpot.getIngredients().Count == 2);
    }

    [Test]
    public void RemoveFromCrockpot_Test()
    {
        //ARANGE
        var testCrockpot = new Crockpot();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };
        testCrockpot.addIngredient(banana);

        //ACT

        testCrockpot.removeIngredient(banana);

        //ASSERT
        Assert.That(testCrockpot.getIngredients().Count == 0);
    }

    [Test]
    public void DoesNotAddBeyondCapacity_Test()
    {
        //ARANGE
        var testCrockpot = new Crockpot();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);

        //ACT

        testCrockpot.addIngredient(banana);

        //ASSERT
        Assert.That(testCrockpot.getIngredients().Count == 4);
    }

    [Test]
    public void ClearCrockpot_Test()
    {
        //ARANGE
        var testCrockpot = new Crockpot();
        Ingredient banana = new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 };
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);
        testCrockpot.addIngredient(banana);

        //ACT

        testCrockpot.clear();

        //ASSERT
        Assert.That(testCrockpot.getIngredients().Count == 0);
    }
}
