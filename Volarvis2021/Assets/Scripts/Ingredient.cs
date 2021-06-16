using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient {
    public enum IngredientType
    {
        Banana,
        Basil,
        Beans,
        Blueberry,
        Bread,
        Butter,
        Cabbage,
        Carrot,
        Cheese,
        Chilli,
        Chocolate,
        Cream,
        Fish,
        Flour,
        Ice,
        Mushroom,
        Mussels,
        Onion,
        Potato,
        Prawn,
        Rice,
        Sausages,
        SpringOnion,
        Strawberry,
        Sugar,
        VanillaBean,
        Water
    }

    public IngredientType ingredientType;
    public int amount;

    public Sprite getSprite()
    {
        switch (ingredientType)
        {
            default:
            case IngredientType.Banana: return ItemAssets.Instance.bananaSprite;
            case IngredientType.Basil: return ItemAssets.Instance.basilSprite;
            case IngredientType.Beans: return ItemAssets.Instance.beansSprite;
            case IngredientType.Blueberry: return ItemAssets.Instance.blueberrySprite;
            case IngredientType.Bread: return ItemAssets.Instance.breadSprite;
            case IngredientType.Butter: return ItemAssets.Instance.butterSprite;
            case IngredientType.Cabbage: return ItemAssets.Instance.cabbageSprite;
            case IngredientType.Carrot: return ItemAssets.Instance.carrotSprite;
            case IngredientType.Cheese: return ItemAssets.Instance.cheeseSprite;
            case IngredientType.Chilli: return ItemAssets.Instance.chilliSprite;
            case IngredientType.Chocolate: return ItemAssets.Instance.chocolateSprite;
            case IngredientType.Cream: return ItemAssets.Instance.creamSprite;
            case IngredientType.Fish: return ItemAssets.Instance.fishSprite;
            case IngredientType.Flour: return ItemAssets.Instance.flourSprite;
            case IngredientType.Ice: return ItemAssets.Instance.iceSprite;
            case IngredientType.Mushroom: return ItemAssets.Instance.mushroomSprite;
            case IngredientType.Mussels: return ItemAssets.Instance.musselsSprite;
            case IngredientType.Onion: return ItemAssets.Instance.onionSprite;
            case IngredientType.Potato: return ItemAssets.Instance.potatoSprite;
            case IngredientType.Prawn: return ItemAssets.Instance.prawnSprite;
            case IngredientType.Rice: return ItemAssets.Instance.riceSprite;
            case IngredientType.Sausages: return ItemAssets.Instance.sausagesSprite;
            case IngredientType.SpringOnion: return ItemAssets.Instance.springOnionSprite;
            case IngredientType.Strawberry: return ItemAssets.Instance.strawberrySprite;
            case IngredientType.Sugar: return ItemAssets.Instance.sugarSprite;
            case IngredientType.VanillaBean: return ItemAssets.Instance.vanillaBeanSprite;
            case IngredientType.Water: return ItemAssets.Instance.waterSprite;

        }
    }

    public bool isStackable()
    {
        switch (ingredientType)
        {
            default: return true;
        }
    }
}
