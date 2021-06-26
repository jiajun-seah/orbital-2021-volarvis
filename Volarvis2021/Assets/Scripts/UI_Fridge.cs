using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fridge : MonoBehaviour
{
    private Fridge fridge;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetFridge(Fridge fridge)
    {
        this.fridge = fridge;
        fridge.onFoodListChanged += Fridge_onFoodListChanged;
        RefreshFridgeItems();
    }

    private void Fridge_onFoodListChanged(object sender, System.EventArgs e)
    {
        RefreshFridgeItems();
    }

    public void RefreshFridgeItems()
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
            float itemSlotCellSize = 38f;

            foreach (Food food in fridge.getFoods())
            {
                if (food.amount > 0)
                {
                    RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();

                    //assign ingredient to its ClickHandler
                    ClickHandlerHome cScript = itemSlotRectTransform.GetComponent<ClickHandlerHome>();
                    cScript.food = food;
                    cScript.type = food.foodScriptableObject;

                    //unhide the slot
                    itemSlotContainer.gameObject.SetActive(true);
                    itemSlotRectTransform.gameObject.SetActive(true);
                    //set position
                    itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                    //set sprite icon
                    Image image = itemSlotRectTransform.Find("icon").GetComponent<Image>();
                    image.sprite = food.getSprite();
                    //set stack count
                    //TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
                    //uiText.SetText(food.amount.ToString());

                    x++;
                }


                if (x > 3)
                {
                    x = 0;
                    y--;
                }

            }
        }
    }


}

