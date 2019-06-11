using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    public GameObject musicOnIcon;
    public GameObject musicOffIcon;


    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = PlayerPrefsController.GetMasterVolume();
        SFXSlider.value = PlayerPrefsController.GetSFXVolume();
        SetSoundState();

    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<BackGroundMusic>();
       
        
        if (musicPlayer)
        {
            musicPlayer.SetVolume(musicSlider.value);
            
            
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(musicSlider.value);
        PlayerPrefsController.SetSFXVolume(SFXSlider.value);
        
        FindObjectOfType<SceneLoader>().LoadStartScene();
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted",0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
        SetSoundState();
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted",0) == 0)
        {
            AudioListener.volume = 1;
            musicOnIcon.SetActive(true);
            musicOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            musicOnIcon.SetActive(false);
            musicOffIcon.SetActive(true);
        }

        
    }
}
