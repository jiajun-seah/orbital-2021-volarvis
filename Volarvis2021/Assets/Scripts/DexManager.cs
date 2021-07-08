using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DexManager : MonoBehaviour
{
    public static DexManager instance;
    public static DexManager Instance { get { return instance; } }

    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI dexNum;
    [SerializeField] private Image habitat;
    [SerializeField] private Image volastroSprite;
    [SerializeField] private TextMeshProUGUI classificationText;
    [SerializeField] private TextMeshProUGUI originRegionText;

    //req traits values
    [SerializeField] private TextMeshProUGUI fieryVal;
    [SerializeField] private TextMeshProUGUI icyVal;
    [SerializeField] private TextMeshProUGUI magicalVal;
    [SerializeField] private TextMeshProUGUI nauticalVal;
    [SerializeField] private TextMeshProUGUI aerialVal;
    [SerializeField] private TextMeshProUGUI terraVal;

    [SerializeField] private TextMeshProUGUI descText;

    public VolastroScriptableObject volastroScriptableObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //if dexmanager is null means new player, create dex entry with volat by default
        if (this.volastroScriptableObject == null)
        {
            volastroScriptableObject = VolastroManager.instance.volatScriptable;
        }
    }
    public void updateDex()
    {
        //set header
        header.SetText(volastroScriptableObject.volastroName);
        //set dexNum
        dexNum.SetText("#" + volastroScriptableObject.dexNum.ToString());
        //set habitat image
        habitat.sprite = volastroScriptableObject.habitatSprite;
        //set sprite
        volastroSprite.sprite = volastroScriptableObject.volastroSprite;
        //set classification text
        classificationText.SetText(volastroScriptableObject.dexType);
        //set origin region text
        originRegionText.SetText(volastroScriptableObject.dexOrigin);

        //set traits
        fieryVal.SetText(volastroScriptableObject.fieryValReq.ToString());
        icyVal.SetText(volastroScriptableObject.icyValReq.ToString());
        magicalVal.SetText(volastroScriptableObject.magicalValReq.ToString());
        nauticalVal.SetText(volastroScriptableObject.nauticalValReq.ToString());
        aerialVal.SetText(volastroScriptableObject.aerialValReq.ToString());
        terraVal.SetText(volastroScriptableObject.terraValReq.ToString());

        //set desc
        descText.SetText(volastroScriptableObject.volastroName + ", the " 
            + volastroScriptableObject.dexType + " Volastro. "
            + volastroScriptableObject.dexDescription);
    }
}
