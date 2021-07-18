using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volastro
{
    public event EventHandler onVolastroChanged;


    public static int MAX_STATS = 100;
    public static int MIN_STATS = 0;

    public VolastroScriptableObject baseVolastro;
    public int hungerVal;
    public int happinessVal;
    public int[] traitsVal;

    public Volastro()
    {
        this.baseVolastro = VolastroManager.instance.volatScriptable;
        this.hungerVal = 100;
        this.happinessVal = 0;
        this.traitsVal = new int[6];

        Debug.Log("Default normal egg Volastro created");
    }

    public Volastro(Volastro oldVolastro, int hungerVal, int happinessVal, int[] traitsVal)
    {
        this.baseVolastro = oldVolastro.baseVolastro;
        this.hungerVal = hungerVal;
        this.happinessVal = happinessVal;
        this.traitsVal = traitsVal;

        Debug.Log("New Volastro: " + this.baseVolastro.volastroName + " updated");
    }

    public Volastro(VolastroScriptableObject volastroScriptableObject, int hungerVal, int happinessVal, int[] traitsVal)
    {
        this.baseVolastro = volastroScriptableObject;
        this.hungerVal = hungerVal;
        this.happinessVal = happinessVal;
        this.traitsVal = traitsVal;

        //Debug.Log("New Volastro: " + this.baseVolastro.volastroName + " created");
    }

    //getters
    public int getDexNum()
    {
        return this.baseVolastro.dexNum;
    }

    public int getHungerVal()
    {
        return this.hungerVal;
    }
    public int getHappinessVal()
    {
        return this.happinessVal;
    }
    public int[] getTraitsVal()
    {
        return this.traitsVal;
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
    public string getHabitat()
    {
        return baseVolastro.dexOrigin;
    }
    public Sprite getSprite()
    {
        return baseVolastro.volastroSprite;
    }
    public Sprite getHabitatSprite()
    {
        return baseVolastro.habitatSprite;
    }
    public string getClassification()
    {
        return baseVolastro.dexType;
    }
    public string ToString()
    {
        return baseVolastro.volastroName;
    }

    public void updateTrait(int hunger, int happiness, int[] foodTraits) {
        
        for (int i = 0; i < 6; i++) {
            this.traitsVal[i] += foodTraits[i];
        }
        this.hungerVal += hunger;
        //max hunger is 100
        this.hungerVal = Math.Min(this.hungerVal, MAX_STATS);
        this.hungerVal = Math.Max(this.hungerVal, MIN_STATS);
        Debug.Log("Fullness increased to " + this.hungerVal.ToString());

        this.happinessVal += happiness;
        //max hunger is 100
        this.happinessVal = Math.Min(this.happinessVal, MAX_STATS);
        this.happinessVal = Math.Max(this.happinessVal, MIN_STATS);

        Debug.Log("Fullness increased to " + this.happinessVal.ToString());

        onVolastroChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Traits updated!");
        //Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);

        float hungerValAsPercentage =  (this.hungerVal / (float) 100);
        float happinessValAsPercentage =  (this.happinessVal / (float) 100);

        Debug.Log(hungerValAsPercentage.ToString());
        Debug.Log(happinessValAsPercentage.ToString());

        // changing the bar
        BarsScript.instance._hungerBar.fillAmount = hungerValAsPercentage;
        BarsScript.instance._happinessBar.fillAmount = happinessValAsPercentage;
    }

    public void rebaseTrait(int hunger, int happiness, int[] foodTraits)
    {

        for (int i = 0; i < 6; i++)
        {
            this.traitsVal[i] = foodTraits[i];
        }
        this.hungerVal = hunger;
        //max hunger is 100
        this.hungerVal = Math.Min(this.hungerVal, MAX_STATS);
        this.hungerVal = Math.Max(this.hungerVal, MIN_STATS);
        Debug.Log("Fullness increased to " + this.hungerVal.ToString());

        this.happinessVal = happiness;
        //max hunger is 100
        this.happinessVal = Math.Min(this.happinessVal, MAX_STATS);
        this.happinessVal = Math.Max(this.happinessVal, MIN_STATS);
        Debug.Log("Fullness increased to " + this.happinessVal.ToString());

        onVolastroChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Traits rebased!");
        //Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);

        float hungerValAsPercentage = (this.hungerVal / (float)100);
        float happinessValAsPercentage = (this.happinessVal / (float)100);

        Debug.Log(hungerValAsPercentage.ToString());
        Debug.Log(happinessValAsPercentage.ToString());

        // changing the bar
        if (BarsScript.instance._hungerBar.fillAmount != null && BarsScript.instance._happinessBar.fillAmount != null)
        {
            BarsScript.instance._hungerBar.fillAmount = hungerValAsPercentage;
            BarsScript.instance._happinessBar.fillAmount = happinessValAsPercentage;
        }
        
    }

    public void rebaseVolastro(VolastroScriptableObject volastroScriptableObject, int hunger, int happiness, int[] foodTraits)
    {
        this.baseVolastro = volastroScriptableObject;

        for (int i = 0; i < 6; i++)
        {
            this.traitsVal[i] = foodTraits[i];
        }
        this.hungerVal = hunger;
        //max hunger is 100
        this.hungerVal = Math.Min(this.hungerVal, MAX_STATS);
        this.hungerVal = Math.Max(this.hungerVal, MIN_STATS);
        Debug.Log("Fullness increased to " + this.hungerVal.ToString());

        this.happinessVal = happiness;
        //max hunger is 100
        this.happinessVal = Math.Min(this.happinessVal, MAX_STATS);
        this.happinessVal = Math.Max(this.happinessVal, MIN_STATS);
        Debug.Log("Fullness increased to " + this.happinessVal.ToString());

        onVolastroChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Volastro rebased!");
        //Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);

        float hungerValAsPercentage = (this.hungerVal / (float)100);
        float happinessValAsPercentage = (this.happinessVal / (float)100);

        Debug.Log(hungerValAsPercentage.ToString());
        Debug.Log(happinessValAsPercentage.ToString());

        // changing the bar
        BarsScript.instance._hungerBar.fillAmount = hungerValAsPercentage;
        BarsScript.instance._happinessBar.fillAmount = happinessValAsPercentage;
    }

    public void evolve()
    {
        if (baseVolastro.growthStage == 4) {
            this.layEgg();
        }
        else
        {

            VolastroScriptableObject[] VOLASTRO_LIST = new VolastroScriptableObject[VolastroManager.instance.getVolastroList().Count];
            VolastroManager.instance.getVolastroList().Values.CopyTo(VOLASTRO_LIST, 0);

            Debug.Log("VOLASTRO_LIST size is: " + VOLASTRO_LIST.Length);

            this.updateTrait(0, -100, new int[6]);
            
            int newGrowthStage = baseVolastro.growthStage + 1;
            VolastroScriptableObject.EggGroup eggGroup = baseVolastro.eggGroup;

            VolastroScriptableObject[] eligibleVolastros =
                VOLASTRO_LIST.Where(v => (v.eggGroup == eggGroup))
                                .Where(v => (v.growthStage == newGrowthStage))
                                .Where(v => (this.getFieryVal() >= v.fieryValReq))
                                .Where(v => (this.getIcyVal() >= v.icyValReq))
                                .Where(v => (this.getMagicalVal() >= v.magicalValReq))
                                .Where(v => (this.getNauticalVal() >= v.nauticalValReq))
                                .Where(v => (this.getAerialVal() >= v.aerialValReq))
                                .Where(v => (this.getTerraVal() >= v.terraValReq))
                                .ToArray();
            Debug.Log(eligibleVolastros.Length + " possible evolutions");
            int randomIndex = Random.Range(0, eligibleVolastros.Length);
            VolastroScriptableObject newBaseVolastro = eligibleVolastros[randomIndex];
            Debug.Log("Random index was " + randomIndex + ". " + newBaseVolastro.volastroName + " was selected by rng");

            this.baseVolastro = newBaseVolastro;

            Debug.Log("Volastro Evolved!");
            Debug.Log("Player's instance volastro: " + Player.instance.volastroOne.ToString());
            
            onVolastroChanged?.Invoke(this, EventArgs.Empty);
            Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);

            ReloadScene();
            

            //Update Discovery
            if (!Player.instance.discovery.getDiscoveredVolastros().Contains(this.getDexNum()))
            {
                Player.instance.discovery.addDiscoveredVolastro(this.getDexNum());
            }
        }
    }


    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void layEgg()
    {

        VolastroScriptableObject[] VOLASTRO_LIST = new VolastroScriptableObject[VolastroManager.instance.getVolastroList().Count];
        VolastroManager.instance.getVolastroList().Values.CopyTo(VOLASTRO_LIST, 0);

        this.rebaseTrait(100, 0, new int[6]);
        int newGrowthStage = 0;
        double eggRng = Random.Range(0, 1);

        List<VolastroScriptableObject> eligibleEggs = new List<VolastroScriptableObject>();

        if (eggRng < baseVolastro.normalEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[5]);
        }
        if (eggRng < baseVolastro.loveEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[6]);
        }
        if (eggRng < baseVolastro.natureEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[7]);
        }
        if (eggRng < baseVolastro.darkEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[8]);
        }

        Debug.Log(eligibleEggs.Count + " possible eggs using RNG");
        int randomIndex = Random.Range(0, eligibleEggs.Count);
        VolastroScriptableObject newBaseVolastro = eligibleEggs[randomIndex];
        Debug.Log("Random index was " + randomIndex + ". " + newBaseVolastro.volastroName + " was selected by rng");

        Debug.Log("Volastro laid an egg!");
        this.baseVolastro = newBaseVolastro;

        onVolastroChanged?.Invoke(this, EventArgs.Empty);

        Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);
        

        ReloadScene();


        //Update Discovery
        if (!Player.instance.discovery.getDiscoveredVolastros().Contains(this.getDexNum()))
        {
            Player.instance.discovery.addDiscoveredVolastro(this.getDexNum());
        }

        //Hatching.instance.volastroOne = this;
        //Hatching.instance.StartHatching();
        //ReloadScene();
    }

   
}
