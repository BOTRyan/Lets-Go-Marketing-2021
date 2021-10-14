using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class ExtraButtons : MonoBehaviour
{

    private Button button;

    
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(MainMenuClick);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SwitchScenes.instance.ToMainMenu);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (gameObject.CompareTag("playButton"))
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(gameClick);
            }
            if (gameObject.CompareTag("addButton"))
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(addPlayer);
            }
            if (gameObject.CompareTag("removeButton"))
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(removePlayer);
            }
            if(gameObject.CompareTag("bulldogButton"))
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(openMenu);
            }
            if (gameObject.CompareTag("viewTutButton"))
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(openTut);
            }

        }

    }

    void removePlayer()
    {
        GameManager.instance.removePlayer(button);
    }
    void addPlayer()
    {
        GameManager.instance.addNewPlayer();
    }

    void openTut()
    {
        AudioManager.instance.savePlayerData();
        Destroy(FindObjectOfType<CameraControl>().gameObject);
        Destroy(GameManager.instance.gameObject);
        SwitchScenes.instance.ToHowTo();
    }

    void openMenu()
    {
        GameManager.instance.openBulldogSelection(button);
    }

    void MainMenuClick()
    {
        SwitchScenes.instance.ToMainMenu();
        Destroy(GameManager.instance.gameObject);
    }

    void gameClick()
    {
        AudioManager.instance.clearPlayerData();
        SwitchScenes.instance.goToGame();
    }


}
