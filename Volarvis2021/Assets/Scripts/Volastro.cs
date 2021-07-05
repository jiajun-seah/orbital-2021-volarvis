using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine;

public class Volastro
{
    public event EventHandler onVolastroChanged;


    public static int MAX_STATS = 100;
    public static VolastroScriptableObject[] VOLASTRO_LIST  = 
        new VolastroScriptableObject[] {
        VolastroManager.instance.normalEggScriptable,
        VolastroManager.instance.loveEggScriptable,
        VolastroManager.instance.plantEggScriptable,
        VolastroManager.instance.shadowEggScriptable,

        VolastroManager.instance.volatScriptable,
        VolastroManager.instance.kareScriptable,
        VolastroManager.instance.kornScriptable,
        VolastroManager.instance.shinjaScriptable,
        VolastroManager.instance.paoScriptable,
        VolastroManager.instance.coconautScriptable,
        VolastroManager.instance.dottieScriptable,
        VolastroManager.instance.frosteriScriptable,
        VolastroManager.instance.klayScriptable,
        VolastroManager.instance.letticeScriptable,

        VolastroManager.instance.jammieScriptable,
        VolastroManager.instance.spookieScriptable,
        VolastroManager.instance.ewelambScriptable,
        VolastroManager.instance.sealourScriptable,
        VolastroManager.instance.gossyflairScriptable,
        VolastroManager.instance.molluavaScriptable,
        VolastroManager.instance.mushyScriptable,
        VolastroManager.instance.cephiceScriptable,
        VolastroManager.instance.angelmataScriptable,
        VolastroManager.instance.bonfernoScriptable,

        VolastroManager.instance.pottereneScriptable,
        VolastroManager.instance.capsiflyScriptable,
        VolastroManager.instance.coachiScriptable,
        VolastroManager.instance.pumpskidScriptable,
        VolastroManager.instance.pocusScriptable,
        VolastroManager.instance.explomelloScriptable,
        VolastroManager.instance.parkrostScriptable,
        VolastroManager.instance.crystaScriptable,
        VolastroManager.instance.cupruhScriptable,
        VolastroManager.instance.ambissScriptable,

        VolastroManager.instance.ducklintScriptable,
        VolastroManager.instance.dioxaScriptable,
        VolastroManager.instance.chiropepScriptable,
        VolastroManager.instance.aurarusScriptable,
        VolastroManager.instance.coniiScriptable,
        VolastroManager.instance.snairyScriptable,
        VolastroManager.instance.delangelScriptable,
        VolastroManager.instance.dwoopieScriptable,
        VolastroManager.instance.clareScriptable,
        VolastroManager.instance.mothetteScriptable,

        VolastroManager.instance.carpentrapScriptable,
        VolastroManager.instance.avododoScriptable,
        VolastroManager.instance.carrabbitScriptable,
        VolastroManager.instance.apriciumScriptable,
        VolastroManager.instance.fawnaScriptable,
        VolastroManager.instance.foliaScriptable,
        VolastroManager.instance.lumidleScriptable,
        VolastroManager.instance.uniburdScriptable,
        VolastroManager.instance.dreacoScriptable,
        VolastroManager.instance.tytowlScriptable,

        VolastroManager.instance.glookScriptable,
        VolastroManager.instance.trawlelfScriptable
        };

    public VolastroScriptableObject baseVolastro;
    public int hungerVal;
    public int happinessVal;
    public int[] traitsVal;

    public Volastro()
    {
        this.baseVolastro = VolastroManager.instance.cupruhScriptable;
        this.hungerVal = 0;
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

        Debug.Log("New Volastro: " + this.baseVolastro.volastroName + " created");
    }

    
    public void updateTrait(int hunger, int happiness, int[] foodTraits) {
        
        for (int i = 0; i < 6; i++) {
            this.traitsVal[i] += foodTraits[i];
        }
        this.hungerVal += hunger;
        //max hunger is 100
        this.hungerVal = Math.Min(this.hungerVal, MAX_STATS);
        Debug.Log("Fullness increased to " + this.hungerVal.ToString());

        this.happinessVal += happiness;
        //max hunger is 100
        this.happinessVal = Math.Min(this.happinessVal, MAX_STATS);
        Debug.Log("Fullness increased to " + this.happinessVal.ToString());

        onVolastroChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Traits updated!");
        Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);

        float hungerValAsPercentage =  (this.hungerVal / (float) 100);
        float happinessValAsPercentage =  (this.happinessVal / (float) 100);

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

            Debug.Log("Volastro Evolved!");
            this.baseVolastro = newBaseVolastro;
            Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);
            onVolastroChanged?.Invoke(this, EventArgs.Empty);

            //Update Discovery
            if (!Player.instance.discovery.getDiscoveredVolastros().Contains(this.getDexNum()))
            {
                Player.instance.discovery.addDiscoveredVolastro(this.getDexNum());
            }
        }
        
    }

    public void layEgg()
    {
        this.updateTrait(0, -100, new int[6]);
        int newGrowthStage = 0;
        double eggRng = Random.Range(0, 1);

        List<VolastroScriptableObject> eligibleEggs = new List<VolastroScriptableObject>();

        if (eggRng < baseVolastro.normalEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[0]);
        }
        if (eggRng < baseVolastro.loveEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[1]);
        }
        if (eggRng < baseVolastro.natureEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[2]);
        }
        if (eggRng < baseVolastro.darkEggProb)
        {
            eligibleEggs.Add(VOLASTRO_LIST[3]);
        }

        Debug.Log(eligibleEggs.Count + " possible eggs using RNG");
        int randomIndex = Random.Range(0, eligibleEggs.Count);
        VolastroScriptableObject newBaseVolastro = eligibleEggs[randomIndex];
        Debug.Log("Random index was " + randomIndex + ". " + newBaseVolastro.volastroName + " was selected by rng");

        Debug.Log("Volastro laid an egg!");
        this.baseVolastro = newBaseVolastro;
        Player.instance.volastroOne = new Volastro(this, this.hungerVal, this.happinessVal, this.traitsVal);
        onVolastroChanged?.Invoke(this, EventArgs.Empty);
    }
    public int getDexNum()
    {
        return this.baseVolastro.dexNum;
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
