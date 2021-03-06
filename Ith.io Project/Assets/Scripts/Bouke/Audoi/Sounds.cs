﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds 
{
    public string Name;
    

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float volume = 1;
    [Range(.1f, 3f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    
}
