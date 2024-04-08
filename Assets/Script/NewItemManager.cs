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
    [SerializeField] private int totalItem = 4;
    [SerializeField] private float totalItemSlider = 0f;

    [SerializeField] private TextMeshProUGUI itemFoundText;
    [SerializeField] private int maxItem;

    [SerializeField] private GameObject[] instantiatedItemRecipe;

    [SerializeField] private Slider sliderFinish;

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

    private void Start() {
        itemFoundText.SetText("Barang ditemukan " + totalItem.ToString() + "/" + maxItem.ToString());
        UpdateSliderValue();
    }

    // Method to award achievement for a new item
    public void AwardAchievementForNewItem(string itemID, Sprite icon) {
        if (!instantiatedItems.Contains(itemID)) {
            instantiatedItems.Add(itemID);
            SetItemFoundText();
            Debug.Log("Achievement unlocked: New item created!");
            newItemCanvas.SetActive(true);
            newItemName.text = itemID;
            newItemIcon.sprite = icon;
            newItemIcon.SetNativeSize();
            UpdateSliderValue();

            if(itemID == "Sensor Banjir") {
                MissionManager.instance.CheckMission1Finish();
            }
            if (totalItem >= maxItem) {
                MissionManager.instance.CheckMission2Finish();
            }
            AudioManager.instance.PlaySfx("newitem");
            Time.timeScale = 0f;


        } else {
            AudioManager.instance.PlaySfx("combine");
        }
    }

    void SetItemFoundText() {
        totalItemSlider++;
        totalItem++;
        itemFoundText.SetText("Barang ditemukan " + totalItem.ToString() + "/" + maxItem.ToString());
    }

    public void ResumeTime() {
        Time.timeScale = 1f;
    }

    public void CheckRecipe() {
        foreach (GameObject recipeItem in instantiatedItemRecipe) {
            if (instantiatedItems.Contains(recipeItem.name)) {
                recipeItem.SetActive(true);
            }
        }
    }

    public void UpdateSliderValue() {
        
        if (sliderFinish != null) {
            sliderFinish.value = totalItemSlider / maxItem;
        }
    }

}
