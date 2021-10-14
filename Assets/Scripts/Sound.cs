using UnityEngine.Audio;
using UnityEngine;
//https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys

// DOES NOT NEED TO BE ATTACHED TO ANYTHING

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public AudioMixerGroup audioMixerGroup;

    [HideInInspector]
    public AudioSource source;
}
