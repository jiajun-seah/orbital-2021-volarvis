using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.UI;

public class GoogleSave : MonoBehaviour
{
    [SerializeField] Text debugtext;
    [SerializeField] InputField leaderboard;
    [SerializeField] InputField datatocloud;
    // cloud saving
    private bool issaving = false;
    private string SAVE_NAME = "savegames";

    public void OpenSaveToCloud(bool saving) {
        if (Social.localUser.authenticated) {
            issaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution;
                (SAVE_NAME, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, 
                ConflictResolutionStrategy.UseLongestPlaytime, SavedGameOpen);
        }
    }

    private void SavedGameOpen(SavedGameRequestStatus status, ISavedGameMetadata arg2) {
        if(status == SavedGameRequestStatus.Success) {
            if(issaving) { // if issaving is true we are saving our data to cloud
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetDataToStoreinCloud());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, saveupdate)
            }
            else { //if is saving is false we are opening our saved data
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, ReadDataFromCloud);
            }
        }
    }

    private void ReadDataFromCloud(SavedGameRequestStatus status, byte[] data) {
        if (status == SavedGameRequestStatus.Success) {
            string savedata = System.Text.ASCIIEncoding.ASCII.GetString(data);
            LoadDataFromCloudToOurGame(savedata);
        }
    }

    private void LoadDataFromCloudToOurGame(string savedata) {
        string[] data = savedata.Split('|');
        debugtext.text = data[0];
    }

    private void saveupdate(SavedGameRequestStatus status, ISavedGameMetadata meta) {
        //use this to debug whether the game is uploaded to cloud
        debugtext.text = "Successfully added data to cloud";
    }
    private string GetDataToStoreinCloud() { // set the value that we are going to store the data
        string Data = "";
        Data += datatocloud.text;
        Data += "|";
        // data [1]
        Data += "some text";
        
        return Data;
    }
}
