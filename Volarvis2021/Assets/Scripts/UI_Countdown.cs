using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_Countdown : MonoBehaviour
{
    //properties
    private GoOnAdventure goOnAdventure;
    public TextMeshProUGUI countdownDisplay;
    public TextMeshProUGUI countdownFillerText;
    public Button adventureTab;
    public Button cancelAdventureButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UI_countdown called!");
        //GoOnAdventure.instance.onWentOnAdventure += GoOnAdventure_onWentOnAdventure;
    }

    //public void SetCountdown(GoOnAdventure goOnAdventure)
    //{
    //    this.goOnAdventure = goOnAdventure;
    //    goOnAdventure.onWentOnAdventure += GoOnAdventure_onWentOnAdventure;
    //}

    //private void GoOnAdventure_onWentOnAdventure(object sender, System.EventArgs e)
    //{

    //    if (Player.instance.firstVolastroReturnTime > DateTime.Now)
    //    {
    //        RefreshCountdown();
    //        Debug.Log("First refresh countdown called");
    //    }

    //}

    void Update()
    {
        Debug.Log("UI_countdown update is still being called");

        RefreshCountdown();
    }

    public void RefreshCountdown()
    {


        if (Player.instance.adventureLocation != "")
        {
            TimeSpan durat = (Player.instance.firstVolastroReturnTime - DateTime.Now);
            int countdownTracker = (int)durat.TotalSeconds;
            int countdownTimeHour = durat.Hours;
            int countdownTimeMin = durat.Minutes;
            int countdownTimeSec = durat.Seconds;

            countdownDisplay.SetText(
               countdownTimeHour.ToString() + ":"
               + countdownTimeMin.ToString() + ":"
               + countdownTimeSec.ToString());

            countdownDisplay.gameObject.SetActive(true);
            countdownFillerText.gameObject.SetActive(true);

            cancelAdventureButton.gameObject.SetActive(true);
            adventureTab.interactable = false;
        }
        else
        {
            countdownFillerText.gameObject.SetActive(false);
            countdownDisplay.gameObject.SetActive(false);

            cancelAdventureButton.gameObject.SetActive(false);
            adventureTab.interactable = true;
        }
    }
}
