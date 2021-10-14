using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CardAnimation : MonoBehaviour
{

    #region Singleton

    public static CardAnimation instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Animator CardAnimator;
    public Animator SettingsAnimator;

    public Sprite didYouKnowCardBackBlue;
    public Sprite didYouKnowCardBackGreen;
    public Sprite didYouKnowCardBackYellow;
    public Sprite didYouKnowCardBackRed;
    public Sprite didYouKnowCardBackPink;
    public Sprite didYouKnowCardBackPurple;

    public Sprite brandCrisisCardBack;

    public Sprite careerPointCardBack;

    public Sprite youreTheBoss;

    public GameObject cardBack;
    public GameObject cardFront;
    public TMPro.TMP_InputField emailInput;
    public GameObject submitButton;
    public GameObject editButton;
    public GameObject careerButtons;
    public GameObject didYouButtons;
    public GameObject youreTheButtons;
    public GameObject continueButton;
    public GameObject claimVicButton;
    public GameObject chillButton;
    public GameObject keepGoingButton;

    public Sprite[] brandCrisisCardFront;
    public Sprite[] brandCrisisCardFrontIdentity;

    public Sprite[] careerPointCardFront;
    public Sprite[] careerPointCardFrontIdentity;

    public Sprite[] youreTheBossFront;
    public Sprite[] youreTheBossFrontIdentity;

    public Sprite[] didYouKnowCardFrontBlue;
    public Sprite[] didYouKnowCardFrontGreen;
    public Sprite[] didYouKnowCardFrontYellow;
    public Sprite[] didYouKnowCardFrontRed;
    public Sprite[] didYouKnowCardFrontPink;
    public Sprite[] didYouKnowCardFrontPurple;

    public Sprite didYouKnowButtonBlue;
    public Sprite didYouKnowButtonGreen;
    public Sprite didYouKnowButtonYellow;
    public Sprite didYouKnowButtonRed;
    public Sprite didYouKnowButtonPink;
    public Sprite didYouKnowButtonPurple;

    public Sprite firstPlayerDone;
    public Sprite otherPlayersDone;
    public Sprite allPlayersDone;
    public Sprite doneBack;
    public Sprite doneBackTall;

    public GameObject blur;
    public GameObject grayBlur;
    public GameObject rainbowBlur;
    public GameObject tShirt;

    public GameObject[] didYouKnowButtons;
    public int playerMovementEffect = 0;
    public bool cardRead = false;
    public bool playerDoesntMove;
    public bool finishCardUp = false;

    public GameObject even1, even2, even3, even4, even5, even6, odd1, odd2, odd3, odd4, odd5;
    public GameObject youreTheBossPlayerName;
    public GameObject cardAvatar;
    public bool showNameOnce = true;

    private int currentBrandCrisisNumber = 0;

    private int currentCareerPointNumber = 0;

    private int currentYoureTheBossNumber = 0;

    private int playerStartNum = 0;

    private int currentDidYouKnowBlueNumber = 0;
    private int currentDidYouKnowGreenNumber = 0;
    private int currentDidYouKnowYellowNumber = 0;
    private int currentDidYouKnowRedNumber = 0;
    private int currentDidYouKnowPinkNumber = 0;
    private int currentDidYouKnowPurpleNumber = 0;
    private int didYouKnowTokenColor = 0;

    private PlayerInfo[] playersInfo = new PlayerInfo[6];

    private bool p1hasTakenToken = true;
    private bool p2hasTakenToken = true;
    private bool p3hasTakenToken = true;
    private bool p4hasTakenToken = true;
    private bool p5hasTakenToken = true;
    private bool p6hasTakenToken = true;

    public int playersPressed = 0;
    public int bossColor = 0;

    public void Start()
    {
        // Knuth shuffle algorithms
        //brand crisis
        for (int t = 0; t < brandCrisisCardFront.Length; t++)
        {
            Sprite tmp = brandCrisisCardFront[t];
            int r = UnityEngine.Random.Range(t, brandCrisisCardFront.Length);
            brandCrisisCardFront[t] = brandCrisisCardFront[r];
            brandCrisisCardFront[r] = tmp;
        }
        //career point
        for (int t = 0; t < careerPointCardFront.Length; t++)
        {
            Sprite tmp = careerPointCardFront[t];
            int r = UnityEngine.Random.Range(t, careerPointCardFront.Length);
            careerPointCardFront[t] = careerPointCardFront[r];
            careerPointCardFront[r] = tmp;
        }
        //youre the boss
        for (int t = 0; t < youreTheBossFront.Length; t++)
        {
            Sprite tmp = youreTheBossFront[t];
            int r = UnityEngine.Random.Range(t, youreTheBossFront.Length);
            youreTheBossFront[t] = youreTheBossFront[r];
            youreTheBossFront[r] = tmp;
        }
        //did you know blue
        for (int t = 0; t < didYouKnowCardFrontBlue.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontBlue[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontBlue.Length);
            didYouKnowCardFrontBlue[t] = didYouKnowCardFrontBlue[r];
            didYouKnowCardFrontBlue[r] = tmp;
        }
        //did you know green
        for (int t = 0; t < didYouKnowCardFrontGreen.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontGreen[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontGreen.Length);
            didYouKnowCardFrontGreen[t] = didYouKnowCardFrontGreen[r];
            didYouKnowCardFrontGreen[r] = tmp;
        }
        //did you know Yellow
        for (int t = 0; t < didYouKnowCardFrontYellow.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontYellow[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontYellow.Length);
            didYouKnowCardFrontYellow[t] = didYouKnowCardFrontYellow[r];
            didYouKnowCardFrontYellow[r] = tmp;
        }
        //did you know Red
        for (int t = 0; t < didYouKnowCardFrontRed.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontRed[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontRed.Length);
            didYouKnowCardFrontRed[t] = didYouKnowCardFrontRed[r];
            didYouKnowCardFrontRed[r] = tmp;
        }
        //did you know Pink
        for (int t = 0; t < didYouKnowCardFrontPink.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontPink[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontPink.Length);
            didYouKnowCardFrontPink[t] = didYouKnowCardFrontPink[r];
            didYouKnowCardFrontPink[r] = tmp;
        }
        //did you know Purple
        for (int t = 0; t < didYouKnowCardFrontPurple.Length; t++)
        {
            Sprite tmp = didYouKnowCardFrontPurple[t];
            int r = UnityEngine.Random.Range(t, didYouKnowCardFrontPurple.Length);
            didYouKnowCardFrontPurple[t] = didYouKnowCardFrontPurple[r];
            didYouKnowCardFrontPurple[r] = tmp;
        }

        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            playersInfo[i] = GameManager.instance.players[i].GetComponent<PlayerInfo>();
        }
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            didYouKnowButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[i].playerName;
        }
        for (int i = didYouKnowButtons.Length - 1; i >= GameManager.instance.currPlayers; i--)
        {
            didYouKnowButtons[i].SetActive(false);
        }
        shiftButtons(GameManager.instance.currPlayers);
    }

    public void SubmitEmail()
    {
        GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().email = emailInput.text;
        emailInput.gameObject.GetComponent<TMPro.TMP_InputField>().interactable = false;
        emailInput.gameObject.GetComponent<TMPro.TMP_InputField>().textComponent.fontStyle = TMPro.FontStyles.Italic;
        submitButton.gameObject.SetActive(false);
        editButton.gameObject.SetActive(true);
    }

    public void editEmail()
    {
        emailInput.gameObject.GetComponent<TMPro.TMP_InputField>().interactable = true;
        emailInput.gameObject.GetComponent<TMPro.TMP_InputField>().textComponent.fontStyle = TMPro.FontStyles.Normal;
        submitButton.gameObject.SetActive(true);
        editButton.gameObject.SetActive(false);
    }

    public void CardDown()
    {
        CardAnimator.SetBool("CardIsUp", false);
        continueButton.SetActive(false);
        chillButton.SetActive(false);
        claimVicButton.SetActive(false);
        keepGoingButton.SetActive(false);
        cardRead = true;
        finishCardUp = false;
        playersPressed = 0;
        youreTheButtons.SetActive(false);
        careerButtons.SetActive(false);
        didYouButtons.SetActive(false);
        p1hasTakenToken = true;
        p2hasTakenToken = true;
        p3hasTakenToken = true;
        p4hasTakenToken = true;
        p5hasTakenToken = true;
        p6hasTakenToken = true;
        cardAvatar.SetActive(false);
        youreTheBossPlayerName.SetActive(false);
        emailInput.gameObject.GetComponent<TMPro.TMP_InputField>().interactable = true;
        emailInput.gameObject.GetComponent<TMPro.TMP_InputField>().textComponent.fontStyle = TMPro.FontStyles.Normal;
        emailInput.text = "yourname@email.com";
        emailInput.gameObject.SetActive(false);
        editButton.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
        tShirt.SetActive(false);
        showNameOnce = true;
        emailInput.text = "yourname@email.com";
        if (GameManager.instance.playersDone >= GameManager.instance.currPlayers && SceneManager.GetActiveScene().buildIndex == 3)
        {
            FindObjectOfType<AudioManager>().Stop("Walk");
            SceneManager.LoadScene("endScene");
        }
    }

    public void SettingsDown()
    {
        SettingsAnimator.SetBool("isCardDown", true);
    }

    public void SettingsUp()
    {
        SettingsAnimator.SetBool("isCardDown", false);
    }

    public void CardButtonPressed(int buttonPressed)
    {
        switch (buttonPressed)
        {
            case 1:
                if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[0])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-1A");
                    playerMovementEffect = 2;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[1])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-2A");
                    playerMovementEffect = -2;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[2])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-3A");
                    playerMovementEffect = -1;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[3])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-4A");
                    playerMovementEffect = 1;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[4])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-5A");
                    playerMovementEffect = -1;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[5])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-6A");
                    playerMovementEffect = 2;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);

                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[6])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-7A");
                    playerMovementEffect = -1;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[7])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-8A");
                    playerDoesntMove = true;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 2:
                if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[0])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-1B");
                    playerDoesntMove = true;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[1])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-2B");
                    playerDoesntMove = true;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[2])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-3B");
                    playerDoesntMove = true;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[3])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-4B");
                    playerMovementEffect = -1;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[4])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-5B");
                    playerDoesntMove = true;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[5])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-6B");
                    playerDoesntMove = true;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[6])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-7B");
                    playerMovementEffect = 2;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                else if (careerPointCardFront[currentCareerPointNumber] == careerPointCardFrontIdentity[7])
                {
                    cardFront.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Cards/Front/Career Point/cp-card-8B");
                    playerMovementEffect = 2;
                    careerButtons.SetActive(false);
                    CardAnimation.instance.continueButton.SetActive(true);
                }
                if (currentCareerPointNumber < (careerPointCardFront.Length - 1)) currentCareerPointNumber++;
                else currentCareerPointNumber = 0;
                break;
            case 3:
                if (p1hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(1, didYouKnowTokenColor);
                    p1hasTakenToken = false;
                }
                break;
            case 4:
                if (p2hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(2, didYouKnowTokenColor);
                    p2hasTakenToken = false;
                }
                break;
            case 5:
                if (p3hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(3, didYouKnowTokenColor);
                    p3hasTakenToken = false;
                }
                break;
            case 6:
                if (p4hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(4, didYouKnowTokenColor);
                    p4hasTakenToken = false;
                }
                break;
            case 7:
                if (p5hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(5, didYouKnowTokenColor);
                    p5hasTakenToken = false;
                }
                break;
            case 8:
                if (p6hasTakenToken)
                {
                    TokenAnimation.instance.isBoss = false;
                    TokenAnimation.instance.SpawnToken(6, didYouKnowTokenColor);
                    p6hasTakenToken = false;
                }
                break;
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                Sprite f = cardFront.GetComponent<Image>().sprite;
                if (buttonPressed == 14 && (f == youreTheBossFrontIdentity[0] || f == youreTheBossFrontIdentity[3] || f == youreTheBossFrontIdentity[5] || f == youreTheBossFrontIdentity[6])) { }
                else
                {
                    TokenAnimation.instance.isBoss = true;
                    checkBossCard(buttonPressed - 8);

                    if (playersPressed < GameManager.instance.currPlayers) playersPressed++;
                    if (playersPressed >= GameManager.instance.currPlayers)
                    {
                        CardAnimation.instance.continueButton.SetActive(true);
                        if (currentYoureTheBossNumber < (youreTheBossFront.Length - 1)) currentYoureTheBossNumber++;
                        else currentYoureTheBossNumber = 0;
                    }
                    setNameAndSprite();
                }
                break;
            default:
                break;
        }
    }

    private void checkBossCard(int val)
    {
        if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[0])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 2;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 5;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[1])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 2;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 5;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[2])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 2;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 5;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[3])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 5;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 3;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[4])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 2;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 5;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }

        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[5])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 5;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 3;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[6])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 5;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 3;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
        else if (youreTheBossFront[currentYoureTheBossNumber] == youreTheBossFrontIdentity[7])
        {
            switch (val)
            {
                case 1:
                    bossColor = 6;
                    break;
                case 2:
                    bossColor = 2;
                    break;
                case 3:
                    bossColor = 4;
                    break;
                case 4:
                    bossColor = 5;
                    break;
                case 5:
                    bossColor = 1;
                    break;
                case 6:
                    bossColor = 3;
                    break;
                default:
                    break;
            }
        }
        int currPos = (playerStartNum + playersPressed <= GameManager.instance.currPlayers) ? playerStartNum + playersPressed - 1 : playerStartNum + playersPressed - GameManager.instance.currPlayers - 1;
        if (playersPressed < GameManager.instance.currPlayers) TokenAnimation.instance.SpawnToken(currPos + 1, bossColor);
    }

    public void SpriteSwap(int card)
    {
        switch (card)
        {
            case 1:
                cardBack.GetComponent<Image>().sprite = youreTheBoss;
                cardFront.GetComponent<Image>().sprite = youreTheBossFront[currentYoureTheBossNumber];
                youreTheButtons.SetActive(true);
                youreTheBossPlayerName.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                playerStartNum = GameManager.instance.currPlayerTurn;
                FindObjectOfType<AudioManager>().Play("You're the Boss");
                setNameAndSprite();
                break;
            case 2:
                cardBack.GetComponent<Image>().sprite = careerPointCardBack;
                cardFront.GetComponent<Image>().sprite = careerPointCardFront[currentCareerPointNumber];
                careerButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                setNameAndSprite();
                FindObjectOfType<AudioManager>().Play("Career Point");
                break;
            case 3:
                cardBack.GetComponent<Image>().sprite = brandCrisisCardBack;
                cardFront.GetComponent<Image>().sprite = brandCrisisCardFront[currentBrandCrisisNumber];
                if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[0] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[2] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[4] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[8])
                {
                    playerMovementEffect = -1;
                }
                else if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[3] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[5] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[6] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[7] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[10] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[11])
                {
                    playerMovementEffect = -2;
                }
                else if (brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[1] || brandCrisisCardFront[currentBrandCrisisNumber] == brandCrisisCardFrontIdentity[9])
                {
                    playerMovementEffect = -3;
                }
                if (currentBrandCrisisNumber < (brandCrisisCardFront.Length - 1)) currentBrandCrisisNumber++;
                else currentBrandCrisisNumber = 0;
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Brand Crisis");
                setNameAndSprite();
                break;
            case 4:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPurple;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPurple[currentDidYouKnowPurpleNumber];
                if (currentDidYouKnowPurpleNumber < (didYouKnowCardFrontPurple.Length - 1)) currentDidYouKnowPurpleNumber++;
                else currentDidYouKnowPurpleNumber = 0;
                didYouKnowTokenColor = 1;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonPurple;
                }
                didYouButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Did You Know");
                setNameAndSprite();
                break;
            case 5:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackGreen;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontGreen[currentDidYouKnowGreenNumber];
                if (currentDidYouKnowGreenNumber < (didYouKnowCardFrontGreen.Length - 1)) currentDidYouKnowGreenNumber++;
                else currentDidYouKnowGreenNumber = 0;
                didYouKnowTokenColor = 2;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonGreen;
                }
                didYouButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Did You Know");
                setNameAndSprite();
                break;
            case 6:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackRed;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontRed[currentDidYouKnowRedNumber];
                if (currentDidYouKnowRedNumber < (didYouKnowCardFrontRed.Length - 1)) currentDidYouKnowRedNumber++;
                else currentDidYouKnowRedNumber = 0;
                didYouKnowTokenColor = 3;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonRed;
                }
                didYouButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Did You Know");
                setNameAndSprite();
                break;
            case 7:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackPink;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontPink[currentDidYouKnowPinkNumber];
                if (currentDidYouKnowPinkNumber < (didYouKnowCardFrontPink.Length - 1)) currentDidYouKnowPinkNumber++;
                else currentDidYouKnowPinkNumber = 0;
                didYouKnowTokenColor = 4;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonPink;
                }
                didYouButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Did You Know");
                setNameAndSprite();
                break;
            case 8:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackYellow;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontYellow[currentDidYouKnowYellowNumber];
                if (currentDidYouKnowYellowNumber < (didYouKnowCardFrontYellow.Length - 1)) currentDidYouKnowYellowNumber++;
                else currentDidYouKnowYellowNumber = 0;
                didYouKnowTokenColor = 5;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonYellow;
                }
                didYouButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Did You Know");
                setNameAndSprite();
                break;
            case 9:
                cardBack.GetComponent<Image>().sprite = didYouKnowCardBackBlue;
                cardFront.GetComponent<Image>().sprite = didYouKnowCardFrontBlue[currentDidYouKnowBlueNumber];
                if (currentDidYouKnowBlueNumber < (didYouKnowCardFrontBlue.Length - 1)) currentDidYouKnowBlueNumber++;
                else currentDidYouKnowBlueNumber = 0;
                didYouKnowTokenColor = 6;
                for (int i = 0; i < didYouKnowButtons.Length; i++)
                {
                    didYouKnowButtons[i].GetComponent<Image>().sprite = didYouKnowButtonBlue;
                }
                didYouButtons.SetActive(true);
                blur.gameObject.SetActive(true);
                grayBlur.gameObject.SetActive(true);
                StartCoroutine("grayBlurFadeIn");
                FindObjectOfType<AudioManager>().Play("Did You Know");
                setNameAndSprite();
                break;
            case 10:
                // First Player Done
                cardBack.GetComponent<Image>().sprite = doneBackTall;
                cardFront.GetComponent<Image>().sprite = firstPlayerDone;
                emailInput.transform.localPosition = new Vector3(-7.9f, -15.2f, 0);
                submitButton.transform.localPosition = new Vector3(19.1f, -13.6f, 0);
                editButton.transform.localPosition = new Vector3(19.2f, -13.6f, 0);
                emailInput.gameObject.SetActive(true);
                submitButton.gameObject.SetActive(true);
                blur.gameObject.SetActive(true);
                rainbowBlur.gameObject.SetActive(true);
                StartCoroutine("rainbowBlurFadeIn");
                setNameAndSprite();
                break;
            case 11:
                // Other Players Done
                cardBack.GetComponent<Image>().sprite = doneBack;
                cardFront.GetComponent<Image>().sprite = otherPlayersDone;
                emailInput.transform.localPosition = new Vector3(-8.6f, -13.8f, 0);
                submitButton.transform.localPosition = new Vector3(18.4f, -12.2f, 0);
                editButton.transform.localPosition = new Vector3(18.4f, -12.2f, 0);
                emailInput.gameObject.SetActive(true);
                submitButton.gameObject.SetActive(true);
                blur.gameObject.SetActive(true);
                rainbowBlur.gameObject.SetActive(true);
                StartCoroutine("rainbowBlurFadeIn");
                setNameAndSprite();
                break;
            case 12:
                // All Players Done
                cardBack.GetComponent<Image>().sprite = doneBack;
                cardFront.GetComponent<Image>().sprite = allPlayersDone;
                emailInput.transform.localPosition = new Vector3(-8, -6, 0);
                submitButton.transform.localPosition = new Vector3(19, -4.4f, 0);
                editButton.transform.localPosition = new Vector3(19, -4.4f, 0);
                emailInput.gameObject.SetActive(true);
                submitButton.gameObject.SetActive(true);
                blur.gameObject.SetActive(true);
                rainbowBlur.gameObject.SetActive(true);
                StartCoroutine("rainbowBlurFadeIn");
                setNameAndSprite();
                break;
            default:
                break;
        }
    }

    private void shiftButtons(int players)
    {
        switch (players)
        {
            case 1:
                didYouKnowButtons[0].transform.position = odd3.transform.position;
                break;
            case 2:
                didYouKnowButtons[0].transform.position = even3.transform.position;
                didYouKnowButtons[1].transform.position = even4.transform.position;
                break;
            case 3:
                didYouKnowButtons[0].transform.position = odd2.transform.position;
                didYouKnowButtons[1].transform.position = odd3.transform.position;
                didYouKnowButtons[2].transform.position = odd4.transform.position;
                break;
            case 4:
                didYouKnowButtons[0].transform.position = even2.transform.position;
                didYouKnowButtons[1].transform.position = even3.transform.position;
                didYouKnowButtons[2].transform.position = even4.transform.position;
                didYouKnowButtons[3].transform.position = even5.transform.position;
                break;
            case 5:
                didYouKnowButtons[0].transform.position = odd1.transform.position;
                didYouKnowButtons[1].transform.position = odd2.transform.position;
                didYouKnowButtons[2].transform.position = odd3.transform.position;
                didYouKnowButtons[3].transform.position = odd4.transform.position;
                didYouKnowButtons[4].transform.position = odd5.transform.position;
                break;
            case 6:
                didYouKnowButtons[0].transform.position = even1.transform.position;
                didYouKnowButtons[1].transform.position = even2.transform.position;
                didYouKnowButtons[2].transform.position = even3.transform.position;
                didYouKnowButtons[3].transform.position = even4.transform.position;
                didYouKnowButtons[4].transform.position = even5.transform.position;
                didYouKnowButtons[5].transform.position = even6.transform.position;
                break;
        }
    }

    private void setNameAndSprite()
    {
        if (playersPressed < GameManager.instance.currPlayers)
        {
            if (showNameOnce) StartCoroutine(showNameWithDelay(1.75f));

            if (cardBack.GetComponent<Image>().sprite == careerPointCardBack)
            {
                cardAvatar.GetComponent<Image>().sprite = GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().avatar;
                int randChoice = Mathf.FloorToInt(Random.Range(1, 7));
                switch (randChoice)
                {
                    case 1:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().playerName + ", " + "take your pick!";
                        break;
                    case 2:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "You're up, " + GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().playerName;
                        break;
                    case 3:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Now it's your turn, " + GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().playerName;
                        break;
                    case 4:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "It's your call, " + GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().playerName;
                        break;
                    case 5:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "What'll it be, " + GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().playerName + "?";
                        break;
                    case 6:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "All eyes on you, " + GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().playerName;
                        break;
                }
            }
            else if (cardBack.GetComponent<Image>().sprite == youreTheBoss)
            {
                int currPos = (playerStartNum + playersPressed <= GameManager.instance.currPlayers) ? playerStartNum + playersPressed - 1 : playerStartNum + playersPressed - GameManager.instance.currPlayers - 1;
                cardAvatar.GetComponent<Image>().sprite = GameManager.instance.players[currPos].GetComponent<PlayerInfo>().avatar;
                int randChoice = Mathf.FloorToInt(Random.Range(1, 7));
                switch (randChoice)
                {
                    case 1:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPos].GetComponent<PlayerInfo>().playerName + ", " + "take your pick!";
                        break;
                    case 2:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "You're up, " + GameManager.instance.players[currPos].GetComponent<PlayerInfo>().playerName;
                        break;
                    case 3:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Now it's your turn, " + GameManager.instance.players[currPos].GetComponent<PlayerInfo>().playerName;
                        break;
                    case 4:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "It's your call, " + GameManager.instance.players[currPos].GetComponent<PlayerInfo>().playerName;
                        break;
                    case 5:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "What'll it be, " + GameManager.instance.players[currPos].GetComponent<PlayerInfo>().playerName + "?";
                        break;
                    case 6:
                        youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "All eyes on you, " + GameManager.instance.players[currPos].GetComponent<PlayerInfo>().playerName;
                        break;
                }
            }
            else
            {
                cardAvatar.GetComponent<Image>().sprite = GameManager.instance.players[GameManager.instance.currPlayerTurn - 1].GetComponent<PlayerInfo>().avatar;
            }
            youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = youreTheBossPlayerName.GetComponentInChildren<TMPro.TextMeshProUGUI>().text.ToUpper();
        }
        else
        {
            youreTheBossPlayerName.SetActive(false);
            cardAvatar.SetActive(false);
        }
    }

    IEnumerator showNameWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (cardFront.GetComponent<Image>().sprite == firstPlayerDone)
        {
            tShirt.SetActive(true);
            claimVicButton.SetActive(true);
            cardAvatar.SetActive(true);
        }
        else if (cardFront.GetComponent<Image>().sprite == otherPlayersDone)
        {
            chillButton.SetActive(true);
            cardAvatar.SetActive(true);
        }
        else if (cardFront.GetComponent<Image>().sprite == allPlayersDone)
        {
            keepGoingButton.SetActive(true);
            cardAvatar.SetActive(true);
        }
        else if (didYouButtons.activeSelf == true || cardBack.GetComponent<Image>().sprite == brandCrisisCardBack)
        {
            continueButton.SetActive(true);
        }
        else
        {
            youreTheBossPlayerName.SetActive(true);
            cardAvatar.SetActive(true);
        }

        showNameOnce = false;
    }

    IEnumerator grayBlurFadeIn()
    {
        blur.GetComponent<Image>().material.SetFloat("_Size", 0);
        grayBlur.GetComponent<Image>().color = new Color(.375f, .375f, .375f, 0);

        for (float a = 0; a < 1f; a += .03f)
        {
            blur.GetComponent<Image>().material.SetFloat("_Size", a);
            if (a <= .375f)
            {
                Color grayFade = grayBlur.GetComponent<Image>().color;
                grayFade.a = a;
                grayBlur.GetComponent<Image>().color = grayFade;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator rainbowBlurFadeIn()
    {
        blur.GetComponent<Image>().material.SetFloat("_Size", 0);
        rainbowBlur.GetComponent<Image>().color = new Color(.375f, .375f, .375f, 0);

        for (float a = 0; a < 1f; a += .03f)
        {
            blur.GetComponent<Image>().material.SetFloat("_Size", a);
            if (a <= .75f)
            {
                Color rainbowFade = rainbowBlur.GetComponent<Image>().color;
                rainbowFade.a = a;
                rainbowBlur.GetComponent<Image>().color = rainbowFade;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator grayBlurFadeOut()
    {
        blur.GetComponent<Image>().material.SetFloat("_Size", 1);
        grayBlur.GetComponent<Image>().color = new Color(.375f, .375f, .375f, .375f);

        for (float a = 1; a > -1f; a -= .05f)
        {
            blur.GetComponent<Image>().material.SetFloat("_Size", a);
            if (a <= .375f)
            {
                Color grayFade = grayBlur.GetComponent<Image>().color;
                grayFade.a = a;
                grayBlur.GetComponent<Image>().color = grayFade;
            }

            if (a <= 0)
            {
                blur.SetActive(false);
                grayBlur.SetActive(false);
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator rainbowBlurFadeOut()
    {
        blur.GetComponent<Image>().material.SetFloat("_Size", 1);
        rainbowBlur.GetComponent<Image>().color = new Color(.375f, .375f, .375f, .75f);

        for (float a = 1; a > -1f; a -= .05f)
        {
            blur.GetComponent<Image>().material.SetFloat("_Size", a);
            if (a <= .75f)
            {
                Color rainbowFade = rainbowBlur.GetComponent<Image>().color;
                rainbowFade.a = a;
                rainbowBlur.GetComponent<Image>().color = rainbowFade;
            }

            if (a <= 0)
            {
                blur.SetActive(false);
                rainbowBlur.SetActive(false);
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public void grayCorutine()
    {
        StartCoroutine("grayBlurFadeOut");
    }
    public void rainbowCorutine()
    {
        StartCoroutine("rainbowBlurFadeOut");
    }
}