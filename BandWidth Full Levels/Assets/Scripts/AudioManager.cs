using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

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
        Play("BackGround");
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
