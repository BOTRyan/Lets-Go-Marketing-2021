using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    public Button musicButt;
    public Button SFXButt;
    public Button QuitButt;
    public GameObject areYouSure;
    public GameObject quitBlur;
    public bool buttonsHidden = true;
    public bool quitIsOut = false;
    public SendToGoogle googleScript;

    void Start()
    {
        buttonsHidden = true;
        quitIsOut = false;
        SFXButt.gameObject.SetActive(false);
        musicButt.gameObject.SetActive(false);
        if (QuitButt) QuitButt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (AudioManager.instance.musicMuted)
        {
            musicButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound-effects-off");
        }
        else
        {
            musicButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound-effects");
        }

        if (AudioManager.instance.sfxMuted)
        {
            SFXButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound-off");
        }
        else
        {
            SFXButt.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/sound");
        }

        if (buttonsHidden)
        {
            SFXButt.gameObject.SetActive(false);
            musicButt.gameObject.SetActive(false);
            if (QuitButt) QuitButt.gameObject.SetActive(false);
        }
        else
        {
            SFXButt.gameObject.SetActive(true);
            musicButt.gameObject.SetActive(true);
            if (QuitButt) QuitButt.gameObject.SetActive(true);
        }
    }

    public void switchMusic()
    {
        if (AudioManager.instance.musicMuted) AudioManager.instance.musicMuted = false;
        else AudioManager.instance.musicMuted = true;
    }

    public void switchSFX()
    {
        if (AudioManager.instance.sfxMuted) AudioManager.instance.sfxMuted = false;
        else AudioManager.instance.sfxMuted = true;
    }

    public void areYouSureCheck()
    {
        if (!quitIsOut)
        {
            areYouSure.SetActive(true);
            quitBlur.SetActive(true);
            StartCoroutine("blurFadeIn");
            quitIsOut = true;
        }
        buttonsHidden = true;
    }

    public void keepPlaying()
    {
        StartCoroutine("blurFadeOut");
    }

    public void quitGame()
    {
        googleScript.SendData();
        Destroy(GameManager.instance.gameObject);
        Destroy(FindObjectOfType<CameraControl>().gameObject);
        SceneManager.LoadScene("startScene");
    }

    IEnumerator blurFadeIn()
    {
        for (float a = 0; a < 1f; a += .05f)
        {
            Color sureFade = areYouSure.GetComponent<Image>().color;
            Image[] children = areYouSure.GetComponentsInChildren<Image>();
            sureFade.a = a;
            foreach (Image i in children)
            {
                i.color = sureFade;
            }
            areYouSure.GetComponent<Image>().color = sureFade;
            quitBlur.GetComponent<Image>().material.SetFloat("_Size", a);

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator blurFadeOut()
    {
        for (float a = 1; a > -1f; a -= .05f)
        {
            Color sureFade = areYouSure.GetComponent<Image>().color;
            Image[] children = areYouSure.GetComponentsInChildren<Image>();
            sureFade.a = a;
            foreach (Image i in children)
            {
                i.color = sureFade;
            }
            areYouSure.GetComponent<Image>().color = sureFade;
            quitBlur.GetComponent<Image>().material.SetFloat("_Size", a);

            if (a <= 0)
            {
                areYouSure.SetActive(false);
                quitBlur.SetActive(false);
                quitIsOut = false;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void buttonVisibility()
    {
        if (buttonsHidden) buttonsHidden = false;
        else buttonsHidden = true;
    }
}
