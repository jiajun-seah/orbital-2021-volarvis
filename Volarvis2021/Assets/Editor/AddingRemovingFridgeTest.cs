using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class AddingRemovingFridgeTest
{
    //food (scriptable)

    //0-10
    public FoodScriptableObject wetGoopScriptable;
    public FoodScriptableObject avocadoToastScriptable;
    public FoodScriptableObject blackberryJellyScriptable;

    [Test]
    public void AddWetGoopToFridge_Test()
    {
        //ARANGE
        var testFridge = new Fridge();
        Food wetGoop = new Food { foodScriptableObject = wetGoopScriptable, amount = 1 };

        //ACT
        testFridge.addFood(wetGoop);

        //ASSERT
        Assert.That(testFridge.getFoods().Count == 1);
    }

    [Test]
    public void AddMultipleToFridge_Test()
    {
        //ARANGE
        var testFridge = new Fridge();
        Food wetGoop = new Food { foodScriptableObject = wetGoopScriptable, amount = 1 };
        Food avocadoToast = new Food { foodScriptableObject = avocadoToastScriptable, amount = 1 };
        Food blackberryJelly = new Food { foodScriptableObject = blackberryJellyScriptable, amount = 1 };


        //ACT
        testFridge.addFood(wetGoop);
        testFridge.addFood(avocadoToast);
        testFridge.addFood(blackberryJelly);


        //ASSERT
        Assert.That(testFridge.getFoods().Count == 3);
    }

    [Test]
    public void AddDuplicatesToFridge_Test()
    {
        //ARANGE
        var testFridge = new Fridge();
        Food wetGoop = new Food { foodScriptableObject = wetGoopScriptable, amount = 1 };
        Food avocadoToast = new Food { foodScriptableObject = avocadoToastScriptable, amount = 1 };
        Food blackberryJelly = new Food { foodScriptableObject = blackberryJellyScriptable, amount = 1 };


        //ACT
        testFridge.addFood(wetGoop);
        testFridge.addFood(avocadoToast);
        testFridge.addFood(blackberryJelly);
        testFridge.addFood(wetGoop);
        testFridge.addFood(wetGoop);

        //ASSERT
        Assert.That(testFridge.getFoods().Count == 5);
    }

    [Test]
    public void RemoveFromFridge_Test()
    {
        //ARANGE
        var testFridge = new Fridge();
        Food wetGoop = new Food { foodScriptableObject = wetGoopScriptable, amount = 1 };
        Food avocadoToast = new Food { foodScriptableObject = avocadoToastScriptable, amount = 1 };
        testFridge.addFood(wetGoop);
        testFridge.addFood(avocadoToast);

        //ACT

        testFridge.removeFood(wetGoop);

        //ASSERT
        Assert.That(testFridge.getFoods().Count == 1);
    }

    [Test]
    public void ClearFridge_Test()
    {
        //ARANGE
        var testFridge = new Fridge();
        Food wetGoop = new Food { foodScriptableObject = wetGoopScriptable, amount = 1 };
        Food avocadoToast = new Food { foodScriptableObject = avocadoToastScriptable, amount = 1 };
        Food blackberryJelly = new Food { foodScriptableObject = blackberryJellyScriptable, amount = 1 };
        testFridge.addFood(wetGoop);
        testFridge.addFood(avocadoToast);
        testFridge.addFood(blackberryJelly);
        testFridge.addFood(wetGoop);
        testFridge.addFood(wetGoop);


        //ACT
        testFridge.clear();

        //ASSERT
        Assert.That(testFridge.getFoods().Count == 0);
    }
}
