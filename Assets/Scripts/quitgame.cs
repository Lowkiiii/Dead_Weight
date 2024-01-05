using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing the game in the Unity Editor
        #else
            Application.Quit(); // Quit the application when built
        #endif
    }
}
