using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class AddingRemovingDexTest
{

    [Test]
    public void AddFoodEntry_Test()
    {
        //ARANGE
        var testDiscovery = new Discovery();

        //ACT
        testDiscovery.addDiscoveredFood(1);

        //ASSERT
        Assert.That(testDiscovery.getDiscoveredFoods()[0] == 1);
    }

    [Test]
    public void AddMultipleFoodEntry_Test()
    {
        //ARANGE
        var testDiscovery = new Discovery();

        //ACT
        testDiscovery.addDiscoveredFood(1);
        testDiscovery.addDiscoveredFood(2);

        //ASSERT
        Assert.That(testDiscovery.getDiscoveredFoods().Count == 2);
    }

    [Test]
    public void AddExistingFoodEntry_Test()
    {
        //ARANGE
        var testDiscovery = new Discovery();

        //ACT
        testDiscovery.addDiscoveredFood(1);
        testDiscovery.addDiscoveredFood(2);
        testDiscovery.addDiscoveredFood(2);

        //ASSERT
        Assert.That(testDiscovery.getDiscoveredFoods().Count == 2);
    }

    [Test]
    public void AddVolastroEntry_Test()
    {
        //ARANGE
        var testDiscovery = new Discovery();

        //ACT
        testDiscovery.addDiscoveredVolastro(1);
        //ASSERT
        Assert.That(testDiscovery.getDiscoveredVolastros()[0] == 1);
    }

    [Test]
    public void AddMultipleVolastroEntry_Test()
    {
        //ARANGE
        var testDiscovery = new Discovery();

        //ACT
        testDiscovery.addDiscoveredVolastro(2);
        testDiscovery.addDiscoveredVolastro(3);

        //ASSERT
        Assert.That(testDiscovery.getDiscoveredVolastros().Count == 3);
    }

    [Test]
    public void AddExsitingVolastroEntry_Test()
    {
        //ARANGE
        var testDiscovery = new Discovery();

        //ACT
        testDiscovery.addDiscoveredVolastro(1);
        testDiscovery.addDiscoveredVolastro(2);

        //ASSERT
        Assert.That(testDiscovery.getDiscoveredVolastros().Count == 2);
    }
}
