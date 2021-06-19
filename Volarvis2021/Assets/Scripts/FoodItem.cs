using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FoodItem", menuName = "FoodItem")] 
public class FoodItem : ScriptableObject
{
    public int dexNum;
    public new string name;
    public Sprite icon;

    public int hunger = 0;

    public int fieryVal = 0;
    public int icyVal = 0;
    public int magicalVal = 0;
    public int nauticalVal = 0;
    public int aerialVal = 0;
    public int terraVal = 0;
}
