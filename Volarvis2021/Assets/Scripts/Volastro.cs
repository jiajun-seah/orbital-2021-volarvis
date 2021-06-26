using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volastro
{
    public event EventHandler onVolastroChanged;

    public VolastroScriptableObject baseVolastro;
    public int hungerVal;
    public int happinessVal;
    public int[] traitsVal;

    public Volastro()
    {
        this.baseVolastro = VolastroManager.instance.ambissScriptable;
        this.hungerVal = 100;
        this.happinessVal = 100;
        this.traitsVal = new int[6];

        Debug.Log("Default normal egg Volastro created");
    }

    public Volastro(Volastro oldVolastro, int hungerVal, int happinessVal, int[] traitsVal)
    {
        this.baseVolastro = oldVolastro.baseVolastro;
        this.hungerVal = hungerVal;
        this.happinessVal = happinessVal;
        this.traitsVal = traitsVal;

        Debug.Log("New Volastro: " + this.baseVolastro.volastroName + " created");
    }

    /*public Volastro updateTrait(string traitName, int amount)
    {
        int oldFiery = this.traitsVal[0];
        int oldIcy = this.traitsVal[1];
        int oldMagical = this.traitsVal[2];
        int oldNautical = this.traitsVal[3];
        int oldAerial = this.traitsVal[4];
        int oldTerra = this.traitsVal[5];

        switch (traitName) 
        {
            case "fiery":
                oldFiery = oldFiery + amount;
                break;
            case "icy": 
                oldIcy = oldIcy + amount;
                break;
            case "magical": 
                oldMagical = oldMagical + amount;
                break;
            case "nautical": 
                oldNautical = oldNautical + amount;
                break;
            case "aerial": 
                oldAerial = oldAerial + amount;
                break;
            case "terra": 
                oldTerra = oldTerra + amount;
                break;
        }
        
        onVolastroChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("traits updated");

        return new Volastro(this, this.hungerVal, this.happinessVal, new int[] { oldFiery, oldIcy, oldMagical, oldAerial, oldTerra });
    }*/
    // my method

    public void updateTrait(int hunger, int happiness, int[] foodTraits) {
        Debug.Log(this.traitsVal.Length);
        Debug.Log(foodTraits.Length);
        for (int i = 0; i < 6; i++) {
            this.traitsVal[i] += foodTraits[i];
        }
        this.hungerVal -= hunger;
        this.happinessVal -= happiness;
        onVolastroChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Traits updated!");
        Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);
    }

    public int getFieryVal()
    {
        return this.traitsVal[0];
    }
    public int getIcyVal()
    {
        return this.traitsVal[1];
    }
    public int getMagicalVal()
    {
        return this.traitsVal[2];
    }
    public int getNauticalVal()
    {
        return this.traitsVal[3];
    }
    public int getAerialVal()
    {
        return this.traitsVal[4];
    }
    public int getTerraVal()
    {
        return this.traitsVal[5];
    }
}
