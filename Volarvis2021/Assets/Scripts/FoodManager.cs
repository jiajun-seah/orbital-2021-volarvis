using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static FoodManager instance;
    public static FoodManager Instance { get { return instance; } }

    //food (scriptable)

    //0-10
    public FoodScriptableObject wetGoopScriptable;
    public FoodScriptableObject avocadoToastScriptable;
    public FoodScriptableObject blackberryJellyScriptable;
    public FoodScriptableObject blueberryCakeScriptable;
    public FoodScriptableObject blueberryPieScriptable;
    public FoodScriptableObject blueberrySconeScriptable;
    public FoodScriptableObject bouillabaiseScriptable;
    public FoodScriptableObject bubbleTeaScriptable;
    public FoodScriptableObject buffaloWingsScriptable;
    public FoodScriptableObject candyCanesScriptable;
    public FoodScriptableObject cevicheScriptable;

    //11-20
    public FoodScriptableObject chocolateDonutsScriptable;
    public FoodScriptableObject chocolateFroyoScriptable;
    public FoodScriptableObject chocolateIceCreamScriptable;
    public FoodScriptableObject cinnamonRollsScriptable;
    public FoodScriptableObject crawfishBisqueScriptable;
    public FoodScriptableObject escargotScriptable;
    public FoodScriptableObject fishAndChipsScriptable;
    public FoodScriptableObject fishCurryScriptable;
    public FoodScriptableObject fruitbarScriptable;
    public FoodScriptableObject fruitcakeScriptable;

    //21-30
    public FoodScriptableObject gardenSaladScriptable;
    public FoodScriptableObject garlicChickenScriptable;
    public FoodScriptableObject greenCurryScriptable;
    public FoodScriptableObject greenStuffedPeppersScriptable;
    public FoodScriptableObject hamburgerScriptable;
    public FoodScriptableObject honeyPancakeScriptable;
    public FoodScriptableObject jellyBeansScriptable;
    public FoodScriptableObject keyLimePieScriptable;
    public FoodScriptableObject lagsanaScriptable;
    public FoodScriptableObject lemonCakeScriptable;

    //31-40
    public FoodScriptableObject bananaFroyoScriptable;
    public FoodScriptableObject liquoriceCandyScriptable;
    public FoodScriptableObject lotusRootSoupScriptable;
    public FoodScriptableObject lycheeJellyScriptable;
    public FoodScriptableObject makiSushiScriptable;
    public FoodScriptableObject malaHotpotScriptable;
    public FoodScriptableObject popsiclesScriptable;
    public FoodScriptableObject raspberryPieScriptable;
    public FoodScriptableObject ratatouilleScriptable;
    public FoodScriptableObject redStuffedPeppersScriptable;

    //41-50
    public FoodScriptableObject rosemaryChickenScriptable;
    public FoodScriptableObject creamySausagesScriptable;
    public FoodScriptableObject seafoodPancakeScriptable;
    public FoodScriptableObject shavedIceScriptable;
    public FoodScriptableObject shrimpPastaScriptable;
    public FoodScriptableObject smoothieScriptable;
    public FoodScriptableObject sobaScriptable;
    public FoodScriptableObject squidInkPastaScriptable;
    public FoodScriptableObject strawberryCakeScriptable;
    public FoodScriptableObject strawberryCupcakeScriptable;

    //51-60
    public FoodScriptableObject strawberryDonutsScriptable;
    public FoodScriptableObject strawberryFroyoScriptable;
    public FoodScriptableObject strawberryIceCreamScriptable;
    public FoodScriptableObject strawberryJellyScriptable;
    public FoodScriptableObject strawberrySconeScriptable;
    public FoodScriptableObject tomYumSoupScriptable;
    public FoodScriptableObject tortillaChipsScriptable;
    public FoodScriptableObject vanillaCupcakeScriptable;
    public FoodScriptableObject vanillaDonutsScriptable;
    public FoodScriptableObject chocolateCupcakesScriptable;

    //61-62
    public FoodScriptableObject vanillaIceCreamScriptable;
    public FoodScriptableObject yellowStuffedPeppersScriptable;

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
