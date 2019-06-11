using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] Slider SFXSlider;
    
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = PlayerPrefsController.GetSFXVolume();

        }
    }

    



    public AudioSource GetSound(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        return s.source;
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }




}
