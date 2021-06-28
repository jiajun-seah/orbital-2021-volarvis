using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsScript : MonoBehaviour
{
    public static BarsScript instance;
    public static BarsScript Instance { get { return instance; } }
    
    public Image _hungerBar;
    public Image _happinessBar;

    public void Awake() {

        if (instance == null)
        {
            instance = this;
        }


        _hungerBar.fillAmount = 0f;
        _happinessBar.fillAmount = 0f;
    }
}
