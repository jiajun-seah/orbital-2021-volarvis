using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBar : MonoBehaviour
{

    public void GoToHome()
    {
        SceneManager.LoadScene("HomePage");
        Debug.Log("Go to Home");
    }

    public void GoToCook()
    {
        SceneManager.LoadScene("CookPage");
        Debug.Log("Go to Cook");
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("ShopPage");
        Debug.Log("Go to Shop");
    }

    public void GoToLibrary()
    {
        SceneManager.LoadScene("LibraryPage");
        Debug.Log("Go to Library");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsPage");
        Debug.Log("Go to Settings");
    }

}
