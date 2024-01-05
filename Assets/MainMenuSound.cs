using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    [SerializeField] private AudioSource mainmenuSound;
    // Start is called before the first frame update
    void Start()
    {
        mainmenuSound.Play();
    }
}
