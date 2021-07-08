using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DexBar : MonoBehaviour
{
    public Discovery discovery;
    [SerializeField] private Transform normalEggGroup;
    [SerializeField] private Transform loveEggGroup;
    [SerializeField] private Transform natureEggGroup;
    [SerializeField] private Transform darkEggGroup;

    private Transform normalBaby1;
    private Transform normalChild1;
    private Transform normalChild2;
    private Transform normalTeen1;
    private Transform normalTeen2;
    private Transform normalTeen3;
    private Transform normalTeen4;
    private Transform normalAdult1;
    private Transform normalAdult2;
    private Transform normalAdult3;
    private Transform normalAdult4;
    private Transform normalAdult5;
    private Transform normalAdult6;

    private Transform loveBaby1;
    private Transform loveChild1;
    private Transform loveChild2;
    private Transform loveTeen1;
    private Transform loveTeen2;
    private Transform loveTeen3;
    private Transform loveTeen4;
    private Transform loveAdult1;
    private Transform loveAdult2;
    private Transform loveAdult3;
    private Transform loveAdult4;
    private Transform loveAdult5;
    private Transform loveAdult6;

    private Transform natureBaby1;
    private Transform natureChild1;
    private Transform natureChild2;
    private Transform natureTeen1;
    private Transform natureTeen2;
    private Transform natureTeen3;
    private Transform natureTeen4;
    private Transform natureAdult1;
    private Transform natureAdult2;
    private Transform natureAdult3;
    private Transform natureAdult4;
    private Transform natureAdult5;
    private Transform natureAdult6;

    private Transform darkBaby1;
    private Transform darkChild1;
    private Transform darkChild2;
    private Transform darkTeen1;
    private Transform darkTeen2;
    private Transform darkTeen3;
    private Transform darkTeen4;
    private Transform darkAdult1;
    private Transform darkAdult2;
    private Transform darkAdult3;
    private Transform darkAdult4;
    private Transform darkAdult5;
    private Transform darkAdult6;


    // buttons
    private Button normalBaby1Button;
    private Button normalChild1Button;
    private Button normalChild2Button;
    private Button normalTeen1Button;
    private Button normalTeen2Button;
    private Button normalTeen3Button;
    private Button normalTeen4Button;
    private Button normalAdult1Button;
    private Button normalAdult2Button;
    private Button normalAdult3Button;
    private Button normalAdult4Button;
    private Button normalAdult5Button;
    private Button normalAdult6Button;

    private Button loveBaby1Button;
    private Button loveChild1Button;
    private Button loveChild2Button;
    private Button loveTeen1Button;
    private Button loveTeen2Button;
    private Button loveTeen3Button;
    private Button loveTeen4Button;
    private Button loveAdult1Button;
    private Button loveAdult2Button;
    private Button loveAdult3Button;
    private Button loveAdult4Button;
    private Button loveAdult5Button;
    private Button loveAdult6Button;

    private Button natureBaby1Button;
    private Button natureChild1Button;
    private Button natureChild2Button;
    private Button natureTeen1Button;
    private Button natureTeen2Button;
    private Button natureTeen3Button;
    private Button natureTeen4Button;
    private Button natureAdult1Button;
    private Button natureAdult2Button;
    private Button natureAdult3Button;
    private Button natureAdult4Button;
    private Button natureAdult5Button;
    private Button natureAdult6Button;

    private Button darkBaby1Button;
    private Button darkChild1Button;
    private Button darkChild2Button;
    private Button darkTeen1Button;
    private Button darkTeen2Button;
    private Button darkTeen3Button;
    private Button darkTeen4Button;
    private Button darkAdult1Button;
    private Button darkAdult2Button;
    private Button darkAdult3Button;
    private Button darkAdult4Button;
    private Button darkAdult5Button;
    private Button darkAdult6Button;



    private void Awake()
    {
        //assign Transform objects to each box, then add them into a dict of Transforms
        //Normal
        normalBaby1 = normalEggGroup.Find("baby");
        normalChild1 = normalEggGroup.Find("child1");
        normalChild2 = normalEggGroup.Find("child2");
        normalTeen1 = normalEggGroup.Find("teen1");
        normalTeen2 = normalEggGroup.Find("teen2");
        normalTeen3 = normalEggGroup.Find("teen3");
        normalTeen4 = normalEggGroup.Find("teen4");
        normalAdult1 = normalEggGroup.Find("adult1");
        normalAdult2 = normalEggGroup.Find("adult2");
        normalAdult3 = normalEggGroup.Find("adult3");
        normalAdult4 = normalEggGroup.Find("adult4");
        normalAdult5 = normalEggGroup.Find("adult5");
        normalAdult6 = normalEggGroup.Find("adult6");

        //Love
        loveBaby1 = loveEggGroup.Find("baby");
        loveChild1 = loveEggGroup.Find("child1");
        loveChild2 = loveEggGroup.Find("child2");
        loveTeen1 = loveEggGroup.Find("teen1");
        loveTeen2 = loveEggGroup.Find("teen2");
        loveTeen3 = loveEggGroup.Find("teen3");
        loveTeen4 = loveEggGroup.Find("teen4");
        loveAdult1 = loveEggGroup.Find("adult1");
        loveAdult2 = loveEggGroup.Find("adult2");
        loveAdult3 = loveEggGroup.Find("adult3");
        loveAdult4 = loveEggGroup.Find("adult4");
        loveAdult5 = loveEggGroup.Find("adult5");
        loveAdult6 = loveEggGroup.Find("adult6");

        natureBaby1 = natureEggGroup.Find("baby");
        natureChild1 = natureEggGroup.Find("child1");
        natureChild2 = natureEggGroup.Find("child2");
        natureTeen1 = natureEggGroup.Find("teen1");
        natureTeen2 = natureEggGroup.Find("teen2");
        natureTeen3 = natureEggGroup.Find("teen3");
        natureTeen4 = natureEggGroup.Find("teen4");
        natureAdult1 = natureEggGroup.Find("adult1");
        natureAdult2 = natureEggGroup.Find("adult2");
        natureAdult3 = natureEggGroup.Find("adult3");
        natureAdult4 = natureEggGroup.Find("adult4");
        natureAdult5 = natureEggGroup.Find("adult5");
        natureAdult6 = natureEggGroup.Find("adult6");

        darkBaby1 = darkEggGroup.Find("baby");
        darkChild1 = darkEggGroup.Find("child1");
        darkChild2 = darkEggGroup.Find("child2");
        darkTeen1 = darkEggGroup.Find("teen1");
        darkTeen2 = darkEggGroup.Find("teen2");
        darkTeen3 = darkEggGroup.Find("teen3");
        darkTeen4 = darkEggGroup.Find("teen4");
        darkAdult1 = darkEggGroup.Find("adult1");
        darkAdult2 = darkEggGroup.Find("adult2");
        darkAdult3 = darkEggGroup.Find("adult3");
        darkAdult4 = darkEggGroup.Find("adult4");
        darkAdult5 = darkEggGroup.Find("adult5");
        darkAdult6 = darkEggGroup.Find("adult6");

        //assign Button objects to each box, then add them into a dict of Buttons
        //Normal
        normalBaby1Button =  normalEggGroup.Find("baby").GetComponent<Button>().GetComponent<Button>();
        normalChild1Button =  normalEggGroup.Find("child1").GetComponent<Button>();
        normalChild2Button =  normalEggGroup.Find("child2").GetComponent<Button>();
        normalTeen1Button =  normalEggGroup.Find("teen1").GetComponent<Button>();
        normalTeen2Button =  normalEggGroup.Find("teen2").GetComponent<Button>();
        normalTeen3Button =  normalEggGroup.Find("teen3").GetComponent<Button>();
        normalTeen4Button =  normalEggGroup.Find("teen4").GetComponent<Button>();
        normalAdult1Button =  normalEggGroup.Find("adult1").GetComponent<Button>();
        normalAdult2Button =  normalEggGroup.Find("adult2").GetComponent<Button>();
        normalAdult3Button =  normalEggGroup.Find("adult3").GetComponent<Button>();
        normalAdult4Button =  normalEggGroup.Find("adult4").GetComponent<Button>();
        normalAdult5Button =  normalEggGroup.Find("adult5").GetComponent<Button>();
        normalAdult6Button =  normalEggGroup.Find("adult6").GetComponent<Button>();

        //Love
        loveBaby1Button =  loveEggGroup.Find("baby").GetComponent<Button>();
        loveChild1Button =  loveEggGroup.Find("child1").GetComponent<Button>();
        loveChild2Button =  loveEggGroup.Find("child2").GetComponent<Button>();
        loveTeen1Button =  loveEggGroup.Find("teen1").GetComponent<Button>();
        loveTeen2Button =  loveEggGroup.Find("teen2").GetComponent<Button>();
        loveTeen3Button =  loveEggGroup.Find("teen3").GetComponent<Button>();
        loveTeen4Button =  loveEggGroup.Find("teen4").GetComponent<Button>();
        loveAdult1Button =  loveEggGroup.Find("adult1").GetComponent<Button>();
        loveAdult2Button =  loveEggGroup.Find("adult2").GetComponent<Button>();
        loveAdult3Button =  loveEggGroup.Find("adult3").GetComponent<Button>();
        loveAdult4Button =  loveEggGroup.Find("adult4").GetComponent<Button>();
        loveAdult5Button =  loveEggGroup.Find("adult5").GetComponent<Button>();
        loveAdult6Button =  loveEggGroup.Find("adult6").GetComponent<Button>();

        natureBaby1Button =  natureEggGroup.Find("baby").GetComponent<Button>();
        natureChild1Button =  natureEggGroup.Find("child1").GetComponent<Button>();
        natureChild2Button =  natureEggGroup.Find("child2").GetComponent<Button>();
        natureTeen1Button =  natureEggGroup.Find("teen1").GetComponent<Button>();
        natureTeen2Button =  natureEggGroup.Find("teen2").GetComponent<Button>();
        natureTeen3Button =  natureEggGroup.Find("teen3").GetComponent<Button>();
        natureTeen4Button =  natureEggGroup.Find("teen4").GetComponent<Button>();
        natureAdult1Button =  natureEggGroup.Find("adult1").GetComponent<Button>();
        natureAdult2Button =  natureEggGroup.Find("adult2").GetComponent<Button>();
        natureAdult3Button =  natureEggGroup.Find("adult3").GetComponent<Button>();
        natureAdult4Button =  natureEggGroup.Find("adult4").GetComponent<Button>();
        natureAdult5Button =  natureEggGroup.Find("adult5").GetComponent<Button>();
        natureAdult6Button =  natureEggGroup.Find("adult6").GetComponent<Button>();

        darkBaby1Button =  darkEggGroup.Find("baby").GetComponent<Button>();
        darkChild1Button =  darkEggGroup.Find("child1").GetComponent<Button>();
        darkChild2Button =  darkEggGroup.Find("child2").GetComponent<Button>();
        darkTeen1Button =  darkEggGroup.Find("teen1").GetComponent<Button>();
        darkTeen2Button =  darkEggGroup.Find("teen2").GetComponent<Button>();
        darkTeen3Button =  darkEggGroup.Find("teen3").GetComponent<Button>();
        darkTeen4Button =  darkEggGroup.Find("teen4").GetComponent<Button>();
        darkAdult1Button =  darkEggGroup.Find("adult1").GetComponent<Button>();
        darkAdult2Button =  darkEggGroup.Find("adult2").GetComponent<Button>();
        darkAdult3Button =  darkEggGroup.Find("adult3").GetComponent<Button>();
        darkAdult4Button =  darkEggGroup.Find("adult4").GetComponent<Button>();
        darkAdult5Button =  darkEggGroup.Find("adult5").GetComponent<Button>();
        darkAdult6Button =  darkEggGroup.Find("adult6").GetComponent<Button>();


    }

    void Start()
    {
        discovery = Player.instance.discovery;
        discovery.onDiscoveredVolastrosListChanged += Discovery_onDiscoveredVolastrosListChanged;
        RefreshDex();
    }

    public void SetDiscovery(Discovery discovery)
    {
        this.discovery = discovery;
        discovery.onDiscoveredVolastrosListChanged += Discovery_onDiscoveredVolastrosListChanged;
        RefreshDex();
    }

    private void Discovery_onDiscoveredVolastrosListChanged(object sender, System.EventArgs e)
    {
        RefreshDex();
    }

    private void RefreshDex()
    {
        Dictionary<int, Transform> volastroBoxes = new Dictionary<int, Transform>()
    {
            {1, normalBaby1},
            {2, loveBaby1},
            {3, natureBaby1},
            {4, darkBaby1},

            {5, normalChild1},
            {6, normalChild2},
            {7, loveChild1},
            {8, loveChild2},
            {9, natureChild1},
            {10, natureChild2},
            {11, darkChild1},
            {12, darkChild2},


            {13, normalTeen1},
            {14, normalTeen2},
            {15, normalTeen3},
            {16, normalTeen4},
            {17, loveTeen1},
            {18, loveTeen2},
            {19, loveTeen3},
            {20, loveTeen4},
            {21, natureTeen1},
            {22, natureTeen2},
            {23, natureTeen3},
            {24, natureTeen4},
            {25, darkTeen1},
            {26, darkTeen2},
            {27, darkTeen3},
            {28, darkTeen4},

            {29, normalAdult1},
            {30, normalAdult2},
            {31, normalAdult3},
            {32, normalAdult4},
            {33, normalAdult5},
            {34, normalAdult6},
            {35, loveAdult1},
            {36, loveAdult2},
            {37, loveAdult3},
            {38, loveAdult4},
            {39, loveAdult5},
            {40, loveAdult6},
            {41, natureAdult1},
            {42, natureAdult2},
            {43, natureAdult3},
            {44, natureAdult4},
            {45, natureAdult5},
            {46, natureAdult6},
            {47, darkAdult1},
            {48, darkAdult2},
            {49, darkAdult3},
            {50, darkAdult4},
            {51, darkAdult5},
            {52, darkAdult6},
    };
        Dictionary<int, Button> volastroBoxesButtons = new Dictionary<int, Button>()
    {
            {1, normalBaby1Button},
            {2, loveBaby1Button},
            {3, natureBaby1Button},
            {4, darkBaby1Button},

            {5, normalChild1Button},
            {6, normalChild2Button},
            {7, loveChild1Button},
            {8, loveChild2Button},
            {9, natureChild1Button},
            {10, natureChild2Button},
            {11, darkChild1Button},
            {12, darkChild2Button},


            {13, normalTeen1Button},
            {14, normalTeen2Button},
            {15, normalTeen3Button},
            {16, normalTeen4Button},
            {17, loveTeen1Button},
            {18, loveTeen2Button},
            {19, loveTeen3Button},
            {20, loveTeen4Button},
            {21, natureTeen1Button},
            {22, natureTeen2Button},
            {23, natureTeen3Button},
            {24, natureTeen4Button},
            {25, darkTeen1Button},
            {26, darkTeen2Button},
            {27, darkTeen3Button},
            {28, darkTeen4Button},

            {29, normalAdult1Button},
            {30, normalAdult2Button},
            {31, normalAdult3Button},
            {32, normalAdult4Button},
            {33, normalAdult5Button},
            {34, normalAdult6Button},
            {35, loveAdult1Button},
            {36, loveAdult2Button},
            {37, loveAdult3Button},
            {38, loveAdult4Button},
            {39, loveAdult5Button},
            {40, loveAdult6Button},
            {41, natureAdult1Button},
            {42, natureAdult2Button},
            {43, natureAdult3Button},
            {44, natureAdult4Button},
            {45, natureAdult5Button},
            {46, natureAdult6Button},
            {47, darkAdult1Button},
            {48, darkAdult2Button},
            {49, darkAdult3Button},
            {50, darkAdult4Button},
            {51, darkAdult5Button},
            {52, darkAdult6Button},
    };

        //change sprite
        foreach (KeyValuePair<int, Transform> entry in volastroBoxes)
        {
            if (discovery.getDiscoveredVolastros().Contains(entry.Key))
            {
                if (entry.Value != null)
                {
                    
                    //set non shadow sprite icon
                    Image image = entry.Value.Find("icon").GetComponent<Image>();

                    image.sprite = VolastroManager.instance.getVolastroList()[entry.Key].volastroSprite;
                }
                
            }

        }

        //toggle interactivity
        foreach (KeyValuePair<int, Button> entry in volastroBoxesButtons)
        {
            if (discovery.getDiscoveredVolastros().Contains(entry.Key))
            {
                if (entry.Value != null)
                {
                    //assign volastro to its ClickHandler
                    ClickHandlerLibrary cScript = entry.Value.GetComponent<ClickHandlerLibrary>();
                    cScript.volastroScriptableObject = VolastroManager.instance.getVolastroList()[entry.Key];

                    Debug.Log("Clickhandler assigned " + VolastroManager.instance.getVolastroList()[entry.Key].volastroName);
                    entry.Value.interactable = true;
                }

            }

        }

    }
}

