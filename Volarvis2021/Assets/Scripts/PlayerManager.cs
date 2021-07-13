using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] public UI_Inventory uiInventory;
    [SerializeField] private UI_Crockpot uiCrockpot;
    [SerializeField] private UI_Volastro uiVolastro;
    [SerializeField] private UI_Fridge uiFridge;
    [SerializeField] public UI_CoinBar uiCoinBar;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        String sceneName = scene.name;

        if (sceneName == "HomePage")
        {

            Player.instance.uiVolastro = uiVolastro;
            Player.instance.uiFridge = uiFridge;
            Player.instance.uiCoinBar = uiCoinBar;
            Player.instance.RefreshUI();

        }

        if (sceneName == "CookPage")
        {
            Player.instance.uiInventory = uiInventory;
            Player.instance.uiCrockpot = uiCrockpot;
            Player.instance.uiCoinBar = uiCoinBar;
            Player.instance.RefreshUI();
        }

        if (sceneName == "ShopPage")
        {
            Player.instance.uiCoinBar = uiCoinBar;
            Player.instance.RefreshUI();
        }
    }
}
