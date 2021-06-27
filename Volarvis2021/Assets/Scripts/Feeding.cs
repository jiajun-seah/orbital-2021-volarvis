using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeding : MonoBehaviour
{
    public static Feeding instance;
    public static Feeding Instance { get { return instance; } }

    public Food food;
    public FoodScriptableObject type;

    public Fridge fridge;

    public Volastro volastroOne;

    public int[] foodVal;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    
    void Start() {
        fridge = Player.instance.fridge;
        volastroOne = Player.instance.volastroOne;
    }

    public void OnClickFeed() {
        foodVal = new int[] {type.fieryVal, type.icyVal, type.magicalVal, type.nauticalVal, type.aerialVal, type.terraVal};
        fridge.removeFood(food); // removing from fridge
        volastroOne.updateTrait(type.happinessVal, type.hungerVal, foodVal); // update volastro
    }

    
}
