using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager instance;
    public static IngredientManager Instance { get { return instance; } }

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

    Dictionary<int, IngredientScriptableObject> ingredientList = new Dictionary<int, IngredientScriptableObject>();

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

        ingredientList.Add(1, bananaScriptable);
        ingredientList.Add(2, basilScriptable);
        ingredientList.Add(3, beansScriptable);
        ingredientList.Add(4, blueberryScriptable);
        ingredientList.Add(5, breadScriptable);
        ingredientList.Add(6, butterScriptable);
        ingredientList.Add(7, cabbageScriptable);
        ingredientList.Add(8, carrotScriptable);
        ingredientList.Add(9, cheeseScriptable);
        ingredientList.Add(10, chilliScriptable);
        ingredientList.Add(11, chocolateScriptable);
        ingredientList.Add(12, creamScriptable);
        ingredientList.Add(13, fishScriptable);
        ingredientList.Add(14, flourScriptable);
        ingredientList.Add(15, iceScriptable);
        ingredientList.Add(16, mushroomScriptable);
        ingredientList.Add(17, musselsScriptable);
        ingredientList.Add(18, onionScriptable);
        ingredientList.Add(19, potatoScriptable);
        ingredientList.Add(20, prawnScriptable);
        ingredientList.Add(21, riceScriptable);
        ingredientList.Add(22, sausagesScriptable);
        ingredientList.Add(23, springOnionScriptable);
        ingredientList.Add(24, strawberryScriptable);
        ingredientList.Add(25, sugarScriptable);
        ingredientList.Add(26, vanillaBeanScriptable);
        ingredientList.Add(27, waterScriptable);
    }

    public Dictionary<int, IngredientScriptableObject> getIngredientList()
    {
        return this.ingredientList;
    }
}
