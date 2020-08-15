using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;
    private Slider backgroundMusic;
    private Slider SFXSlider;
    private bool soundSet = true;

    public MenuPause pauseMenu;

    void Awake()
    {
        //destroys gameObject if another AudioManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); //so music keeps playing when scene restarts

        foreach (Sound s in sounds) //for each Sound (designated as 's') from the Sound class (created in another script called Sound) in the array sounds
        {
            //creates an AudioSource on the gameobject and assigns it the variable s.source
            s.source = gameObject.AddComponent<AudioSource>(); 
            
            // element in the AudioSource equals assigned variable from the sound script.
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //backgroundMusic = GameObject.Find("MusicSlider").GetComponent<Slider>();
        //SFXSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
        Play("MainMenu");
    }

    void Update()
    {
        if (GameObject.Find("OptionsPanel") == true)
        {
            backgroundMusic = GameObject.Find("MusicSlider").GetComponent<Slider>();
            SFXSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
            if (soundSet == true)
            {
                backgroundMusic.value = 30;
                SFXSlider.value = 30;
                soundSet = false;
            }

            foreach (Sound s in sounds)
            {
                if (s.background == true)
                {
                    s.source.volume = backgroundMusic.value / 100;
                }
                else
                {
                    s.source.volume = SFXSlider.value / 100;
                }

            }
        }
        
        

    }

    //public method to be called to play sounds using their names
    public void Play (string name)
    {
        // finds a sound with a specific name from the sounds array
        Sound s = Array.Find(sounds, Sound => Sound.name == name); //=> means where
        if (s == null) //if a sound with that name cant be found
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;    //reaturn means stop function (if there is no sound with that name it doesnt give an error)
        }
            
        s.source.Play(); //plays the AudioSource
    }

    //public method to be called to pause sounds using their names
    public void Pause (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;    
        }
        s.source.Pause(); //pauses the AudioSource
    }
}
