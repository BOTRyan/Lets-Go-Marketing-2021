using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalFunction : MonoBehaviour
{
    #region Singleton

    public static ModalFunction instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Button modalButton;
    public GameObject DYKModal;
    public GameObject YTBModal;
    public GameObject CareerModal;
    public GameObject SpinModal;
    private bool fadeOutModal = false;
    private bool fadeInModal = true;
    private float alpha = 0;

    private void Update()
    {
        if (fadeOutModal)
        {
            if (alpha > 0) alpha -= Time.deltaTime * 2;
            else
            {
                fadeOutModal = false;
                DYKModal.SetActive(false);
                YTBModal.SetActive(false);
                CareerModal.SetActive(false);
                SpinModal.SetActive(false);
                gameObject.SetActive(false);
            }
            if (GetComponentInChildren<Image>()) GetComponentInChildren<Image>().color = new Color(1, 1, 1, alpha);
        }

        if (fadeInModal)
        {
            if (alpha < 1) alpha += Time.deltaTime * 2;
            else
            {
                fadeInModal = false;
            }

            if (GetComponentInChildren<Image>()) GetComponentInChildren<Image>().color = new Color(1, 1, 1, alpha);
        }
    }

    public void fadeModalIn(string type)
    {
        fadeOutModal = false;
        switch (type)
        {
            case "DYK":
                DYKModal.SetActive(true);
                break;
            case "YTB":
                YTBModal.SetActive(true);
                break;
            case "Career":
                CareerModal.SetActive(true);
                break;
            case "Spin":
                SpinModal.SetActive(true);
                break;
            default:
                break;
        }
        fadeInModal = true;
        alpha = 0;
    }

    public void hideModal()
    {
        if (!fadeInModal && !fadeOutModal)
        {
            fadeInModal = false;
            fadeOutModal = true;
            alpha = 1;
        }
    }
}
