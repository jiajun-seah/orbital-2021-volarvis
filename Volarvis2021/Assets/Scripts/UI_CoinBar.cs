using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CoinBar: MonoBehaviour
{
    private int voltz;
    private Transform coinBarContainer;

    private void Awake()
    {
        coinBarContainer = transform.Find("coinBarContainer");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetVoltzAmount(int voltz)
    {
        Debug.Log("voltz was set.");

        this.voltz = voltz;
        Player.instance.onVoltzAmountChanged += Player_onVoltzAmountChanged;
        RefreshVoltzAmount();
    }

    private void Player_onVoltzAmountChanged(object sender, System.EventArgs e)
    {
        RefreshVoltzAmount();
    }

    public void RefreshVoltzAmount()
    {
        if (coinBarContainer!= null)
        {
            Debug.Log("voltz ui was refreshed");
            TextMeshProUGUI uiText = coinBarContainer.Find("voltz_amount").GetComponent<TextMeshProUGUI>();
            //set stack count
            uiText.SetText(Player.instance.voltz.ToString());
        }
        

    }
}

