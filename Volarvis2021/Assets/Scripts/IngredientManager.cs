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

    }
}
