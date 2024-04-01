using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipsManager : MonoBehaviour
{
    public static TooltipsManager instance;
    public TextMeshProUGUI tooltipsText;
    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowTooltips(string tooltips) {
        gameObject.SetActive(true);
        tooltipsText.text = tooltips;
    }

    public void HideTooltips() {
        gameObject.SetActive(false);
        tooltipsText.text = string.Empty;
    }
}
