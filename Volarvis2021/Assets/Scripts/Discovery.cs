using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discovery
{
    public event EventHandler onDiscoveredFoodsListChanged;
    public event EventHandler onDiscoveredVolastrosListChanged;

    private List<int> discoveredFoods;
    private List<int> discoveredVolastros;

    public Discovery()
    {
        discoveredFoods = new List<int>();
        discoveredVolastros = new List<int>();
        discoveredVolastros.Add(1);

        Debug.Log("New discovery storage created");
    }

    public Discovery(List<int> dFoods, List<int> dVolastros)
    {
        discoveredFoods = dFoods;
        discoveredVolastros = dVolastros;

        Debug.Log("new discovery storage created from 2 lists");
    }

    public void addDiscoveredFood(int dexNum)
    {
        discoveredFoods.Add(dexNum);

        onDiscoveredFoodsListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Food dex num " + dexNum.ToString() + " added to discovery.");
    }

    public void addDiscoveredVolastro(int dexNum)
    {
        discoveredVolastros.Add(dexNum);

        onDiscoveredVolastrosListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Volastro dex num " + dexNum.ToString() + " added to discovery.");
    }

    //Remove method for completeness (although in theory a Player's discovery should only expand)
    public void removeDiscoveredFood(int dexNum)
    {
        discoveredFoods.Remove(dexNum);

        onDiscoveredFoodsListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Food dex num " + dexNum.ToString() + " removed from discovery.");
    }

    //Remove method for completeness (although in theory a Player's discovery should only expand)
    public void removeDiscoveredVolastro(int dexNum)
    {
        discoveredVolastros.Remove(dexNum);

        onDiscoveredVolastrosListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Volastro dex num " + dexNum.ToString() + " removed from discovery.");
    }

    public List<int> getDiscoveredFoods()
    {
        return discoveredFoods;
    }

    public List<int> getDiscoveredVolastros()
    {
        return discoveredVolastros;
    }
}
