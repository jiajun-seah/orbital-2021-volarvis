using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.onIngredientListChanged += Inventory_onIngredientListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_onIngredientListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
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

            foreach (Ingredient ingredient in inventory.getIngredients())
            {
                if (ingredient.amount > 0)
                {
                    RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();

                    //assign ingredient to its ClickHandler
                    ClickHandler cScript = itemSlotRectTransform.GetComponent<ClickHandler>();
                    cScript.ingredient = ingredient;
                    cScript.type = ingredient.ingredientScriptableObject;

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
                }
                
                
                if (x > 4)
                {
                    x = 0;
                    y--;
                }

            }
        }
    }
    

}

