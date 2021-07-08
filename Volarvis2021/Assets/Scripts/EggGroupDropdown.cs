using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGroupDropdown : MonoBehaviour
{
    [SerializeField] private Transform normalEggContent;
    [SerializeField] private Transform loveEggContent;
    [SerializeField] private Transform natureEggContent;
    [SerializeField] private Transform darkEggContent;

    public void HandleInputData(int value)
    {
        switch (value)
        {
            case 0:
                normalEggContent.gameObject.SetActive(true);
                loveEggContent.gameObject.SetActive(false);
                natureEggContent.gameObject.SetActive(false);
                darkEggContent.gameObject.SetActive(false);
                break;
            case 1:
                normalEggContent.gameObject.SetActive(false);
                loveEggContent.gameObject.SetActive(true);
                natureEggContent.gameObject.SetActive(false);
                darkEggContent.gameObject.SetActive(false);
                break;
            case 2:
                normalEggContent.gameObject.SetActive(false);
                loveEggContent.gameObject.SetActive(false);
                natureEggContent.gameObject.SetActive(true);
                darkEggContent.gameObject.SetActive(false);
                break;
            case 3:
                normalEggContent.gameObject.SetActive(false);
                loveEggContent.gameObject.SetActive(false);
                natureEggContent.gameObject.SetActive(false);
                darkEggContent.gameObject.SetActive(true);
                break;
        }
    }

}
