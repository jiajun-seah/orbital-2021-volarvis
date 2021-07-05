using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShopIngredient : MonoBehaviour
{
    private Shop shop;
    private Transform listingContainer;
    private Transform listingTemplate;

    private void Awake()
    {
        listingContainer = transform.Find("listingContainer");
        listingTemplate = listingContainer.Find("listingTemplate");
    }

    public void SetShop(Shop shop)
    {
        Debug.Log("Set Shop called");
        this.shop = shop;

        this.shop.refreshIngredientStock();

        shop.onIngredientListChanged += Shop_onIngredientListChanged;
        RefreshIngredientStock();
    }

    private void Shop_onIngredientListChanged(object sender, System.EventArgs e)
    {
        RefreshIngredientStock();
    }


    public void RefreshIngredientStock()
    {
        Debug.Log("Ingredient stock UI refreshed.");
        if (listingContainer == null)
        {
            Debug.Log("listingContainer(ingredient) is null");
        }
        if (listingContainer != null)
        {
           
            int x = 0;
            int y = 0;
            float itemSlotCellSize = 140f;

            foreach (Ingredient ingredient in shop.getIngredients())
            {
                Debug.Log("UI shown for " +  ingredient.ToString());
                RectTransform listingRectTransform = Instantiate(listingTemplate, listingContainer).GetComponent<RectTransform>();

                //assign ingredient to its ClickHandler
                ClickHandlerShop cScript = listingRectTransform.GetComponent<ClickHandlerShop>();
                cScript.ingredient = ingredient;
                cScript.ingredientScriptableObject = ingredient.ingredientScriptableObject;

                //unhide the slot
                listingRectTransform.gameObject.SetActive(true);
                //set position
                listingRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                //set sprite icon
                Image image = listingRectTransform.Find("icon").GetComponent<Image>();
                image.sprite = ingredient.getSprite();
                //set name
                TextMeshProUGUI uiText = listingRectTransform.Find("name").GetComponent<TextMeshProUGUI>();
                uiText.SetText(ingredient.ToString());
                //set price
                TextMeshProUGUI uiText1 = listingRectTransform.Find("price").GetComponent<TextMeshProUGUI>();
                uiText1.SetText(ingredient.getPrice().ToString());

                x++;
                


                if (x > 0)
                {
                    x = 0;
                    y--;
                }

            }
        }
    }


}

