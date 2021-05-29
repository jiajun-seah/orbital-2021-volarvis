using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;

    public Image background;

    public void OnPointerClick(PointerEventData eventData) {
        tabGroup.onTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tabGroup.onTabExit(this);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        tabGroup.onTabEnter(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Suscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
