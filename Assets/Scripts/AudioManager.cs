using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys

// ATTACHED TO AudioManager PREFAB. The prefab should be placed in the start screen and NOWHERE ELSE since there's a DontDestroyOnLoad()

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public AudioMixer mixer;

    public bool musicMuted;
    public bool sfxMuted;

    // These Variables will only be used in the StartScene and HowToScene to save user data when going back and forth
    private Sprite[] playerSprites = new Sprite[6];
    private String[] playerNames = { "Add Name", "Add Name", "Add Name", "Add Name", "Add Name", "Add Name" };
    private int numOfPlayers;

    // This is ran anytime you go from StartScene to HowToScene to save player data
    public void savePlayerData()
    {
        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            playerSprites[i] = GameManager.instance.players[i].GetComponent<PlayerInfo>().avatar;
            playerNames[i] = GameManager.instance.players[i].GetComponent<PlayerInfo>().playerName;
        }
        numOfPlayers = GameManager.instance.currPlayers;


    }

    // This is ran anytime you want to load player data when switching back from HowToScene to StartScene
    public void loadPlayerData()
    {
        // Sets the amount of players in StartScene
        for (int i = 0; i < numOfPlayers - 1; i++) GameManager.instance.addNewPlayer();

        // Loads player
        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            // Load the saved Image to the dog and bulldog button
            GameManager.instance.players[i].GetComponent<PlayerInfo>().avatar = playerSprites[i];
            GameManager.instance.avatarObjects[i].GetComponent<Image>().sprite = playerSprites[i];
            // If the sprite isn't null hide the button
            if (GameManager.instance.avatarObjects[i].GetComponent<Image>().sprite != null)
            {
                GameManager.instance.avatarObjects[i].GetComponent<Image>().enabled = true;
                GameManager.instance.bulldogButtons[i].GetComponent<Image>().enabled = false;
            }

            // Load the saved name to the text input and player name
            GameManager.instance.playerInputs[i].GetComponent<InputField>().text = playerNames[i];
            GameManager.instance.players[i].GetComponent<PlayerInfo>().playerName = playerNames[i];
        }
    }

    // This is ran anytime you want to clear all player data saved
    public void clearPlayerData()
    {
        playerSprites = new Sprite[6];
        playerNames = new String[6];
    }

    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    private void Update()
    {
        if (musicMuted)
        {
            mixer.SetFloat("Theme-Exposed", -100);
        }
        else
        {
            mixer.SetFloat("Theme-Exposed", 10);
        }

        if (sfxMuted)
        {
            mixer.SetFloat("SFX-Exposed", -100);
        }
        else
        {
            mixer.SetFloat("SFX-Exposed", 10);
        }

        //play click sound
        if (Input.GetMouseButtonDown(0)) FindObjectOfType<AudioManager>().PlayUninterrupted("Click");
    }

    public void Play(string name)
    {
        //to play sound, type "FindObjectOfType<AudioManager>().Play("SoundName");" in the file/section of code that would play sound

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        //to play sound, type "FindObjectOfType<AudioManager>().Play("SoundName");" in the file/section of code that would play sound

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    IEnumerator playSoundWithDelay(string clip, float delay, Sound s)
    {
        yield return new WaitForSeconds(delay);

        //to play sound, type "FindObjectOfType<AudioManager>().PlayInSeconds("SoundName", float);" in the file/section of code that would play sound
        s.source.Play();
    }

    public void PlayInSeconds(string name, float seconds)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        else
        {
            StartCoroutine(playSoundWithDelay(name, seconds, s));
        }
    }

    public void PlayUninterrupted(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }
        else s.source.PlayOneShot(s.source.clip, s.source.volume);
    }
}
