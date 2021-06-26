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

    //Inventory (Ingredients)
    public Inventory inventory;
    public Crockpot crockpot;
    public Fridge fridge;

    //Volastro
    public Volastro volastroOne;

    //Adventure Status
    public DateTime firstVolastroReturnTime;

    private void Awake()
    {

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


        else if (instance != this)
        {
            Destroy(gameObject);
        }

        /*
        DontDestroyOnLoad(gameObject);
        */

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
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

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
        }
            
    }

}


