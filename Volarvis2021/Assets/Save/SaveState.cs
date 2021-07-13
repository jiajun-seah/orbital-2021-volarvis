using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveState
{
    public DateTime LastSaveTime { set; get; }
    public int SaveCount { set; get; }

    public Dictionary<int, int> inventory { set; get; } //(ingredientDex, qty)
    public int[] crockpot { set; get; }
    public int[] fridge { set; get; }
    public int volastroOneDexNum;
    public int hungerVal;
    public int happinessVal;
    public int[] traits;

    public DateTime lastFedTime;
    public DateTime emptyHungerTime;
    public int hungerAtLastFed;
    public int happinessAtHungerEmpty;

    public DateTime firstVolastroReturnTime;
    public string adventureLocation;

    public int voltz;

    public int[] volastroDiscovery;
    public int[] foodDiscovery;
}