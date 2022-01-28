using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMenuScenes : MonoBehaviour
{

    public Sprite businessScene, designScene, mediaManagementScene, marketingScene, PRScene;
    private List<Sprite> imgArray = new List<Sprite>();

    public GameObject disclaimer;
    public GameObject blur;

    private float randTimer = 7f;
    private bool hasSwapped = false;
    // Start is called before the first frame update
    void Start()
    {

        imgArray.Add(businessScene);
        imgArray.Add(designScene);
        imgArray.Add(mediaManagementScene);
        imgArray.Add(marketingScene);
        imgArray.Add(PRScene);

        randomize();

        disclaimer.SetActive(true);
        blur.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        randTimer -= Time.deltaTime;
        if (randTimer <= 0)
        {
            hasSwapped = false;
            StartCoroutine("ImgFade");
            randTimer = 8f;
        }
    }

    void randomize()
    {
        int randImg = Mathf.FloorToInt(Random.Range(0, 5));
        while (randImg == imgArray.IndexOf(GetComponent<Image>().sprite))
        {
            randImg = Mathf.FloorToInt(Random.Range(0, 6));
        }
        GetComponent<Image>().sprite = imgArray[randImg];
    }

    IEnumerator ImgFade()
    {
        for (float a = 1; a > -1f; a -= .02f)
        {
            Color fade = GetComponent<Image>().color;
            fade.a = (a >= 0) ? a : -a;
            GetComponent<Image>().color = fade;
            if (a <= 0)
            {
                if (!hasSwapped)
                {
                    randomize();
                    hasSwapped = true;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public void hideDisclaimer()
    {
        StartCoroutine("blurFade");
    }

    IEnumerator blurFade()
    {
        for (float a = 1; a > -1f; a -= .05f)
        {
            Color fade = blur.GetComponent<Image>().color;
            Color fade2 = disclaimer.GetComponent<Image>().color;
            fade.a = a;
            fade2.a = a;
            Image[] children = disclaimer.GetComponentsInChildren<Image>();
            foreach (Image i in children)
            {
                i.color = fade;
            }
            blur.GetComponent<Image>().material.SetFloat("_Size", a);
            disclaimer.GetComponent<Image>().color = fade2;
            if (a < 0f)
            {
                blur.SetActive(false);
                disclaimer.SetActive(false);
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
