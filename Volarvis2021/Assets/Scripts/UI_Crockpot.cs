using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Crockpot : MonoBehaviour
{
    private Crockpot crockpot;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetCrockpot(Crockpot crockpot)
    {
        this.crockpot = crockpot;
        crockpot.onCrockpotListChanged += Crockpot_onCrockpotListChanged;
        RefreshCrockpotItems();
    }

    private void Crockpot_onCrockpotListChanged(object sender, System.EventArgs e)
    {
        RefreshCrockpotItems();
    }

    private void RefreshCrockpotItems()
    {
        if (itemSlotContainer != null)
        {
            foreach (Transform child in itemSlotContainer)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }


            int x = 0;
            int y = 0;
            float itemSlotCellSize = 50f;

            foreach (Ingredient ingredient in crockpot.getIngredients())
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();

                //unhide the slot
                itemSlotRectTransform.gameObject.SetActive(true);
                //set position
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                //set sprite icon
                Image image = itemSlotRectTransform.Find("icon").GetComponent<Image>();
                image.sprite = ingredient.getSprite();
                //set stack count
                TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
                uiText.SetText(ingredient.amount.ToString());



                x++;
                if (x > 1)
                {
                    x = 0;
                    y--;
                }

            }
        }
    }


}

