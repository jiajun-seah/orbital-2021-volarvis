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

    Dictionary<int, FoodScriptableObject> foodList = new Dictionary<int, FoodScriptableObject>();

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

        //0-1,0
        foodList.Add(0, wetGoopScriptable);
        foodList.Add(1, avocadoToastScriptable);
        foodList.Add(2, blackberryJellyScriptable);
        foodList.Add(3, blueberryCakeScriptable);
        foodList.Add(4, blueberryPieScriptable);
        foodList.Add(5, blueberrySconeScriptable);
        foodList.Add(6, bouillabaiseScriptable);
        foodList.Add(7, bubbleTeaScriptable);
        foodList.Add(8, buffaloWingsScriptable);
        foodList.Add(9, candyCanesScriptable);
        foodList.Add(10, cevicheScriptable);

        //1,1,-20
        foodList.Add(11, chocolateDonutsScriptable);
        foodList.Add(12, chocolateFroyoScriptable);
        foodList.Add(13, chocolateIceCreamScriptable);
        foodList.Add(14, cinnamonRollsScriptable);
        foodList.Add(15, crawfishBisqueScriptable);
        foodList.Add(16, escargotScriptable);
        foodList.Add(17, fishAndChipsScriptable);
        foodList.Add(18, fishCurryScriptable);
        foodList.Add(19, fruitbarScriptable);
        foodList.Add(20, fruitcakeScriptable);

        //21,-30
        foodList.Add(21, gardenSaladScriptable);
        foodList.Add(22, garlicChickenScriptable);
        foodList.Add(23, greenCurryScriptable);
        foodList.Add(24, greenStuffedPeppersScriptable);
        foodList.Add(25, hamburgerScriptable);
        foodList.Add(26, honeyPancakeScriptable);
        foodList.Add(27, jellyBeansScriptable);
        foodList.Add(28, keyLimePieScriptable);
        foodList.Add(29, lagsanaScriptable);
        foodList.Add(30, lemonCakeScriptable);

        //31,40
        foodList.Add(31, bananaFroyoScriptable);
        foodList.Add(32, liquoriceCandyScriptable);
        foodList.Add(33, lotusRootSoupScriptable);
        foodList.Add(34, lycheeJellyScriptable);
        foodList.Add(35, makiSushiScriptable);
        foodList.Add(36, malaHotpotScriptable);
        foodList.Add(37, popsiclesScriptable);
        foodList.Add(38, raspberryPieScriptable);
        foodList.Add(39, ratatouilleScriptable);
        foodList.Add(40, redStuffedPeppersScriptable);

        //41,-50
        foodList.Add(41, rosemaryChickenScriptable);
        foodList.Add(42, creamySausagesScriptable);
        foodList.Add(43, seafoodPancakeScriptable);
        foodList.Add(44, shavedIceScriptable);
        foodList.Add(45, shrimpPastaScriptable);
        foodList.Add(46, smoothieScriptable);
        foodList.Add(47, sobaScriptable);
        foodList.Add(48, squidInkPastaScriptable);
        foodList.Add(49, strawberryCakeScriptable);
        foodList.Add(50, strawberryCupcakeScriptable);

        //51,-60
        foodList.Add(51, strawberryDonutsScriptable);
        foodList.Add(52, strawberryFroyoScriptable);
        foodList.Add(53, strawberryIceCreamScriptable);
        foodList.Add(54, strawberryJellyScriptable);
        foodList.Add(55, strawberrySconeScriptable);
        foodList.Add(56, tomYumSoupScriptable);
        foodList.Add(57, tortillaChipsScriptable);
        foodList.Add(58, vanillaCupcakeScriptable);
        foodList.Add(59, vanillaDonutsScriptable);
        foodList.Add(60, chocolateCupcakesScriptable);

        //61,-62
        foodList.Add(61, vanillaIceCreamScriptable);
        foodList.Add(62, yellowStuffedPeppersScriptable);
        
    }

    public Dictionary<int, FoodScriptableObject> getFoodList()
    {
        return this.foodList;
    }
}
