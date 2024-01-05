using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ContinueGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
