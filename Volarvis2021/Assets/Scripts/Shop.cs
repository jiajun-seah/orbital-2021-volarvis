using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{
    private static int FOOD_COUNT_MIN = 1;
    private static int FOOD_COUNT_MAX = 62;
    private static int INGREDIENT_COUNT_MIN = 1;
    private static int INGREDIENT_COUNT_MAX = 27;

    public static IngredientScriptableObject[] INGREDIENT_LIST =
       new IngredientScriptableObject[] {
            IngredientManager.instance.bananaScriptable,
            IngredientManager.instance.basilScriptable,
            IngredientManager.instance.beansScriptable,
            IngredientManager.instance.blueberryScriptable,
            IngredientManager.instance.breadScriptable,
            IngredientManager.instance.butterScriptable,
            IngredientManager.instance.cabbageScriptable,
            IngredientManager.instance.carrotScriptable,
            IngredientManager.instance.cheeseScriptable,
            IngredientManager.instance.chilliScriptable,
            IngredientManager.instance.chocolateScriptable,
            IngredientManager.instance.creamScriptable,
            IngredientManager.instance.fishScriptable,
            IngredientManager.instance.flourScriptable,
            IngredientManager.instance.iceScriptable,
            IngredientManager.instance.mushroomScriptable,
            IngredientManager.instance.musselsScriptable,
            IngredientManager.instance.onionScriptable,
            IngredientManager.instance.potatoScriptable,
            IngredientManager.instance.prawnScriptable,
            IngredientManager.instance.riceScriptable,
            IngredientManager.instance.sausagesScriptable,
            IngredientManager.instance.springOnionScriptable,
            IngredientManager.instance.strawberryScriptable,
            IngredientManager.instance.sugarScriptable,
            IngredientManager.instance.vanillaBeanScriptable,
            IngredientManager.instance.waterScriptable
       };

    public static FoodScriptableObject[] FOOD_LIST =
        new FoodScriptableObject[] {
            //0-10
            FoodManager.instance.wetGoopScriptable,
            FoodManager.instance.avocadoToastScriptable,
            FoodManager.instance.blackberryJellyScriptable,
            FoodManager.instance.blueberryCakeScriptable,
            FoodManager.instance.blueberryPieScriptable,
            FoodManager.instance.blueberrySconeScriptable,
            FoodManager.instance.bouillabaiseScriptable,
            FoodManager.instance.bubbleTeaScriptable,
            FoodManager.instance.buffaloWingsScriptable,
            FoodManager.instance.candyCanesScriptable,
            FoodManager.instance.cevicheScriptable,

            //11-20
            FoodManager.instance.chocolateDonutsScriptable,
            FoodManager.instance.chocolateFroyoScriptable,
            FoodManager.instance.chocolateIceCreamScriptable,
            FoodManager.instance.cinnamonRollsScriptable,
            FoodManager.instance.crawfishBisqueScriptable,
            FoodManager.instance.escargotScriptable,
            FoodManager.instance.fishAndChipsScriptable,
            FoodManager.instance.fishCurryScriptable,
            FoodManager.instance.fruitbarScriptable,
            FoodManager.instance.fruitcakeScriptable,

            //21-30
            FoodManager.instance.gardenSaladScriptable,
            FoodManager.instance.garlicChickenScriptable,
            FoodManager.instance.greenCurryScriptable,
            FoodManager.instance.greenStuffedPeppersScriptable,
            FoodManager.instance.hamburgerScriptable,
            FoodManager.instance.honeyPancakeScriptable,
            FoodManager.instance.jellyBeansScriptable,
            FoodManager.instance.keyLimePieScriptable,
            FoodManager.instance.lagsanaScriptable,
            FoodManager.instance.lemonCakeScriptable,

            //31-40
            FoodManager.instance.bananaFroyoScriptable,
            FoodManager.instance.liquoriceCandyScriptable,
            FoodManager.instance.lotusRootSoupScriptable,
            FoodManager.instance.lycheeJellyScriptable,
            FoodManager.instance.makiSushiScriptable,
            FoodManager.instance.malaHotpotScriptable,
            FoodManager.instance.popsiclesScriptable,
            FoodManager.instance.raspberryPieScriptable,
            FoodManager.instance.ratatouilleScriptable,
            FoodManager.instance.redStuffedPeppersScriptable,

            //41-50
            FoodManager.instance.rosemaryChickenScriptable,
            FoodManager.instance.creamySausagesScriptable,
            FoodManager.instance.seafoodPancakeScriptable,
            FoodManager.instance.shavedIceScriptable,
            FoodManager.instance.shrimpPastaScriptable,
            FoodManager.instance.smoothieScriptable,
            FoodManager.instance.sobaScriptable,
            FoodManager.instance.squidInkPastaScriptable,
            FoodManager.instance.strawberryCakeScriptable,
            FoodManager.instance.strawberryCupcakeScriptable,

            //51-60
            FoodManager.instance.strawberryDonutsScriptable,
            FoodManager.instance.strawberryFroyoScriptable,
            FoodManager.instance.strawberryIceCreamScriptable,
            FoodManager.instance.strawberryJellyScriptable,
            FoodManager.instance.strawberrySconeScriptable,
            FoodManager.instance.tomYumSoupScriptable,
            FoodManager.instance.tortillaChipsScriptable,
            FoodManager.instance.vanillaCupcakeScriptable,
            FoodManager.instance.vanillaDonutsScriptable,
            FoodManager.instance.chocolateCupcakesScriptable,

            //61-62
            FoodManager.instance.vanillaIceCreamScriptable,
            FoodManager.instance.yellowStuffedPeppersScriptable,
        };


    public event EventHandler onIngredientListChanged;
    public event EventHandler onFoodListChanged;

    private List<Ingredient> ingredients;
    private List<Food> foods;

    public Shop()
    {
        ingredients = new List<Ingredient>();
        foods = new List<Food>();

        Debug.Log("New inventory created");
    }

    public void refreshIngredientStock()
    {
       
        DateTime moment = DateTime.Now;
        int seed = moment.Year + moment.Month + moment.Day;
        Random.InitState(seed);
        for (int i = 0; i < 4; i++)
        {
            IngredientScriptableObject ingredient1 = INGREDIENT_LIST[Random.Range(INGREDIENT_COUNT_MIN - 1, INGREDIENT_COUNT_MAX - 1)];
            ingredients.Add(new Ingredient { ingredientScriptableObject = ingredient1, amount = 1 });
        }
        onIngredientListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Ingredient stock refreshed: " 
            + ingredients[0].ToString() + " "
            + ingredients[1].ToString() + " "
            + ingredients[2].ToString() + " "
            + ingredients[3].ToString() + " ");
    }

    public void refreshFoodStock()
    {

        DateTime moment = DateTime.Now;
        int seed = moment.Year + moment.Month + moment.Day;
        Random.InitState(seed);
        for (int i = 0; i < 4; i++)
        {
            FoodScriptableObject food1 = FOOD_LIST[Random.Range(FOOD_COUNT_MIN - 1, FOOD_COUNT_MAX - 1)];
            foods.Add(new Food { foodScriptableObject = food1, amount = 1 });
        }
        onFoodListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Food stock refreshed: "
            + foods[0].ToString() + " "
            + foods[1].ToString() + " "
            + foods[2].ToString() + " "
            + foods[3].ToString() + " ");
    }

    public List<Ingredient> getIngredients()
    {
        return ingredients;
    }

    public List<Food> getFoods()
    {
        return foods;
    }
}
