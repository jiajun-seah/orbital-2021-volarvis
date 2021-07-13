using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


//The player class is essentially the Game Manager
public class Player : MonoBehaviour
{
    public static Player instance;
    public static Player Instance { get { return instance; } }


    [SerializeField] public UI_Inventory uiInventory;
    [SerializeField] public UI_Crockpot uiCrockpot;
    [SerializeField] public UI_Volastro uiVolastro;
    [SerializeField] public UI_Fridge uiFridge;
    [SerializeField] public UI_CoinBar uiCoinBar;

    //Inventory (Ingredients)
    public Inventory inventory;
    public Crockpot crockpot;
    public Fridge fridge;

    //Volastro
    public Volastro volastroOne;
    public DateTime lastFedTime = DateTime.Now;
    public DateTime emptyHungerTime = DateTime.Now;
    public int hungerAtLastFed;
    public int happinessAtHungerEmpty;

    //Adventure Status
    public DateTime firstVolastroReturnTime;
    public string adventureLocation;

    //currency
    public int voltz;
    public event EventHandler onVoltzAmountChanged;

    //library
    public Discovery discovery;

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
        //if volastroOne is null means new player or volastro ran away, create new normal egg
        if (Player.instance.volastroOne == null)
        {
            volastroOne = new Volastro();
        }

        //if inventory is null means new player, create new inventory
        if (Player.instance.inventory == null)
        {
            inventory = new Inventory();
            crockpot = new Crockpot();
        }

        if (Player.instance.fridge == null)
        {
            fridge = new Fridge();
        }

        if (Player.instance.firstVolastroReturnTime == null)
        {
            firstVolastroReturnTime = DateTime.Now;
        }

        if (Player.instance.adventureLocation == null)
        {
            adventureLocation = "";
        }

        //Initialize last fed state of volastro
        if (Player.instance.lastFedTime == null)
        {
            lastFedTime = (DateTime.Now.AddSeconds(-1));
        }
        //Initialize hunger zero datetime state of volastro
        if (Player.instance.emptyHungerTime == null)
        {
            lastFedTime = (DateTime.Now.AddSeconds(-1));
        }
        if (Player.instance.hungerAtLastFed == null)
        {
            hungerAtLastFed = 100;
            Debug.Log("Starting state: hunger is 100");
        }
        if (Player.instance.happinessAtHungerEmpty == null)
        {
            happinessAtHungerEmpty = 0;
        }

        if (Player.instance.voltz == null)
        {
           voltz = 0;
        }

