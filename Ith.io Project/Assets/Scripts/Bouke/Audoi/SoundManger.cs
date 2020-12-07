using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManger : MonoBehaviour
{
    public Sounds[] sounds;

    public static SoundManger instance;

    private void Awake()
    {
        //make this a instace if there is already a instance destroy the dublecate gameojbect
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        //get all the right variable out the sounds script with a foreach
        foreach (Sounds s in sounds )
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        //Play("Main Theme");
    }

    public void Play(string name)
    {
        //play sound that was called from a other script
        Sounds s =  Array.Find(sounds, sound => sound.Name == name);
        //if there was no sound found with the name given give error message
        if(s == null)
        {
            Debug.LogError("There is no sound with the name " + name);
            return;
        }
        s.source.Play();

    }

}
