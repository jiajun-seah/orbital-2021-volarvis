using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodDexManager : MonoBehaviour
{
    public static FoodDexManager instance;
    public static FoodDexManager Instance { get { return instance; } }

    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI dexNum;
    [SerializeField] private Image habitat;
    [SerializeField] private Image foodSprite;
    [SerializeField] private TextMeshProUGUI rarityText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI fullnessText;
    [SerializeField] private TextMeshProUGUI happinessText;

    //req traits values
    [SerializeField] private TextMeshProUGUI fieryVal;
    [SerializeField] private TextMeshProUGUI icyVal;
    [SerializeField] private TextMeshProUGUI magicalVal;
    [SerializeField] private TextMeshProUGUI nauticalVal;
    [SerializeField] private TextMeshProUGUI aerialVal;
    [SerializeField] private TextMeshProUGUI terraVal;

    [SerializeField] private Image ingredient1;
    [SerializeField] private Image ingredient2;
    [SerializeField] private Image ingredient3;
    [SerializeField] private Image ingredient4;

    [SerializeField] private Sprite anyIngredient;

    public FoodScriptableObject foodScriptableObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //if dexmanager is null means new player, create dex entry with wet goop by default
        if (this.foodScriptableObject == null)
        {
            foodScriptableObject = FoodManager.instance.wetGoopScriptable;
        }
    }
    public void updateDex()
    {
        //set header
        header.SetText(foodScriptableObject.foodName);
        //set dexNum
        dexNum.SetText("#" + foodScriptableObject.dexNum.ToString());
        
        //set sprite
        foodSprite.sprite = foodScriptableObject.foodSprite;
        //set rarity text
        rarityText.SetText(foodScriptableObject.rarity.ToString() + "/5");
        //set price text
        priceText.SetText(foodScriptableObject.price.ToString() + "V");

        fullnessText.SetText(foodScriptableObject.hungerVal.ToString() + "/100");

        happinessText.SetText(foodScriptableObject.happinessVal.ToString() + "/100");

        //set traits
        fieryVal.SetText(foodScriptableObject.fieryVal.ToString());
        icyVal.SetText(foodScriptableObject.icyVal.ToString());
        magicalVal.SetText(foodScriptableObject.magicalVal.ToString());
        nauticalVal.SetText(foodScriptableObject.nauticalVal.ToString());
        aerialVal.SetText(foodScriptableObject.aerialVal.ToString());
        terraVal.SetText(foodScriptableObject.terraVal.ToString());

        if (foodScriptableObject.dexNum == 0)
        {
            ingredient1.sprite = anyIngredient;
            ingredient2.sprite = anyIngredient;
            ingredient3.sprite = anyIngredient;
            ingredient4.sprite = anyIngredient;
        }
        else
        {
            ingredient1.sprite = foodScriptableObject.ingredient1.ingredientSprite;
            ingredient2.sprite = foodScriptableObject.ingredient2.ingredientSprite;
            ingredient3.sprite = foodScriptableObject.ingredient3.ingredientSprite;
            ingredient4.sprite = foodScriptableObject.ingredient4.ingredientSprite;
        }
        
    }
}
