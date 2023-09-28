using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;


public class FinalButtons : MonoBehaviour, IPointerDownHandler
{
    private bool creditsIsOut = false;
    public GameObject creditCard;
    public GameObject creditBlur;

    /// MY STUFF begin
    [Serializable]
    public class ButtonPressEvent : UnityEvent { }

    public ButtonPressEvent OnPress = new ButtonPressEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPress.Invoke();
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);
    public void OpenLinkJSPlugin()
    {
        openWindow("https://ferrisdsgn.typeform.com/to/hIYzD9Jv");
    }
    /// MY STUFF end

    public void feedbackSurvey()
    {
        OpenLinkJSPlugin(); // CHANGED THIS
    }

    public void lgmMain()
    {
        Application.OpenURL("https://ferris.letsgo.careers");
    }

    public void playAgain()
    {
        if (GameManager.instance)
            Destroy(GameManager.instance.gameObject);
        if (AudioManager.instance)
            Destroy(AudioManager.instance.gameObject);
        SceneManager.LoadScene("startScene");
    }

    public void ferrisMain()
    {
        Application.OpenURL("https://business.ferris.edu/program/marketing/");
    }

    public void visitFerris()
    {
        Application.OpenURL("https://www.ferris.edu/admissions/schedule_visit.htm");
    }

    public void credits()
    {
        if (!creditsIsOut)
        {
            creditCard.SetActive(true);
            creditBlur.SetActive(true);
            StartCoroutine("blurFadeIn");
            creditsIsOut = true;
        }
    }

    public void closeCredits()
    {
        StartCoroutine("blurFadeOut");
    }

    IEnumerator blurFadeIn()
    {
        for (float a = 0; a < 1f; a += .05f)
        {
            Color sureFade = creditCard.GetComponent<Image>().color;
            Image[] children = creditCard.GetComponentsInChildren<Image>();
            sureFade.a = a;
            foreach (Image i in children)
            {
                i.color = sureFade;
            }
            creditCard.GetComponent<Image>().color = sureFade;
            creditBlur.GetComponent<Image>().material.SetFloat("_Size", a);

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator blurFadeOut()
    {
        for (float a = 1; a > -1f; a -= .05f)
        {
            Color sureFade = creditCard.GetComponent<Image>().color;
            Image[] children = creditCard.GetComponentsInChildren<Image>();
            sureFade.a = a;
            foreach (Image i in children)
            {
                i.color = sureFade;
            }
            creditCard.GetComponent<Image>().color = sureFade;
            creditBlur.GetComponent<Image>().material.SetFloat("_Size", a);

            if (a <= 0)
            {
                creditCard.SetActive(false);
                creditBlur.SetActive(false);
                creditsIsOut = false;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
