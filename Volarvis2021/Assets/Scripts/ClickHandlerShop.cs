using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandlerShop : MonoBehaviour
{
    public Ingredient ingredient;
    public IngredientScriptableObject ingredientScriptableObject;

    public Food food;
    public FoodScriptableObject foodScriptableObject;

    public Inventory inventory;
    public Fridge fridge;

    [SerializeField] private Transform insufficientVoltzMessage;
    [SerializeField] private Transform buySuccessMessage;
    [SerializeField] private Transform fridgeFullMessage;

    void Start()
    {
        inventory = Player.instance.inventory;
        fridge = Player.instance.fridge;
    }

    public void buyIngredient()
    {
        Debug.Log("Attempting to buy ingredient");

        if (Player.instance.voltz < ingredientScriptableObject.price)
        {
            Debug.Log("Insufficient voltz");
            insufficientVoltzMessage.gameObject.SetActive(true);
        }
        else
        {
            Player.instance.minusVoltz(ingredientScriptableObject.price);
            inventory.addIngredient(ingredient);
            buySuccessMessage.gameObject.SetActive(true);
            Debug.Log("Bought" + ingredient.ToString() + " using " + ingredientScriptableObject.price + " voltz.");
        }
        
    }

    public void buyFood()
    {
        Debug.Log("Attempting to buy food");
        if (Player.instance.fridge.getFoods().Count >= 20)
        {
            Debug.Log("Fridge full");
            fridgeFullMessage.gameObject.SetActive(true);
        }
        else if (Player.instance.voltz < foodScriptableObject.price)
        {
            Debug.Log("Insufficient voltz");
            insufficientVoltzMessage.gameObject.SetActive(true);
        }
        else
        {
            Player.instance.minusVoltz(foodScriptableObject.price);
            fridge.addFood(food);
            buySuccessMessage.gameObject.SetActive(true);
            Debug.Log("Bought" + food.ToString() + " using " + foodScriptableObject.price + " voltz.");

            //Update Discovery
            if (!Player.instance.discovery.getDiscoveredFoods().Contains(food.getDexNum()))
            {
                Player.instance.discovery.addDiscoveredFood(food.getDexNum());
            }

        }
    }
}
