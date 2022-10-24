using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// keeps track of all sounds
// on awake() initialize each sound's audiosource with its corresponding attributes
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        // make AudioManager persist between scenes
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // use FindObjectOfType<AudioManager>().Play("audioToPlay") in other scripts to call this method
    // or make an AudioManager public variable, referencing it through the inspector
    public void Play(string name)
    {
        // find sound in sounds array such that sound.name == name
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
            s.source.Play();
            //Debug.Log("Play called");
    }
}