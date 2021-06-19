using System;
using UnityEngine;


//The player class is essentially the Game Manager
public class Player : MonoBehaviour
{
    public static Player instance;
    public static Player Instance { get { return instance; } }
    

    [SerializeField] private UI_Inventory uiInventory;
    
    //[SerializeField] private UI_Volastro volastroOne;
    
    //Inventory (Ingredients)
    public Inventory inventory;

    //Adventure Status
    public DateTime firstVolastroReturnTime;


    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        }

        if (Player.instance.inventory == null)
        {
            inventory = new Inventory();
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
        
        
    }
}

