using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSettings : MonoBehaviour
{
    public GameObject PauseSet;

    public void PauseSett()
    {
        PauseSet.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        PauseSet.SetActive(false);
        Time.timeScale = 1;
    }
}
