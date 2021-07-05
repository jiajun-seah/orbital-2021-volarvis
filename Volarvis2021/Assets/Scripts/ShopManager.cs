using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//The player class is essentially the Game Manager
public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public static ShopManager Instance { get { return instance; } }


    [SerializeField] public UI_ShopIngredient uiShopIngredient;
    [SerializeField] public UI_ShopFood uiShopFood;

    public Shop shop;

    
    private void Awake()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance == null)
        {
            instance = this;
        }

        

        
        else if (instance != this)
        {
            Destroy(gameObject);
        }

  
    }

    void Start()
    {
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        String sceneName = scene.name;

        if (sceneName == "ShopPage")
        {
            //if shop is null, create new shop
            if (ShopManager.instance.shop == null)
            {
                shop = new Shop();
            }

            if (uiShopIngredient != null)
            {
                uiShopIngredient.SetShop(ShopManager.instance.shop);
            }
            if (uiShopFood != null)
            {
                uiShopFood.SetShop(ShopManager.instance.shop);
            }
        }
    }

}


