using GooglePlayGames.BasicApi.SavedGame;
using System;
using TMPro;
using UnityEngine;

public class CloudSaveTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;

    private void Start()
    {
        CloudSaveManager.Instance.OnSave += AfterSave;
        CloudSaveManager.Instance.OnLoad += AfterLoad;
    }

    public void AfterSave(SavedGameRequestStatus status)
    {
        switch (status)
        {
            case SavedGameRequestStatus.Success:
                
                debugText.text = "Saving.. : " + CloudSaveManager.Instance.State.SaveCount.ToString() + " at " + CloudSaveManager.Instance.State.LastSaveTime.ToString();
                break;
            default:
                debugText.text = status.ToString();
                break;
        }
    }
    public void AfterLoad(SavedGameRequestStatus status)
    {
        try
        {
            switch (status)
            {
                case SavedGameRequestStatus.Success:
                    
                    Player.instance.loadPlayerFromState();
                    
                    debugText.text = "Loaded save! : " + CloudSaveManager.Instance.State.SaveCount.ToString() + " from " + CloudSaveManager.Instance.State.LastSaveTime.ToString();
                    break;
                default:
                    debugText.text = status.ToString();
                    break;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    private void OnPlayError(PlayServiceError obj)
    {
        debugText.text = obj.ToString();
    }

    public void Save()
    {
        //Rearranged SaveCount increment and LastSaveTime assignement
        CloudSaveManager.Instance.State.SaveCount++;
        CloudSaveManager.Instance.State.LastSaveTime = DateTime.Now;

        Player.instance.savePlayerToState();

        debugText.text = "Saving to cloud...";
        CloudSaveManager.Instance.SaveToCloud(OnPlayError);
        
    }
    public void Load()
    {
        debugText.text = "Loading from cloud...";
        CloudSaveManager.Instance.LoadFromCloud(OnPlayError);
        
    }
    public void Login()
    {
        debugText.text = "Login...";
        PlayService.Instance.SignIn(OnLoginSuccess,OnLoginFail);
    }

    public void LoginOnly()
    {
        debugText.text = "Login only.";
        PlayService.Instance.SignIn(OnLoginOnlySuccess, OnLoginFail);
    }

    public void Logout()
    {
        debugText.text = "Logged out!";
        PlayService.Instance.SignOut();
    }
    private void OnLoginSuccess()
    {
        debugText.text = "Successful login! Attempting to load save file";
        Load();
    }
    private void OnLoginOnlySuccess()
    {
        debugText.text = "Successful login!";
    }
    private void OnLoginFail()
    {
        debugText.text = "Failed to log in";
    }
}
