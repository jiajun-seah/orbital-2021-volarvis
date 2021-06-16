using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOnAdventure : MonoBehaviour
{
    public void visitMeadows()
    {
        Player.instance.inventory.addIngredient(new Ingredient { ingredientType = Ingredient.IngredientType.Banana, amount = 1 });
        Debug.Log("Visit Meadows");
    }
}
