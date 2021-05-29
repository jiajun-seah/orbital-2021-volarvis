using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Tab_Button : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private int tabIndex;
    private Image image;

    private Tab_Controller controller;

    private bool isActive = false;

    private void Awake() {
        controller = FindObjectOfType<Tab_Controller>();
        image = GetComponent<Image>();
    }

    public void setIndex(int _index) {
        tabIndex = _index;
    }

    public void OnPointerClick(PointerEventData eventData) {
        controller.ButtonMouseClick(tabIndex);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!isActive) {
            image.color = controller.mouseEnterColor;
        } 
        controller.ButtonMouseEnter(tabIndex);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!isActive) {
            image.color = controller.normalColor;
        } 
        controller.ButtonMouseExit(tabIndex);
    }

    public void ToggleActive() {
        isActive = !isActive;
        if (isActive) {
            image.color = controller.mouseClickColor; // changing colour of the pressed tab
        }
        else {
            image.color = controller.normalColor;
        }
    }
}
