using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backbut : MonoBehaviour
{

    public void BackToGameMenu()
    {
        SceneManager.LoadScene("gamemenu"); // Load the "Level1" scene
    }

}
