using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/VolastroScriptableObject")]
public class VolastroScriptableObject : ScriptableObject
{
    [Range(-4, 52)]
    public int dexNum; 
    public string volastroName;

    [Range(0, 4)]
    public int growthStage; //egg - 0, baby - 1, child - 2, teen - 3, adult - 4;
    public string dexType;
    public string dexOrigin;
    public string dexDescription;
    public Sprite volastroSprite;
}
