using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandlerLibrary : MonoBehaviour
{
    public VolastroScriptableObject volastroScriptableObject;
    public FoodScriptableObject foodScriptableObject;

    [SerializeField] public Transform detailedDexInfo;
    [SerializeField] public Transform detailedFoodDexInfo;

    DexManager dexManager;

    public void selectedVolastro()
    {

        DexManager.instance.volastroScriptableObject = volastroScriptableObject;

        Debug.Log(volastroScriptableObject.volastroName + " volastro selected, updating dex info");

        DexManager.instance.updateDex();

        Debug.Log(volastroScriptableObject.volastroName + ": Dex manager updated dex info successfully.");

        detailedDexInfo.gameObject.SetActive(true);

        Debug.Log("Showing full dex entry for " + volastroScriptableObject.volastroName);
    }

    public void selectedFood()
    {

        FoodDexManager.instance.foodScriptableObject = foodScriptableObject;

        Debug.Log(foodScriptableObject.foodName + " food selected, updating dex info");

        FoodDexManager.instance.updateDex();

        Debug.Log(foodScriptableObject.foodName + ": Dex manager updated dex info successfully.");

        detailedFoodDexInfo.gameObject.SetActive(true);

        Debug.Log("Showing full dex entry for " + foodScriptableObject.foodName);


    }

}
