using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSettings : MonoBehaviour
{
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings"); // Load the "Level1" scene
    }
}
