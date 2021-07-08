using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_FoodDex : MonoBehaviour
{
    private Discovery discovery;
    private Transform dexContainer;
    private Transform dexTemplate;

    private void Awake()
    {
        dexContainer = transform.Find("dexContainer");
        dexTemplate = dexContainer.Find("dexTemplate");

        discovery = Player.instance.discovery;
        discovery.onDiscoveredFoodsListChanged += Discovery_onDiscoveredFoodsListChanged;
        RefreshDex();
    }

    void Start()
    {
        
    }

    public void SetDiscovery(Discovery discovery)
    {
        this.discovery = discovery;
        discovery.onDiscoveredFoodsListChanged += Discovery_onDiscoveredFoodsListChanged;
        RefreshDex();
    }

    private void Discovery_onDiscoveredFoodsListChanged(object sender, System.EventArgs e)
    {
        RefreshDex();
    }

    public void RefreshDex()
    {
        if (dexContainer != null)
        {
            foreach (Transform child in dexContainer)
            {
                if (child == dexTemplate) continue;
                Destroy(child.gameObject);
            }


            int x = 0;
            int y = 0;
            float itemSlotCellSize = 45f;

            foreach (KeyValuePair<int, FoodScriptableObject> entry in FoodManager.instance.getFoodList())
            {
                FoodScriptableObject food = entry.Value;
                RectTransform dexRectTransform = Instantiate(dexTemplate, dexContainer).GetComponent<RectTransform>();
                Button viewEntryButton = dexRectTransform.GetComponent<Button>();



                //unhide the slot
                dexRectTransform.gameObject.SetActive(true);
                //set position
                dexRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                if (discovery == null)
                {
                    Debug.Log("discovery is null");
                }
                
                if (discovery.getDiscoveredFoods().Contains(food.dexNum))
                {
                    viewEntryButton.interactable = true;
                    //set sprite icon
                    Image image = dexRectTransform.Find("icon").GetComponent<Image>();
                    image.sprite = food.foodSprite;
                    //set stack count
                    TextMeshProUGUI uiText = dexRectTransform.Find("foodName").GetComponent<TextMeshProUGUI>();
                    uiText.SetText(food.foodName);

                    //assign ingredient to its ClickHandler
                    ClickHandlerLibrary cScript = dexRectTransform.GetComponent<ClickHandlerLibrary>();
                    cScript.foodScriptableObject = food;

                    Debug.Log("Clickhandler assigned " + FoodManager.instance.getFoodList()[entry.Key].foodName);
                    

                }

                else
                {
                    //set sprite icon
                    Image image = dexRectTransform.Find("icon").GetComponent<Image>();
                    image.sprite = food.foodShadowSprite;
                    //set stack count
                    TextMeshProUGUI uiText = dexRectTransform.Find("foodName").GetComponent<TextMeshProUGUI>();
                    uiText.SetText("?????");
                    viewEntryButton.interactable = false;
                }
                
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

