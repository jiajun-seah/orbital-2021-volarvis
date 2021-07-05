using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolastroManager : MonoBehaviour
{
    public static VolastroManager instance;
    public static VolastroManager Instance { get { return instance; } }

    //volastro (scriptable)

    //-1 - -4
    public VolastroScriptableObject normalEggScriptable;
    public VolastroScriptableObject loveEggScriptable;
    public VolastroScriptableObject plantEggScriptable;
    public VolastroScriptableObject shadowEggScriptable;

    //0-10
    public VolastroScriptableObject defaultScriptable;
    public VolastroScriptableObject volatScriptable;
    public VolastroScriptableObject kareScriptable;
    public VolastroScriptableObject kornScriptable;
    public VolastroScriptableObject shinjaScriptable;
    public VolastroScriptableObject paoScriptable;
    public VolastroScriptableObject coconautScriptable;
    public VolastroScriptableObject dottieScriptable;
    public VolastroScriptableObject frosteriScriptable;
    public VolastroScriptableObject klayScriptable;
    public VolastroScriptableObject letticeScriptable;

    //11-20
    public VolastroScriptableObject jammieScriptable;
    public VolastroScriptableObject spookieScriptable;
    public VolastroScriptableObject ewelambScriptable;
    public VolastroScriptableObject sealourScriptable;
    public VolastroScriptableObject gossyflairScriptable;
    public VolastroScriptableObject molluavaScriptable;
    public VolastroScriptableObject mushyScriptable;
    public VolastroScriptableObject cephiceScriptable;
    public VolastroScriptableObject angelmataScriptable;
    public VolastroScriptableObject bonfernoScriptable;

    //21-30
    public VolastroScriptableObject pottereneScriptable;
    public VolastroScriptableObject capsiflyScriptable;
    public VolastroScriptableObject coachiScriptable;
    public VolastroScriptableObject pumpskidScriptable;
    public VolastroScriptableObject pocusScriptable;
    public VolastroScriptableObject explomelloScriptable;
    public VolastroScriptableObject parkrostScriptable;
    public VolastroScriptableObject crystaScriptable;
    public VolastroScriptableObject cupruhScriptable;
    public VolastroScriptableObject ambissScriptable;

    //31-40
    public VolastroScriptableObject ducklintScriptable;
    public VolastroScriptableObject dioxaScriptable;
    public VolastroScriptableObject chiropepScriptable;
    public VolastroScriptableObject aurarusScriptable;
    public VolastroScriptableObject coniiScriptable;
    public VolastroScriptableObject snairyScriptable;
    public VolastroScriptableObject delangelScriptable;
    public VolastroScriptableObject dwoopieScriptable;
    public VolastroScriptableObject clareScriptable;
    public VolastroScriptableObject mothetteScriptable;

    //41-50
    public VolastroScriptableObject carpentrapScriptable;
    public VolastroScriptableObject avododoScriptable;
    public VolastroScriptableObject carrabbitScriptable;
    public VolastroScriptableObject apriciumScriptable;
    public VolastroScriptableObject fawnaScriptable;
    public VolastroScriptableObject foliaScriptable;
    public VolastroScriptableObject lumidleScriptable;
    public VolastroScriptableObject uniburdScriptable;
    public VolastroScriptableObject dreacoScriptable;
    public VolastroScriptableObject tytowlScriptable;

    //51-52
    public VolastroScriptableObject glookScriptable;
    public VolastroScriptableObject trawlelfScriptable;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
}
