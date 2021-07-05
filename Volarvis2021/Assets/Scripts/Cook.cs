using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour
{
    //constants
    private static int REQUIRED = 4;


    //reference to insufficient ingredients message
    [SerializeField] private Transform ui_cooked;
    [SerializeField] private Transform cooked_filler;
    [SerializeField] private Transform insufficientIngredientsMessage;
    [SerializeField] private Transform fridgeFullMessage;
    [SerializeField] private Button cook_btn;
    [SerializeField] private Button clear_btn;

    //properties for CookedFood panel
    private Food cookedFood;
    private Transform cookedFoodContainer;
    private Transform cookedFoodTemplate;
    


    //reference to FoodScriptableObject
    //0-10
    static FoodScriptableObject food0 = FoodManager.instance.wetGoopScriptable;
    static FoodScriptableObject food1 = FoodManager.instance.avocadoToastScriptable;
    static FoodScriptableObject food2 = FoodManager.instance.blackberryJellyScriptable;
    static FoodScriptableObject food3 = FoodManager.instance.blueberryCakeScriptable;
    static FoodScriptableObject food4 = FoodManager.instance.blueberryPieScriptable;
    static FoodScriptableObject food5 = FoodManager.instance.blueberrySconeScriptable;
    static FoodScriptableObject food6 = FoodManager.instance.bouillabaiseScriptable;
    static FoodScriptableObject food7 = FoodManager.instance.bubbleTeaScriptable;
    static FoodScriptableObject food8 = FoodManager.instance.buffaloWingsScriptable;
    static FoodScriptableObject food9 = FoodManager.instance.candyCanesScriptable;
    static FoodScriptableObject food10 = FoodManager.instance.cevicheScriptable;

    //11-20
    static FoodScriptableObject food11 = FoodManager.instance.chocolateDonutsScriptable;
    static FoodScriptableObject food12 = FoodManager.instance.chocolateFroyoScriptable;
    static FoodScriptableObject food13 = FoodManager.instance.chocolateIceCreamScriptable;
    static FoodScriptableObject food14 = FoodManager.instance.cinnamonRollsScriptable;
    static FoodScriptableObject food15 = FoodManager.instance.crawfishBisqueScriptable;
    static FoodScriptableObject food16 = FoodManager.instance.escargotScriptable;
    static FoodScriptableObject food17 = FoodManager.instance.fishAndChipsScriptable;
    static FoodScriptableObject food18 = FoodManager.instance.fishCurryScriptable;
    static FoodScriptableObject food19 = FoodManager.instance.fruitbarScriptable;
    static FoodScriptableObject food20 = FoodManager.instance.fruitcakeScriptable;

    //21-30
    static FoodScriptableObject food21 = FoodManager.instance.gardenSaladScriptable;
    static FoodScriptableObject food22 = FoodManager.instance.garlicChickenScriptable;
    static FoodScriptableObject food23 = FoodManager.instance.greenCurryScriptable;
    static FoodScriptableObject food24 = FoodManager.instance.greenStuffedPeppersScriptable;
    static FoodScriptableObject food25 = FoodManager.instance.hamburgerScriptable;
    static FoodScriptableObject food26 = FoodManager.instance.honeyPancakeScriptable;
    static FoodScriptableObject food27 = FoodManager.instance.jellyBeansScriptable;
    static FoodScriptableObject food28 = FoodManager.instance.keyLimePieScriptable;
    static FoodScriptableObject food29 = FoodManager.instance.lagsanaScriptable;
    static FoodScriptableObject food30 = FoodManager.instance.lemonCakeScriptable;

    //31-40
    static FoodScriptableObject food31 = FoodManager.instance.bananaFroyoScriptable;
    static FoodScriptableObject food32 = FoodManager.instance.liquoriceCandyScriptable;
    static FoodScriptableObject food33 = FoodManager.instance.lotusRootSoupScriptable;
    static FoodScriptableObject food34 = FoodManager.instance.lycheeJellyScriptable;
    static FoodScriptableObject food35 = FoodManager.instance.makiSushiScriptable;
    static FoodScriptableObject food36 = FoodManager.instance.malaHotpotScriptable;
    static FoodScriptableObject food37 = FoodManager.instance.popsiclesScriptable;
    static FoodScriptableObject food38 = FoodManager.instance.raspberryPieScriptable;
    static FoodScriptableObject food39 = FoodManager.instance.ratatouilleScriptable;
    static FoodScriptableObject food40 = FoodManager.instance.redStuffedPeppersScriptable;

    //41-50
    static FoodScriptableObject food41 = FoodManager.instance.rosemaryChickenScriptable;
    static FoodScriptableObject food42 = FoodManager.instance.creamySausagesScriptable;
    static FoodScriptableObject food43 = FoodManager.instance.seafoodPancakeScriptable;
    static FoodScriptableObject food44 = FoodManager.instance.shavedIceScriptable;
    static FoodScriptableObject food45 = FoodManager.instance.shrimpPastaScriptable;
    static FoodScriptableObject food46 = FoodManager.instance.smoothieScriptable;
    static FoodScriptableObject food47 = FoodManager.instance.sobaScriptable;
    static FoodScriptableObject food48 = FoodManager.instance.squidInkPastaScriptable;
    static FoodScriptableObject food49 = FoodManager.instance.strawberryCakeScriptable;
    static FoodScriptableObject food50 = FoodManager.instance.strawberryCupcakeScriptable;

    //51-60
    static FoodScriptableObject food51 = FoodManager.instance.strawberryDonutsScriptable;
    static FoodScriptableObject food52 = FoodManager.instance.strawberryFroyoScriptable;
    static FoodScriptableObject food53 = FoodManager.instance.strawberryIceCreamScriptable;
    static FoodScriptableObject food54 = FoodManager.instance.strawberryJellyScriptable;
    static FoodScriptableObject food55 = FoodManager.instance.strawberrySconeScriptable;
    static FoodScriptableObject food56 = FoodManager.instance.tomYumSoupScriptable;
    static FoodScriptableObject food57 = FoodManager.instance.tortillaChipsScriptable;
    static FoodScriptableObject food58 = FoodManager.instance.vanillaCupcakeScriptable;
    static FoodScriptableObject food59 = FoodManager.instance.vanillaDonutsScriptable;
    static FoodScriptableObject food60 = FoodManager.instance.chocolateCupcakesScriptable;

    //61-70
    static FoodScriptableObject food61 = FoodManager.instance.vanillaIceCreamScriptable;
    static FoodScriptableObject food62 = FoodManager.instance.yellowStuffedPeppersScriptable;


    //recipe stored as (potentially unsorted) array
    Dictionary<int, IngredientScriptableObject[]> recipeDict = new Dictionary<int, IngredientScriptableObject[]>()
    {

        //1-10
        { 1, new IngredientScriptableObject[] { food1.ingredient1, food1.ingredient2, food1.ingredient3, food1.ingredient4}},
        { 2, new IngredientScriptableObject[] { food2.ingredient1, food2.ingredient2, food2.ingredient3, food2.ingredient4}},
        { 3, new IngredientScriptableObject[] { food3.ingredient1, food3.ingredient2, food3.ingredient3, food3.ingredient4}},
        { 4, new IngredientScriptableObject[] { food4.ingredient1, food4.ingredient2, food4.ingredient3, food4.ingredient4}},
        { 5, new IngredientScriptableObject[] { food5.ingredient1, food5.ingredient2, food5.ingredient3, food5.ingredient4}},
        { 6, new IngredientScriptableObject[] { food6.ingredient1, food6.ingredient2, food6.ingredient3, food6.ingredient4}},
        { 7, new IngredientScriptableObject[] { food7.ingredient1, food7.ingredient2, food7.ingredient3, food7.ingredient4}},
        { 8, new IngredientScriptableObject[] { food8.ingredient1, food8.ingredient2, food8.ingredient3, food8.ingredient4}},
        { 9, new IngredientScriptableObject[] { food9.ingredient1, food9.ingredient2, food9.ingredient3, food9.ingredient4}},
        { 10, new IngredientScriptableObject[] { food10.ingredient1, food10.ingredient2, food10.ingredient3, food10.ingredient4}},
        

        //11-20
        { 11, new IngredientScriptableObject[] { food11.ingredient1, food11.ingredient2, food11.ingredient3, food11.ingredient4}},
        { 12, new IngredientScriptableObject[] { food12.ingredient1, food12.ingredient2, food12.ingredient3, food12.ingredient4}},
        { 13, new IngredientScriptableObject[] { food13.ingredient1, food13.ingredient2, food13.ingredient3, food13.ingredient4}},
        { 14, new IngredientScriptableObject[] { food14.ingredient1, food14.ingredient2, food14.ingredient3, food14.ingredient4}},
        { 15, new IngredientScriptableObject[] { food15.ingredient1, food15.ingredient2, food15.ingredient3, food15.ingredient4}},
        { 16, new IngredientScriptableObject[] { food16.ingredient1, food16.ingredient2, food16.ingredient3, food16.ingredient4}},
        { 17, new IngredientScriptableObject[] { food17.ingredient1, food17.ingredient2, food17.ingredient3, food17.ingredient4}},
        { 18, new IngredientScriptableObject[] { food18.ingredient1, food18.ingredient2, food18.ingredient3, food18.ingredient4}},
        { 19, new IngredientScriptableObject[] { food19.ingredient1, food19.ingredient2, food19.ingredient3, food19.ingredient4}},
        { 20, new IngredientScriptableObject[] { food20.ingredient1, food20.ingredient2, food20.ingredient3, food20.ingredient4}},

        //21-30
        { 21, new IngredientScriptableObject[] { food21.ingredient1, food21.ingredient2, food21.ingredient3, food21.ingredient4}},
        { 22, new IngredientScriptableObject[] { food22.ingredient1, food22.ingredient2, food22.ingredient3, food22.ingredient4}},
        { 23, new IngredientScriptableObject[] { food23.ingredient1, food23.ingredient2, food23.ingredient3, food23.ingredient4}},
        { 24, new IngredientScriptableObject[] { food24.ingredient1, food24.ingredient2, food24.ingredient3, food24.ingredient4}},
        { 25, new IngredientScriptableObject[] { food25.ingredient1, food25.ingredient2, food25.ingredient3, food25.ingredient4}},
        { 26, new IngredientScriptableObject[] { food26.ingredient1, food26.ingredient2, food26.ingredient3, food26.ingredient4}},
        { 27, new IngredientScriptableObject[] { food27.ingredient1, food27.ingredient2, food27.ingredient3, food27.ingredient4}},
        { 28, new IngredientScriptableObject[] { food28.ingredient1, food28.ingredient2, food28.ingredient3, food28.ingredient4}},
        { 29, new IngredientScriptableObject[] { food29.ingredient1, food29.ingredient2, food29.ingredient3, food29.ingredient4}},
        { 30, new IngredientScriptableObject[] { food30.ingredient1, food30.ingredient2, food30.ingredient3, food30.ingredient4}},

        //31-40
        { 31, new IngredientScriptableObject[] { food31.ingredient1, food31.ingredient2, food31.ingredient3, food31.ingredient4}},
        { 32, new IngredientScriptableObject[] { food32.ingredient1, food32.ingredient2, food32.ingredient3, food32.ingredient4}},
        { 33, new IngredientScriptableObject[] { food33.ingredient1, food33.ingredient2, food33.ingredient3, food33.ingredient4}},
        { 34, new IngredientScriptableObject[] { food34.ingredient1, food34.ingredient2, food34.ingredient3, food34.ingredient4}},
        { 35, new IngredientScriptableObject[] { food35.ingredient1, food35.ingredient2, food35.ingredient3, food35.ingredient4}},
        { 36, new IngredientScriptableObject[] { food36.ingredient1, food36.ingredient2, food36.ingredient3, food36.ingredient4}},
        { 37, new IngredientScriptableObject[] { food37.ingredient1, food37.ingredient2, food37.ingredient3, food37.ingredient4}},
        { 38, new IngredientScriptableObject[] { food38.ingredient1, food38.ingredient2, food38.ingredient3, food38.ingredient4}},
        { 39, new IngredientScriptableObject[] { food39.ingredient1, food39.ingredient2, food39.ingredient3, food39.ingredient4}},
        { 40, new IngredientScriptableObject[] { food40.ingredient1, food40.ingredient2, food40.ingredient3, food40.ingredient4}},

        //41-50
        { 41, new IngredientScriptableObject[] { food41.ingredient1, food41.ingredient2, food41.ingredient3, food41.ingredient4}},
        { 42, new IngredientScriptableObject[] { food42.ingredient1, food42.ingredient2, food42.ingredient3, food42.ingredient4}},
        { 43, new IngredientScriptableObject[] { food43.ingredient1, food43.ingredient2, food43.ingredient3, food43.ingredient4}},
        { 44, new IngredientScriptableObject[] { food44.ingredient1, food44.ingredient2, food44.ingredient3, food44.ingredient4}},
        { 45, new IngredientScriptableObject[] { food45.ingredient1, food45.ingredient2, food45.ingredient3, food45.ingredient4}},
        { 46, new IngredientScriptableObject[] { food46.ingredient1, food46.ingredient2, food46.ingredient3, food46.ingredient4}},
        { 47, new IngredientScriptableObject[] { food47.ingredient1, food47.ingredient2, food47.ingredient3, food47.ingredient4}},
        { 48, new IngredientScriptableObject[] { food48.ingredient1, food48.ingredient2, food48.ingredient3, food48.ingredient4}},
        { 49, new IngredientScriptableObject[] { food49.ingredient1, food49.ingredient2, food49.ingredient3, food49.ingredient4}},
        { 50, new IngredientScriptableObject[] { food50.ingredient1, food50.ingredient2, food50.ingredient3, food50.ingredient4}},

        //51-60
        { 51, new IngredientScriptableObject[] { food51.ingredient1, food51.ingredient2, food51.ingredient3, food51.ingredient4}},
        { 52, new IngredientScriptableObject[] { food52.ingredient1, food52.ingredient2, food52.ingredient3, food52.ingredient4}},
        { 53, new IngredientScriptableObject[] { food53.ingredient1, food53.ingredient2, food53.ingredient3, food53.ingredient4}},
        { 54, new IngredientScriptableObject[] { food54.ingredient1, food54.ingredient2, food54.ingredient3, food54.ingredient4}},
        { 55, new IngredientScriptableObject[] { food55.ingredient1, food55.ingredient2, food55.ingredient3, food55.ingredient4}},
        { 56, new IngredientScriptableObject[] { food56.ingredient1, food56.ingredient2, food56.ingredient3, food56.ingredient4}},
        { 57, new IngredientScriptableObject[] { food57.ingredient1, food57.ingredient2, food57.ingredient3, food57.ingredient4}},
        { 58, new IngredientScriptableObject[] { food58.ingredient1, food58.ingredient2, food58.ingredient3, food58.ingredient4}},
        { 59, new IngredientScriptableObject[] { food59.ingredient1, food59.ingredient2, food59.ingredient3, food59.ingredient4}},
        { 60, new IngredientScriptableObject[] { food60.ingredient1, food60.ingredient2, food60.ingredient3, food60.ingredient4}},

        //61-62
        { 61, new IngredientScriptableObject[] { food61.ingredient1, food61.ingredient2, food61.ingredient3, food61.ingredient4}},
        { 62, new IngredientScriptableObject[] { food62.ingredient1, food62.ingredient2, food62.ingredient3, food62.ingredient4}}
    };
 

    private void Awake()
    {
        cookedFoodContainer = transform.Find("cookedContainer");
        cookedFoodTemplate = cookedFoodContainer.Find("cookedFoodTemplate");
    }
 

    public void cook()
    {
        Crockpot crockpot = Player.instance.crockpot;
        
        int foodDexNum = 0;
        if (crockpot.ingredients.Count < REQUIRED) 
        {
            insufficientIngredientsMessage.gameObject.SetActive(true);
            cook_btn.interactable = false;
            clear_btn.interactable = false;
        }
        else if (Player.instance.fridge.getFoods().Count >= 20)
        {
            fridgeFullMessage.gameObject.SetActive(true);
            cook_btn.interactable = false;
            clear_btn.interactable = false;
        }
        else
        {

            //unhide cooked ui and related filler text
            ui_cooked.gameObject.SetActive(true);
            cooked_filler.gameObject.SetActive(true);


            IngredientScriptableObject[] checkCrockpot = crockpot.ingredients.Select(ingredient => ingredient.ingredientScriptableObject).ToArray();

            Array.Sort(checkCrockpot);


            foreach (KeyValuePair<int, IngredientScriptableObject[]> entry in recipeDict)
            {
                if (entry.Value.SequenceEqual(checkCrockpot))
                {
                    foodDexNum = entry.Key;
                    break;
                }
            }

            //add to fridge based on switch case
            switch (foodDexNum)
            {
                default:
                    break;
                case 0:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food0, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food0, amount = 1 };
                    break;
                case 1:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food1, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food1, amount = 1 };
                    break;
                case 2:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food2, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food2, amount = 1 };
                    break;
                case 3:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food3, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food3, amount = 1 };
                    break;
                case 4:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food4, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food4, amount = 1 };
                    break;
                case 5:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food5, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food5, amount = 1 };
                    break;
                case 6:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food6, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food6, amount = 1 };
                    break;
                case 7:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food7, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food7, amount = 1 };
                    break;
                case 8:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food8, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food8, amount = 1 };
                    break;
                case 9:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food9, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food9, amount = 1 };
                    break;
                case 10:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food10, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food10, amount = 1 };
                    break;
                case 11:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food11, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food11, amount = 1 };
                    break;
                case 12:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food12, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food12, amount = 1 };
                    break;
                case 13:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food13, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food13, amount = 1 };
                    break;
                case 14:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food14, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food14, amount = 1 };
                    break;
                case 15:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food15, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food15, amount = 1 };
                    break;
                case 16:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food16, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food16, amount = 1 };
                    break;
                case 17:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food17, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food17, amount = 1 };
                    break;
                case 18:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food18, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food18, amount = 1 };
                    break;
                case 19:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food19, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food19, amount = 1 };
                    break;
                case 20:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food20, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food20, amount = 1 };
                    break;
                case 21:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food21, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food21, amount = 1 };
                    break;
                case 22:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food22, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food22, amount = 1 };
                    break;
                case 23:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food23, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food23, amount = 1 };
                    break;
                case 24:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food24, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food24, amount = 1 };
                    break;
                case 25:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food25, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food25, amount = 1 };
                    break;
                case 26:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food26, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food26, amount = 1 };
                    break;
                case 27:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food27, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food27, amount = 1 };
                    break;
                case 28:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food28, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food28, amount = 1 };
                    break;
                case 29:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food29, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food29, amount = 1 };
                    break;
                case 30:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food30, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food30, amount = 1 };
                    break;
                case 31:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food31, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food31, amount = 1 };
                    break;
                case 32:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food32, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food32, amount = 1 };
                    break;
                case 33:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food33, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food33, amount = 1 };
                    break;
                case 34:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food34, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food34, amount = 1 };
                    break;
                case 35:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food35, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food35, amount = 1 };
                    break;
                case 36:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food36, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food36, amount = 1 };
                    break;
                case 37:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food37, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food37, amount = 1 };
                    break;
                case 38:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food38, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food38, amount = 1 };
                    break;
                case 39:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food39, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food39, amount = 1 };
                    break;
                case 40:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food40, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food40, amount = 1 };
                    break;
                case 41:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food41, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food41, amount = 1 };
                    break;
                case 42:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food42, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food42, amount = 1 };
                    break;
                case 43:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food43, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food43, amount = 1 };
                    break;
                case 44:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food44, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food44, amount = 1 };
                    break;
                case 45:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food45, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food45, amount = 1 };
                    break;
                case 46:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food46, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food46, amount = 1 };
                    break;
                case 47:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food47, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food47, amount = 1 };
                    break;
                case 48:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food48, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food48, amount = 1 };
                    break;
                case 49:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food49, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food49, amount = 1 };
                    break;
                case 50:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food50, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food50, amount = 1 };
                    break;
                case 51:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food51, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food51, amount = 1 };
                    break;
                case 52:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food52, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food52, amount = 1 };
                    break;
                case 53:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food53, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food53, amount = 1 };
                    break;
                case 54:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food54, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food54, amount = 1 };
                    break;
                case 55:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food55, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food55, amount = 1 };
                    break;
                case 56:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food56, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food56, amount = 1 };
                    break;
                case 57:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food57, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food57, amount = 1 };
                    break;
                case 58:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food58, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food58, amount = 1 };
                    break;
                case 59:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food59, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food59, amount = 1 };
                    break;
                case 60:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food60, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food60, amount = 1 };
                    break;
                case 61:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food61, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food61, amount = 1 };
                    break;
                case 62:
                    Player.instance.fridge.addFood(new Food { foodScriptableObject = food62, amount = 1 });
                    cookedFood = new Food { foodScriptableObject = food62, amount = 1 };
                    break;
            }

            //clear Crockpot
            Player.instance.crockpot.clear();

            //Update Discovery
            if (!Player.instance.discovery.getDiscoveredFoods().Contains(foodDexNum))
            {
                Player.instance.discovery.addDiscoveredFood(foodDexNum);
            }

            //Display CookedFood
            //Instantiate gameObjects


            if (cookedFoodContainer != null)
            {

                foreach (Transform child in cookedFoodContainer)
                {
                    if (child == cookedFoodTemplate) continue;
                    Destroy(child.gameObject);
                }

                RectTransform itemSlotRectTransform = Instantiate(cookedFoodTemplate, cookedFoodContainer).GetComponent<RectTransform>();

                //unhide the slot
                cookedFoodContainer.gameObject.SetActive(true);
                itemSlotRectTransform.gameObject.SetActive(true);

                //set position
                itemSlotRectTransform.anchoredPosition = new Vector2(0, 0);

                //set sprite icon
                Image image = itemSlotRectTransform.Find("icon").GetComponent<Image>();
                image.sprite = cookedFood.getSprite();

                //set foodname
                TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
                uiText.SetText(cookedFood.ToString());
            }
        }

    }
}