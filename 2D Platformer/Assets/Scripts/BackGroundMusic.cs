using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            AudioListener.volume = 1;
            
        }
        else
        {
            AudioListener.volume = 0;
        }
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    
}

