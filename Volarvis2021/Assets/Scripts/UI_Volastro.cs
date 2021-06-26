using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Volastro : MonoBehaviour
{
    private Volastro volastro;
    private Transform volastroSprite;
    private Transform traitsContainer;

    

    private void Awake()
    {
        volastroSprite = transform.Find("volastroSprite");
        traitsContainer = transform.Find("traitsTextContainer");
    }

    public void SetVolastro(Volastro volastro)
    {
        this.volastro = volastro;
        volastro.onVolastroChanged += Volastro_onVolastroChanged;
        RefreshVolastro();
    }

    private void Volastro_onVolastroChanged(object sender, System.EventArgs e)
    {
        RefreshVolastro();
    }

    private void RefreshVolastro()
    {

        /*    
        foreach (Transform child in itemSlotContainer)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }
        */


        /*
        RectTransform volastroSpriteRectTransform = Instantiate(volastroSprite).GetComponent<RectTransform>();
        RectTransform volastroTraitsRectTransform = Instantiate(traitsContainer).GetComponent<RectTransform>();
        */

        //unhide the volastro and traits
        volastroSprite.gameObject.SetActive(true);
        traitsContainer.gameObject.SetActive(true);
        
        //set sprite icon
        Image image = volastroSprite.GetComponent<Image>();
        image.sprite = volastro.baseVolastro.volastroSprite;

        //set traits values
        TextMeshProUGUI fieryText = traitsContainer.Find("fieryVal").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI icyText = traitsContainer.Find("icyVal").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI magicalText = traitsContainer.Find("magicalVal").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nauticalText = traitsContainer.Find("nauticalVal").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI aerialText = traitsContainer.Find("aerialVal").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI terraText = traitsContainer.Find("terraVal").GetComponent<TextMeshProUGUI>();

        fieryText.SetText(volastro.getFieryVal().ToString());
        icyText.SetText(volastro.getIcyVal().ToString());
        magicalText.SetText(volastro.getMagicalVal().ToString());
        nauticalText.SetText(volastro.getNauticalVal().ToString());
        aerialText.SetText(volastro.getAerialVal().ToString());
        terraText.SetText(volastro.getTerraVal().ToString());


    }


}