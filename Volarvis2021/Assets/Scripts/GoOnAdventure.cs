using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOnAdventure : MonoBehaviour
{
    //public event EventHandler onWentOnAdventure;

    public void visitMeadows() //1 minute (for ease of testing. Real game will be 5 min)
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddSeconds(5);
        ReturnTimeCountdown.instance.location = "meadows";
        ReturnTimeCountdown.instance.startCounting();

        Debug.Log("Visiting Meadows");
    }

    public void visitTangle() //3 minutes (for ease of testing. Real game will be 30 min)
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddSeconds(5);
        ReturnTimeCountdown.instance.location = "tangle";
        ReturnTimeCountdown.instance.startCounting();

        Debug.Log("Visit Tangle");
    }

    public void visitPeaks() //5 minutes (for ease of testing. Real game will be 45 min)
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddSeconds(5);
        ReturnTimeCountdown.instance.location = "peaks";
        ReturnTimeCountdown.instance.startCounting();

        Debug.Log("Visit Peaks");
    }

    public void visitLava() //1h
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(1);
        ReturnTimeCountdown.instance.location = "lava";
        ReturnTimeCountdown.instance.startCounting();


        Debug.Log("Visit Lava");
    }

    public void visitCorals() //2h
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(2);
        ReturnTimeCountdown.instance.location = "corals";
        ReturnTimeCountdown.instance.startCounting();

        Debug.Log("Visit Corals");
    }

    public void visitGrove()
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(4);
        ReturnTimeCountdown.instance.location = "grove";
        ReturnTimeCountdown.instance.startCounting();

        Debug.Log("Visit Grove");
    }

    public void visitChateau()
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(6);
        ReturnTimeCountdown.instance.location = "chateau";
        ReturnTimeCountdown.instance.startCounting();

        Debug.Log("Visit Chateau");
    }

    public void visitCave()
    {
        Player.instance.firstVolastroReturnTime = DateTime.Now.AddHours(8);
        ReturnTimeCountdown.instance.location = "cave";
        ReturnTimeCountdown.instance.startCounting();
        Debug.Log("Visit Cave");
    }



    public bool canVisit()
    {
        return DateTime.Now > Player.instance.firstVolastroReturnTime ? true : false;
    }

}
