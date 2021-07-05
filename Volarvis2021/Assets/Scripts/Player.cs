using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//The player class is essentially the Game Manager
public class Player : MonoBehaviour
{
    public static Player instance;
    public static Player Instance { get { return instance; } }


    [SerializeField] public UI_Inventory uiInventory;
    [SerializeField] private UI_Crockpot uiCrockpot;
    [SerializeField] private UI_Volastro uiVolastro;
    [SerializeField] private UI_Fridge uiFridge;
    [SerializeField] public UI_CoinBar uiCoinBar;

    //Inventory (Ingredients)
    public Inventory inventory;
    public Crockpot crockpot;
    public Fridge fridge;

    //Volastro
    public Volastro volastroOne;

    //Adventure Status
    public DateTime firstVolastroReturnTime;

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

        if (Player.instance.voltz == null)
        {
           voltz = 0;
        }

        if (Player.instance.discovery == null)
        {
            discovery = new Discovery();
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

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
    }

    void Start()
    {
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        String sceneName = scene.name; 

        if (sceneName == "HomePage")
        {
            //if volastroOne is null means new player or volastro ran away, create new normal egg
            if (Player.instance.volastroOne == null)
            {
                volastroOne = new Volastro();
            }

            if (uiVolastro != null)
            {
                uiVolastro.SetVolastro(Player.instance.volastroOne);
            }

            if (uiCoinBar!= null)
            {
                uiCoinBar.SetVoltzAmount(Player.instance.voltz);
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

}


