using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerHappinessManager : MonoBehaviour
{
    Volastro volastro;

    // Start is called before the first frame update
    void Start()
    {
        volastro = Player.instance.volastroOne;
        Debug.Log(Player.instance.lastFedTime.ToString());
    }

    void Update()
    {
        if (Player.instance.lastFedTime != null && Player.instance.hungerAtLastFed != null)
        {
            Debug.Log("lastFedTime and hungerAtLastFed not null, commencing decay");
            DecayHunger();
        }

        if (Player.instance.emptyHungerTime != null && Player.instance.happinessAtHungerEmpty != null && Player.instance.volastroOne.getHungerVal() == 0)
        {
            Debug.Log("emptyHungerTime, happinessAtHungerEmpty not null, and volastro hunger is ZERO, commencing decay");
            DecayHappiness();
        }

    }

    public void DecayHunger()
    {
        TimeSpan duratSinceLastFed = (DateTime.Now - Player.instance.lastFedTime);
        int duratInSeconds = (int)duratSinceLastFed.TotalSeconds;
        int hungerAtLastFed = Player.instance.hungerAtLastFed;

        hungerAtLastFed -= ((duratInSeconds/1800) * 1);

        Debug.Log("New hunger value is: " + hungerAtLastFed);

        volastro.rebaseTrait(hungerAtLastFed, volastro.getHappinessVal(), volastro.getTraitsVal());
        Debug.Log("Successfully reassigned hunger to: " + hungerAtLastFed);
    }

    public void DecayHappiness()
    {
        TimeSpan duratSinceHungerEmpty = (DateTime.Now - Player.instance.emptyHungerTime);
        int duratInSeconds = (int)duratSinceHungerEmpty.TotalSeconds;
        int happinessAtHungerEmpty = Player.instance.happinessAtHungerEmpty;

        happinessAtHungerEmpty -= ((duratInSeconds/900) * 1);

        Debug.Log("New happiness value is: " + happinessAtHungerEmpty);

        volastro.rebaseTrait(volastro.getHungerVal(), happinessAtHungerEmpty, volastro.getTraitsVal());
        Debug.Log("Successfully reassigned happiness to: " + happinessAtHungerEmpty);
    }
}
