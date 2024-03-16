using UnityEngine;

public class CombineSystem : MonoBehaviour {
    public Recipe[] recipes;

    public GameObject Combine(ItemData ingredient1, ItemData ingredient2) {
        foreach (Recipe recipe in recipes) {
            if ((recipe.dataIngredient1 == ingredient1 && recipe.dataIngredient2 == ingredient2) ||
                (recipe.dataIngredient1 == ingredient2 && recipe.dataIngredient2 == ingredient1)) {
                return recipe.outcomePrefab;
            }
        }
        // No matching recipe found
        return null;
    }
}
