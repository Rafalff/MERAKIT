using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "CombineSystem/Recipe")]
public class Recipe : ScriptableObject {
    public ItemData dataIngredient1;
    public ItemData dataIngredient2;
    public GameObject outcomePrefab;
}