        if (Player.instance.discovery == null)
        {
            discovery = new Discovery();
        }

    }

    public void RefreshUI()
    {
        if (uiInventory != null)
        {
            uiInventory.SetInventory(Player.instance.inventory);
        }

        if (uiCrockpot != null)
        {
            uiCrockpot.SetCrockpot(Player.instance.crockpot);
        }

        if (uiFridge != null)
        {
            uiFridge.SetFridge(Player.instance.fridge);
        }

        if (uiVolastro != null)
        {
            uiVolastro.SetVolastro(Player.instance.volastroOne);
        }

        if (uiCoinBar != null)
        {
            uiCoinBar.SetVoltzAmount(Player.instance.voltz);
        }
    }

    void Start()
    {

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        String sceneName = scene.name; 

        if (sceneName == "HomePage")
        {

            if (uiVolastro != null)
            {
                uiVolastro.SetVolastro(Player.instance.volastroOne);
            }

            //if (uiCoinBar != null)
            //{
            //    uiCoinBar.SetVoltzAmount(Player.instance.voltz);
            //}

            if (uiFridge != null)
            {
                uiFridge.SetFridge(Player.instance.fridge);
            }

        }

        if (sceneName == "CookPage")
        {
            if (uiCoinBar!= null)
            {
                uiCoinBar.SetVoltzAmount(Player.instance.voltz);
            }
        }

        if (sceneName == "ShopPage")
        {
            if (uiCoinBar != null)
            {
                uiCoinBar.SetVoltzAmount(Player.instance.voltz);
            }
        }
    }

    public void addVoltz(int amount)
    {
        voltz += amount;
        onVoltzAmountChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log(amount.ToString() + " voltz was added.");
    }

    public void minusVoltz(int amount)
    {
        voltz -= amount;
        onVoltzAmountChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log(amount.ToString() + " voltz was added.");
    }

    public void loadPlayerFromState()
    {
        //Set Player inventory
        Player.instance.inventory.clear();
        foreach (KeyValuePair<int, int> entry in CloudSaveManager.Instance.State.inventory)
        {
            Player.instance.inventory.addIngredient(new Ingredient { ingredientScriptableObject = IngredientManager.instance.getIngredientList()[entry.Key], amount = entry.Value });
        }


        //Set Player crockpot
        Player.instance.crockpot.clear();
        foreach (int i in CloudSaveManager.Instance.State.crockpot)
        {
            Player.instance.crockpot.addIngredient(new Ingredient { ingredientScriptableObject = IngredientManager.instance.getIngredientList()[i], amount = 1 });
        }

        //Set Player fridge
        Player.instance.fridge.clear();
        foreach (int i in CloudSaveManager.Instance.State.fridge)
        {
            Player.instance.fridge.addFood(new Food { foodScriptableObject = FoodManager.instance.getFoodList()[i], amount = 1 });
        }

        Player.instance.voltz = CloudSaveManager.Instance.State.voltz;

        int vDexNum = CloudSaveManager.Instance.State.volastroOneDexNum;
        int vHungerVal = CloudSaveManager.Instance.State.hungerVal;
        int vHappinessVal = CloudSaveManager.Instance.State.happinessVal;
        int[] vTraitsVal = CloudSaveManager.Instance.State.traits;
        Player.instance.volastroOne.rebaseVolastro(VolastroManager.instance.getVolastroList()[vDexNum], vHungerVal, vHappinessVal, vTraitsVal);

        Player.instance.lastFedTime = CloudSaveManager.Instance.State.lastFedTime;
        Player.instance.emptyHungerTime = CloudSaveManager.Instance.State.emptyHungerTime;

        Player.instance.hungerAtLastFed = CloudSaveManager.Instance.State.hungerAtLastFed;
        Player.instance.happinessAtHungerEmpty = CloudSaveManager.Instance.State.happinessAtHungerEmpty;

        Player.instance.firstVolastroReturnTime = CloudSaveManager.Instance.State.firstVolastroReturnTime;
        Player.instance.adventureLocation = CloudSaveManager.Instance.State.adventureLocation;



        List<int> tempFoodDiscovery = CloudSaveManager.Instance.State.foodDiscovery.OfType<int>().ToList();
        List<int> tempVolastroDiscovery = CloudSaveManager.Instance.State.volastroDiscovery.OfType<int>().ToList();
        Player.instance.discovery = new Discovery(tempFoodDiscovery, tempVolastroDiscovery);
    }

    public void savePlayerToState()
    {
        Dictionary<int, int> tempInventory = new Dictionary<int, int>();
        foreach (Ingredient ingredient in Player.instance.inventory.getIngredients())
        {
            tempInventory.Add(ingredient.getDexNum(), ingredient.getQty());
        }
        CloudSaveManager.Instance.State.inventory = tempInventory;

        List<int> tempCrockpot = new List<int>();
        foreach (Ingredient ingredient in Player.instance.crockpot.getIngredients())
        {
            tempCrockpot.Add(ingredient.getDexNum());
        }
        CloudSaveManager.Instance.State.crockpot = tempCrockpot.ToArray();

        List<int> tempFridge = new List<int>();
        foreach (Food food in Player.instance.fridge.getFoods())
        {
            tempFridge.Add(food.getDexNum());
        }
        CloudSaveManager.Instance.State.fridge = tempFridge.ToArray();

        CloudSaveManager.Instance.State.voltz = Player.instance.voltz;

        CloudSaveManager.Instance.State.volastroOneDexNum = Player.instance.volastroOne.getDexNum();
        CloudSaveManager.Instance.State.hungerVal = Player.instance.volastroOne.getHungerVal();
        CloudSaveManager.Instance.State.happinessVal = Player.instance.volastroOne.getHappinessVal();
        CloudSaveManager.Instance.State.traits = Player.instance.volastroOne.getTraitsVal();

        CloudSaveManager.Instance.State.lastFedTime = Player.instance.lastFedTime;
        CloudSaveManager.Instance.State.emptyHungerTime = Player.instance.emptyHungerTime;

        CloudSaveManager.Instance.State.hungerAtLastFed = Player.instance.hungerAtLastFed;
        CloudSaveManager.Instance.State.happinessAtHungerEmpty = Player.instance.happinessAtHungerEmpty;

        CloudSaveManager.Instance.State.firstVolastroReturnTime = Player.instance.firstVolastroReturnTime;
        CloudSaveManager.Instance.State.adventureLocation = Player.instance.adventureLocation;


        CloudSaveManager.Instance.State.volastroDiscovery = Player.instance.discovery.getDiscoveredVolastros().ToArray();
        CloudSaveManager.Instance.State.foodDiscovery = Player.instance.discovery.getDiscoveredFoods().ToArray();
    }
}


