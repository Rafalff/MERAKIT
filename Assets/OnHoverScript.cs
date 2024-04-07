using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private RecipeHolder recipeHolder;
    private Sprite recipe1;
    private Sprite recipe2;
    private string itemName;
    private string recipe1Name;
    private string recipe2Name;

    private void Start() {
        recipeHolder = GetComponent<RecipeHolder>();
        recipe1 = recipeHolder.recipe.dataIngredient1.icon;
        recipe2 = recipeHolder.recipe.dataIngredient2.icon;
        itemName = recipeHolder.recipe.name;
        recipe1Name = recipeHolder.recipe.dataIngredient1.ingredientName;
        recipe2Name = recipeHolder.recipe.dataIngredient2.ingredientName;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        TooltipsManager.instance.ShowRecipe(recipe1, recipe2, itemName, recipe1Name, recipe2Name);
    }

    public void OnPointerExit(PointerEventData eventData) {
        TooltipsManager.instance.HideRecipe();
    }
}
