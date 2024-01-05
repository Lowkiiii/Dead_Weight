using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource levelcompleteSound;
    void Start()
    {
        levelcompleteSound.Play();
    }
}
