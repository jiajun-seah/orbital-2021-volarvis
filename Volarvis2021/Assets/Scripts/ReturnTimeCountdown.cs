using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnTimeCountdown : MonoBehaviour
{

    //make into singleton
    public static ReturnTimeCountdown instance;
    public static ReturnTimeCountdown Instance { get { return instance; } }

    //constants
    private static float RNDLOWER = 0f;
    private static float RNDUPPER = 1f;

    private static int MEADOWS_LOWER_VOLTZ = 5;
    private static int MEADOWS_UPPER_VOLTZ = 20;

    private static int TANGLE_LOWER_VOLTZ = 10;
    private static int TANGLE_UPPER_VOLTZ = 50;

    private static int PEAKS_LOWER_VOLTZ = 20;
    private static int PEAKS_UPPER_VOLTZ = 80;

    private static int LAVA_LOWER_VOLTZ = 50;
    private static int LAVA_UPPER_VOLTZ = 100;

    private static int CORALS_LOWER_VOLTZ = 80;
    private static int CORALS_UPPER_VOLTZ = 150;

    private static int GROVE_LOWER_VOLTZ = 100;
    private static int GROVE_UPPER_VOLTZ = 200;

    private static int CHATEAU_LOWER_VOLTZ = 150;
    private static int CHATEAU_UPPER_VOLTZ = 200;

    private static int CAVE_LOWER_VOLTZ = 200;
    private static int CAVE_UPPER_VOLTZ = 250;


    //ingredients (scriptable)
    public IngredientScriptableObject bananaScriptable;
    public IngredientScriptableObject basilScriptable;
    public IngredientScriptableObject beansScriptable;
    public IngredientScriptableObject blueberryScriptable;
    public IngredientScriptableObject breadScriptable;
    public IngredientScriptableObject butterScriptable;
    public IngredientScriptableObject cabbageScriptable;
    public IngredientScriptableObject carrotScriptable;
    public IngredientScriptableObject cheeseScriptable;
    public IngredientScriptableObject chilliScriptable;
    public IngredientScriptableObject chocolateScriptable;
    public IngredientScriptableObject creamScriptable;
    public IngredientScriptableObject fishScriptable;
    public IngredientScriptableObject flourScriptable;
    public IngredientScriptableObject iceScriptable;
    public IngredientScriptableObject mushroomScriptable;
    public IngredientScriptableObject musselsScriptable;
    public IngredientScriptableObject onionScriptable;
    public IngredientScriptableObject potatoScriptable;
    public IngredientScriptableObject prawnScriptable;
    public IngredientScriptableObject riceScriptable;
    public IngredientScriptableObject sausagesScriptable;
    public IngredientScriptableObject springOnionScriptable;
    public IngredientScriptableObject strawberryScriptable;
    public IngredientScriptableObject sugarScriptable;
    public IngredientScriptableObject vanillaBeanScriptable;
    public IngredientScriptableObject waterScriptable;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Debug.Log("ReturnTimeCountdown awake");

    }

    private void Start()
    {
        
    }
    
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{

    //    String sceneName = scene.name;

    //    if (sceneName == "HomePage")
    //    {


    //    }
    //}

    //private void GoOnAdventure_onWentOnAdventure(object sender, System.EventArgs e)
    //{

    //    if (Player.instance.firstVolastroReturnTime > DateTime.Now)
    //    {
    //        this.startCounting();
    //        Debug.Log("ReturnTimeCountdown started");
    //    }

    //}

    private void Update()
    {
        if ((DateTime.Now > Player.instance.firstVolastroReturnTime) && (Player.instance.adventureLocation != ""))
        {
            handleReturn();
        }
    }
    public void handleReturn()
    {
        
        //add to inventory and reset state
        switch (Player.instance.adventureLocation)
        {
            default:
                break;
            case "meadows":
                this.finishMeadows();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "tangle":
                this.finishTangle();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "peaks":
                this.finishPeaks();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "lava":
                this.finishLava();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "corals":
                this.finishCorals();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "grove":
                this.finishGrove();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "chateau":
                this.finishChateau();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
            case "cave":
                this.finishCave();
                Player.instance.adventureLocation = "";
                Debug.Log("Player's adventureLocation set to empty string");
                break;
        }
        
    }
  
    public void addIngredientFromAdventure(Ingredient ingredient, double baseDropRate, int attempts)
    {
        for (int i = 0; i < attempts; i++)
        {
            if (baseDropRate > Random.Range(RNDLOWER, RNDUPPER))
            {
                Player.instance.inventory.addIngredient(ingredient);
                Debug.Log("Adding " + ingredient.ToString() + " from adventure");
            }
        }
    }

    public void finishMeadows()
    {
        Debug.Log("Finished meadows");
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = blueberryScriptable, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cabbageScriptable, amount = 1 }, 0.4, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = mushroomScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sausagesScriptable, amount = 1 }, 0.6, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(MEADOWS_LOWER_VOLTZ, MEADOWS_UPPER_VOLTZ));
    }

    public void finishTangle()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = carrotScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = blueberryScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cabbageScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = chilliScriptable, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = beansScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = strawberryScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = basilScriptable, amount = 1 }, 0.1, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(TANGLE_LOWER_VOLTZ, TANGLE_UPPER_VOLTZ));
    }

    public void finishPeaks()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = waterScriptable, amount = 1 }, 0.4, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = iceScriptable, amount = 1 }, 0.8, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = flourScriptable, amount = 1 }, 0.4, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cabbageScriptable, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = carrotScriptable, amount = 1 }, 0.1, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(PEAKS_LOWER_VOLTZ, PEAKS_UPPER_VOLTZ));
    }

    public void finishLava()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = flourScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = chilliScriptable, amount = 1 }, 0.8, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = mushroomScriptable, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sausagesScriptable, amount = 1 }, 0.05, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(LAVA_LOWER_VOLTZ, LAVA_UPPER_VOLTZ));
    }

    public void finishCorals()
    {

        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = waterScriptable, amount = 1 }, 0.8, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = fishScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = prawnScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = musselsScriptable, amount = 1 }, 0.1, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(CORALS_LOWER_VOLTZ, CORALS_UPPER_VOLTZ));
    }

    public void finishGrove()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 3);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = flourScriptable, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = blueberryScriptable, amount = 1 }, 0.4, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = chocolateScriptable, amount = 1 }, 0.2, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(GROVE_LOWER_VOLTZ, GROVE_UPPER_VOLTZ));
    }

    public void finishChateau()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 3);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = flourScriptable, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = fishScriptable, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = vanillaBeanScriptable, amount = 1 }, 0.2, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(CHATEAU_LOWER_VOLTZ, CHATEAU_UPPER_VOLTZ));
    }

    public void finishCave()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = breadScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = butterScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cheeseScriptable, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = creamScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = onionScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = potatoScriptable, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = riceScriptable, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = sugarScriptable, amount = 1 }, 0.5, 3);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = carrotScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = chilliScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = fishScriptable, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = bananaScriptable, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = springOnionScriptable, amount = 1 }, 0.1, 2);

        //add voltz
        Player.instance.addVoltz(Random.Range(CAVE_LOWER_VOLTZ, CAVE_UPPER_VOLTZ));
    }

}