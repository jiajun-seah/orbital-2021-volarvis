using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hatching : MonoBehaviour
{
    public static Hatching instance;
    public static Hatching Instance { get { return instance; } }


    public Volastro volastroOne;

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

    void Start()
    {
    }

    public void StartHatching()
    {
        StartCoroutine(HatchEgg());
    }

    IEnumerator HatchEgg()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Egg hatched. Now evolving to baby");
        volastroOne.evolve();
        Debug.Log("Volastro evolved to baby");
    }

}
