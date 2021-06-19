using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReturnTimeCountdown : MonoBehaviour
{
    //make into singleton
    public static ReturnTimeCountdown instance;
    public static ReturnTimeCountdown Instance { get { return instance; } }

    //constants
    private static float RNDLOWER = 0f;
    private static float RNDUPPER = 1f;

    //properties
    public TextMeshProUGUI countdownDisplay;
    public TextMeshProUGUI countdownFillerText;
    public Button adventureTab;
    public string location = "";
    public bool hasReturned = false;


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

        if (instance != null)
        {
            if (Player.instance.firstVolastroReturnTime > DateTime.Now)
            {
                this.startCounting();
            }
        }

        Debug.Log("ReturnTimeCountdown awake");
    }
    private void Update()
    {
        if (ReturnTimeCountdown.instance.hasReturned)
        {
            //add to inventory
            switch (ReturnTimeCountdown.instance.location)
            {
                default:
                    break;
                case "meadows":
                    this.finishMeadows();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "tangle":
                    this.finishTangle();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "peaks":
                    this.finishPeaks();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "lava":
                    this.finishLava();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "corals":
                    this.finishCorals();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "grove":
                    this.finishGrove();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "chateau":
                    this.finishChateau();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
                case "cave":
                    this.finishCave();
                    ReturnTimeCountdown.instance.hasReturned = false;
                    break;
            }
        }
    }

    public void startCounting()
    {
        StartCoroutine(CountdownToReturn());
        Debug.Log("Countdown initiated.");
    }

    IEnumerator CountdownToReturn()
    {
        TimeSpan durat = (Player.instance.firstVolastroReturnTime - DateTime.Now);
        int countdownTracker = (int)durat.TotalSeconds;


        while (countdownTracker > 0)
        {
            adventureTab.interactable = false;
            ReturnTimeCountdown.instance.hasReturned = false;
            durat = (Player.instance.firstVolastroReturnTime - DateTime.Now);
            int countdownTimeHour = durat.Hours;
            int countdownTimeMin = durat.Minutes;
            int countdownTimeSec = durat.Seconds;

            countdownDisplay.gameObject.SetActive(true);
            countdownFillerText.gameObject.SetActive(true);

            countdownDisplay.SetText(
                countdownTimeHour.ToString() + ":"
                + countdownTimeMin.ToString() + ":"
                + countdownTimeSec.ToString());

            yield return new WaitForSeconds(1f);

            countdownTracker--;
        }

        countdownFillerText.gameObject.SetActive(false);
        countdownDisplay.SetText("Volastro Returned!");
        adventureTab.interactable = true;
        ReturnTimeCountdown.instance.hasReturned = true;

        yield return new WaitForSeconds(1f);

        //hide the text after countdown ends
        countdownDisplay.gameObject.SetActive(false);
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
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = cabbageScriptable, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientScriptableObject = carrotScriptable, amount = 1 }, 0.05, 2);
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
    }

}