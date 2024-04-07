using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipsManager : MonoBehaviour
{
    public static TooltipsManager instance;
    public TextMeshProUGUI tooltipsText;

    public GameObject recipePanel;
    public Image img1;
    public Image img2;

    public TextMeshProUGUI itemName;

    public TextMeshProUGUI recipeText1;
    public TextMeshProUGUI recipeText2;

    public TextMeshProUGUI description;

    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
        recipePanel.SetActive(false);
    }

    public void ShowTooltips(string tooltips) {
        gameObject.SetActive(true);
        tooltipsText.text = tooltips;
    }

    public void HideTooltips() {
        gameObject.SetActive(false);
        tooltipsText.text = string.Empty;
    }

    public void ShowRecipe(Sprite icon1, Sprite icon2,string itemname, string recipetext1, string recipetext2, string desc) {
        recipePanel.SetActive(true);
        img1.sprite = icon1;
        img2.sprite = icon2;

        itemName.SetText(itemname);

        recipeText1.SetText(recipetext1);
        recipeText2.SetText(recipetext2);

        description.SetText(desc);

    }

    public void HideRecipe() {
        recipePanel.SetActive(false);
        img1.sprite = null;
        img2.sprite = null;

        itemName.text = string.Empty;
        recipeText1.text = string.Empty;
        recipeText2.text = string.Empty;

        description.text = string.Empty;
    }
}
