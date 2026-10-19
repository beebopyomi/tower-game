using UnityEngine;

public class SCREEN : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
    }
    void Start()
    {
        // Print the active rendering resolution to the console
        Debug.Log($"[Resolution Test] Game is rendering at: {Screen.width} x {Screen.height}");
        
        // Print the actual physical hardware resolution of the phone
        Resolution nativeRes = Screen.currentResolution;
        Debug.Log($"[Resolution Test] Phone's physical screen is: {nativeRes.width} x {nativeRes.height}");
    }
}
