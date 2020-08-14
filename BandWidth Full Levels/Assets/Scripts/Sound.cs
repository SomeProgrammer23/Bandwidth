using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]//so it shows in the inspector
public class Sound 
{
    //controllable variables to be transfered to an AudioSource
    public string name;
    
    public AudioClip clip;

    [Range(0f, 1f)]//adds sliding bar
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public bool background;

    [HideInInspector]
    public AudioSource source;

}
