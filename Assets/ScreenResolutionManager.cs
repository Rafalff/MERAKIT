using UnityEngine;

public class ScreenResolutionManager : MonoBehaviour {
    public bool fullScreen = true; // Set whether you want fullscreen or not

    void Start() {
        // Get the current screen resolution
        int screenWidth = Screen.currentResolution.width;
        int screenHeight = Screen.currentResolution.height;

        // Set the screen resolution
        Screen.SetResolution(screenWidth, screenHeight, fullScreen);
    }
}
