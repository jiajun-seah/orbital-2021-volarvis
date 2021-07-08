using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/VolastroScriptableObject")]
public class VolastroScriptableObject : ScriptableObject
{
    public enum EggGroup
    {
        Normal,
        Love,
        Nature,
        Dark
    }

    [Range(-4, 52)]
    public int dexNum; 
    public string volastroName;

    [Range(0, 4)]
    public int growthStage; //egg - 0, baby - 1, child - 2, teen - 3, adult - 4;
    public string dexType;
    public string dexOrigin;
    public string dexDescription;
    public Sprite volastroSprite;
    public Sprite volastroShadowSprite;
    public Sprite habitatSprite;
    public EggGroup eggGroup;

    [Range(0, 1)]
    public float normalEggProb;
    [Range(0, 1)]
    public float loveEggProb;
    [Range(0, 1)]
    public float natureEggProb;
    [Range(0, 1)]
    public float darkEggProb;

    [Range(0, 20)]
    public int fieryValReq;
    [Range(0, 20)]
    public int icyValReq;
    [Range(0, 20)]
    public int magicalValReq;
    [Range(0, 20)]
    public int nauticalValReq;
    [Range(0, 20)]
    public int aerialValReq;
    [Range(0, 20)]
    public int terraValReq;
}
