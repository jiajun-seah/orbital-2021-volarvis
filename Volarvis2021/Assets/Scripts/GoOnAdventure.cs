using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoOnAdventure : MonoBehaviour
{

    //make into singleton
    public static GoOnAdventure instance;
    public static GoOnAdventure Instance { get { return instance; } }

    //public event EventHandler onWentOnAdventure;


    void Awake()
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

    public void forceReturnAdventure()
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now;
        Player.instance.adventureLocation = "";

        Debug.Log("Player's adventureLocation reset");
        Debug.Log("Force end adventure");
    }

    public void visitMeadows() //5 seconds (for ease of testing. Real game will be 1 min)
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddSeconds(60);
        Player.instance.adventureLocation = "meadows";

        Debug.Log("Player's adventureLocation set to meadows");
        Debug.Log("Visiting Meadows");
    }

    public void visitTangle() //10 seconds (for ease of testing. Real game will be 5 min)
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddMinutes(5);
        Player.instance.adventureLocation = "tangle";

        Debug.Log("Player's adventureLocation set to tangle");
        Debug.Log("Visit Tangle");
    }

    public void visitPeaks() //15 seconds (for ease of testing. Real game will be 15 min)
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddMinutes(15);
        Player.instance.adventureLocation = "peaks";

        Debug.Log("Player's adventureLocation set to peaks");
        Debug.Log("Visit Peaks");
    }

    public void visitLava() //45 min
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddMinutes(45);
        Player.instance.adventureLocation = "lava";

        Debug.Log("Player's adventureLocation set to lava");
        Debug.Log("Visit Lava");
    }

    public void visitCorals() //1h
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(1);
        Player.instance.adventureLocation = "corals";

        Debug.Log("Player's adventureLocation set to corals");
        Debug.Log("Visit Corals");
    }

    public void visitGrove() //2h
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(2);
        Player.instance.adventureLocation = "grove";

        Debug.Log("Player's adventureLocation set to grove");
        Debug.Log("Visit Grove");
    }

    public void visitChateau() //4h 
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(4);
        Player.instance.adventureLocation = "chateau";

        Debug.Log("Player's adventureLocation set to chateau");
        Debug.Log("Visit Chateau");
    }

    public void visitCave() //6h
    {

        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(6);
        Player.instance.adventureLocation = "cave";

        Debug.Log("Player's adventureLocation set to cave");
        Debug.Log("Visit Cave");
    }
}
