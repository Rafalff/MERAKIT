using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;

    public bool isMission1Finish;
    public bool isMission2Finish;

    public GameObject panel1Finish;
    public GameObject newItemButton;
    public Toggle mission1Toggle;

    public GameObject panel2Finish;
    public Toggle mission2Toggle;
    private void Awake() {
        instance = this;
    }

    public void CheckMission1Finish() {
        isMission1Finish = true;
        panel1Finish.SetActive(true);
        mission1Toggle.isOn = true;
        newItemButton.SetActive(true);

        UIManager.Instance.OnClickSettings();
    }

    public void CheckMission2Finish() {
        isMission2Finish = true;
        panel2Finish.SetActive(true);
        mission2Toggle.isOn = true;

        UIManager.Instance.OnClickSettings();

    }
}
