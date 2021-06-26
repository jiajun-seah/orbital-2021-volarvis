using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set;}
    
    private void Awake()
    {
        Instance = this;
    }

    public Sprite bananaSprite;
    public Sprite basilSprite;
    public Sprite beansSprite;
    public Sprite blueberrySprite;
    public Sprite breadSprite;
    public Sprite butterSprite;
    public Sprite cabbageSprite;
    public Sprite carrotSprite;
    public Sprite cheeseSprite;
    public Sprite chilliSprite;
    public Sprite chocolateSprite;
    public Sprite creamSprite;
    public Sprite fishSprite;
    public Sprite flourSprite;
    public Sprite iceSprite;
    public Sprite mushroomSprite;
    public Sprite musselsSprite;
    public Sprite onionSprite;
    public Sprite potatoSprite;
    public Sprite prawnSprite;
    public Sprite riceSprite;
    public Sprite sausagesSprite;
    public Sprite springOnionSprite;
    public Sprite strawberrySprite;
    public Sprite sugarSprite;
    public Sprite vanillaBeanSprite;
    public Sprite waterSprite;

}
