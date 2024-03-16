using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "CombineSystem/Ingredient")]
public class ItemData : ScriptableObject {
    public string ingredientName;
    public Sprite icon;
}