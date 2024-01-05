using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadLevel1()
    {
        print("biskan ano");
        SceneManager.LoadScene("Level1"); // Load the "Level1" scene
    }
}