using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    [SerializeField] private AudioSource mainmenuSound;
    void Start()
    {
        mainmenuSound.Play();
    }
}
