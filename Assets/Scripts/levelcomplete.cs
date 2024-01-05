using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcomplete : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("gamemenu"); // Load the "Level1" scene
    }
}