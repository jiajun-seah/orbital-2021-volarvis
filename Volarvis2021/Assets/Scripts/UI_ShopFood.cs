using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShopFood : MonoBehaviour
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

        this.shop.refreshFoodStock();

        shop.onFoodListChanged += Shop_onFoodListChanged;
        RefreshFoodStock();
    }

    private void Shop_onFoodListChanged(object sender, System.EventArgs e)
    {
        RefreshFoodStock();
    }


    public void RefreshFoodStock()
    {
        Debug.Log("Food stock UI refreshed.");
        if (listingContainer == null)
        {
            Debug.Log("listingContainer(food) is null");
        }
        if (listingContainer != null)
        {

            int x = 0;
            int y = 0;
            float itemSlotCellSize = 140f;

            foreach (Food food in shop.getFoods())
            {
                Debug.Log("UI shown for " + food.ToString());
                RectTransform listingRectTransform = Instantiate(listingTemplate, listingContainer).GetComponent<RectTransform>();

                //assign ingredient to its ClickHandler
                ClickHandlerShop cScript = listingRectTransform.GetComponent<ClickHandlerShop>();
                cScript.food = food;
                cScript.foodScriptableObject = food.foodScriptableObject;

                //unhide the slot
                listingRectTransform.gameObject.SetActive(true);
                //set position
                listingRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                //set sprite icon
                Image image = listingRectTransform.Find("icon").GetComponent<Image>();
                image.sprite = food.getSprite();
                //set name
                TextMeshProUGUI uiText = listingRectTransform.Find("name").GetComponent<TextMeshProUGUI>();
                uiText.SetText(food.ToString());
                //set price
                TextMeshProUGUI uiText1 = listingRectTransform.Find("price").GetComponent<TextMeshProUGUI>();
                uiText1.SetText(food.getPrice().ToString());

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

