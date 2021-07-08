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

    Dictionary<int, VolastroScriptableObject> volastroList = new Dictionary<int, VolastroScriptableObject>();
    

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

        volastroList.Add(-4, normalEggScriptable);
        volastroList.Add(-3, loveEggScriptable);
        volastroList.Add(-2, plantEggScriptable);
        volastroList.Add(-1, shadowEggScriptable);

        //0-10
        volastroList.Add(0, defaultScriptable);
        volastroList.Add(1, volatScriptable);
        volastroList.Add(2, kareScriptable);
        volastroList.Add(3, kornScriptable);
        volastroList.Add(4, shinjaScriptable);
        volastroList.Add(5, paoScriptable);
        volastroList.Add(6, coconautScriptable);
        volastroList.Add(7,  dottieScriptable);
        volastroList.Add(8,  frosteriScriptable);
        volastroList.Add(9,  klayScriptable);
        volastroList.Add(10,  letticeScriptable);

        //11-20
        volastroList.Add(11,  jammieScriptable);
        volastroList.Add(12,  spookieScriptable);
        volastroList.Add(13,  ewelambScriptable);
        volastroList.Add(14,  sealourScriptable);
        volastroList.Add(15,  gossyflairScriptable);
        volastroList.Add(16,  molluavaScriptable);
        volastroList.Add(17,  mushyScriptable);
        volastroList.Add(18,  cephiceScriptable);
        volastroList.Add(19,  angelmataScriptable);
        volastroList.Add(20,  bonfernoScriptable);

        //21-30
        volastroList.Add(21,  pottereneScriptable);
        volastroList.Add(22,  capsiflyScriptable);
        volastroList.Add(23,  coachiScriptable);
        volastroList.Add(24,  pumpskidScriptable);
        volastroList.Add(25,  pocusScriptable);
        volastroList.Add(26,  explomelloScriptable);
        volastroList.Add(27,  parkrostScriptable);
        volastroList.Add(28,  crystaScriptable);
        volastroList.Add(29,  cupruhScriptable);
        volastroList.Add(30,  ambissScriptable);

        //31-40
        volastroList.Add(31,  ducklintScriptable);
        volastroList.Add(32,  dioxaScriptable);
        volastroList.Add(33,  chiropepScriptable);
        volastroList.Add(34,  aurarusScriptable);
        volastroList.Add(35,  coniiScriptable);
        volastroList.Add(36,  snairyScriptable);
        volastroList.Add(37,  delangelScriptable);
        volastroList.Add(38,  dwoopieScriptable);
        volastroList.Add(39,  clareScriptable);
        volastroList.Add(40,  mothetteScriptable);

        //41-50
        volastroList.Add(41,  carpentrapScriptable);
        volastroList.Add(42,  avododoScriptable);
        volastroList.Add(43,  carrabbitScriptable);
        volastroList.Add(44,  apriciumScriptable);
        volastroList.Add(45,  fawnaScriptable);
        volastroList.Add(46,  foliaScriptable);
        volastroList.Add(47,  lumidleScriptable);
        volastroList.Add(48,  uniburdScriptable);
        volastroList.Add(49,  dreacoScriptable);
        volastroList.Add(50,  tytowlScriptable);

        //51-52
        volastroList.Add(51,  glookScriptable);
        volastroList.Add(52,  trawlelfScriptable);
    }

    public Dictionary<int, VolastroScriptableObject> getVolastroList()
    {
        return this.volastroList;
    }
}
