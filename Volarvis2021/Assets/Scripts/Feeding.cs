using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feeding : MonoBehaviour
{
    public static Feeding instance;
    public static Feeding Instance { get { return instance; } }

    [SerializeField] private Transform volastroFullMessage;
    [SerializeField] private Button feedButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button trashButton;

    public Food food;
    public FoodScriptableObject type;

    public Fridge fridge;

    public Volastro volastroOne;

    public int[] foodVal;

    private void Awake() {

        if (instance == null) {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    void Start() {
        fridge = Player.instance.fridge;
        volastroOne = Player.instance.volastroOne;
    }

    public void OnClickFeed() 
    {
        Debug.Log("Clicked on feed:" + food);

        if (volastroOne.hungerVal == 100)
        {
            volastroFullMessage.gameObject.SetActive(true);
            feedButton.interactable = false;
            closeButton.interactable = false;
            trashButton.interactable = false;
            Debug.Log("Volastro is full");
        }
        else
        {
            foodVal = new int[] { type.fieryVal, type.icyVal, type.magicalVal, type.nauticalVal, type.aerialVal, type.terraVal };
            fridge.removeFood(food); // removing from fridge
            volastroOne.updateTrait(type.happinessVal, type.hungerVal, foodVal); // update volastro

            if (volastroOne.happinessVal == 100)
            {
                volastroOne.evolve();
            }
        }
    }

    public void OnClickTrash()
    {
        Debug.Log("Clicked on trash:" + food);
        fridge.removeFood(food); // removing from fridge
    }


}
