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
                Debug.Log("Adding " + ingredient.ingredientType.ToString() + " from adventure");
            }
        }
    }

    public void finishMeadows()
    {
        Debug.Log("Finished meadows");
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.2, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.2, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Banana, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Blueberry, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cabbage, amount = 1 }, 0.4, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Mushroom, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sausages, amount = 1 }, 0.6, 2);
    }

    public void finishTangle()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Carrot, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Blueberry, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cabbage, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Chilli, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Beans, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Strawberry, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Basil, amount = 1 }, 0.1, 2);
    }

    public void finishPeaks()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Water, amount = 1 }, 0.4, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Ice, amount = 1 }, 0.8, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cabbage, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Carrot, amount = 1 }, 0.05, 2);
    }

    public void finishLava()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Flour, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Chilli, amount = 1 }, 0.8, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Mushroom, amount = 1 }, 0.05, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sausages, amount = 1 }, 0.05, 2);
    }

    public void finishCorals()
    {

        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 1);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 2);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Water, amount = 1 }, 0.8, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Fish, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Prawn, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Mussels, amount = 1 }, 0.1, 2);
    }

    public void finishGrove()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 3);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Flour, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Blueberry, amount = 1 }, 0.4, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Chocolate, amount = 1 }, 0.2, 2);
    }

    public void finishChateau()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 3);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Flour, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Fish, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.VanillaBean, amount = 1 }, 0.2, 2);
    }

    public void finishCave()
    {
        //Universal Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Bread, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Butter, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cheese, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Cream, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Onion, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Potato, amount = 1 }, 0.1, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Rice, amount = 1 }, 0.5, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Sugar, amount = 1 }, 0.5, 3);

        //Localised Ingredients
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Carrot, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Chilli, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Fish, amount = 1 }, 0.6, 2);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.Banana, amount = 1 }, 0.05, 3);
        addIngredientFromAdventure(new Ingredient { ingredientType = Ingredient.IngredientType.SpringOnion, amount = 1 }, 0.1, 2);
    }

}