using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject componentPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject targetPanel;

    public void OnClickComponent() {
        settingsPanel.SetActive(false);
        componentPanel.SetActive(true);
        targetPanel.SetActive(false);
    }
    public void OnClickSettings() {
        settingsPanel.SetActive(true);
        componentPanel.SetActive(false);
        targetPanel.SetActive(false);
    }

    public void OnClickTarget() {
        settingsPanel.SetActive(false);
        componentPanel.SetActive(false);
        targetPanel.SetActive(true);
    }



}
