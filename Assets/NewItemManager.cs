using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class NewItemManager : MonoBehaviour {
    // Singleton instance
    private static NewItemManager instance;
    // HashSet to keep track of instantiated items
    private HashSet<string> instantiatedItems = new HashSet<string>();

    [SerializeField] private GameObject newItemCanvas;
    [SerializeField] private Image newItemIcon;
    [SerializeField] private TextMeshProUGUI newItemName;

    // Method to get the singleton instance
    public static NewItemManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<NewItemManager>();
                if (instance == null) {
                    GameObject obj = new GameObject();
                    obj.name = typeof(NewItemManager).Name;
                    instance = obj.AddComponent<NewItemManager>();
                }
            }
            return instance;
        }
    }

    // Method to award achievement for a new item
    public void AwardAchievementForNewItem(string itemID, Sprite icon) {
        if (!instantiatedItems.Contains(itemID)) {
            instantiatedItems.Add(itemID);
            Debug.Log("Achievement unlocked: New item created!");
            newItemCanvas.SetActive(true);
            newItemName.text = itemID;
            newItemIcon.sprite = icon;
        }
    }
}
