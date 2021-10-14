using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    public GameObject careerPanel, fieldPanel;
    private bool isField = true;

    public GameObject cPlayerName;
    public GameObject careerOptionLeft, careerOptionMid, careerOptionRight;
    public GameObject selection, confirmButton, congrats, congratsPlayer, greatJobTitle;
    public GameObject upArrow, downArrow;
    public GameObject fMainAvatar, cMainAvatar, congratsAvatar;
    public GameObject fieldBackdrop;
    private string career;
    private bool lower = false;

    public GameObject fPlayerName;
    public GameObject aTokens, gmmTokens, bdaTokens, mTokens, gdTokens, prTokens;

    private Sprite aBack, bdaBack, mBack, gmmBack, prBack, dBack;
    private Sprite advertAccount, bpManager, salesProf, marketResearchS, mDirector, salesManage, freelancer, healthMarketer, gmTech, gmTechSales, customerProject, bdAnalyst, marketResearchA, sysArch, creativeDirect, researchDirect, mPlanner, uxDesign, uiDesign, contentStrategist, corpCommManager, prDirect;


    private int currPlayer = 0;
    private int playerPlace = 1;

    void Start()
    {
        advertAccount = Resources.Load<Sprite>("Materials/Job Cards/jc-blue1");
        bpManager = Resources.Load<Sprite>("Materials/Job Cards/jc-blue2");
        salesProf = Resources.Load<Sprite>("Materials/Job Cards/jc-blue3");
        marketResearchS = Resources.Load<Sprite>("Materials/Job Cards/jc-blue4");
        mDirector = Resources.Load<Sprite>("Materials/Job Cards/jc-blue5");
        salesManage = Resources.Load<Sprite>("Materials/Job Cards/jc-blue6");
        freelancer = Resources.Load<Sprite>("Materials/Job Cards/jc-blue7");
        healthMarketer = Resources.Load<Sprite>("Materials/Job Cards/jc-blue8");
        gmTech = Resources.Load<Sprite>("Materials/Job Cards/jc-green1");
        gmTechSales = Resources.Load<Sprite>("Materials/Job Cards/jc-green2");
        customerProject = Resources.Load<Sprite>("Materials/Job Cards/jc-green3");
        bdAnalyst = Resources.Load<Sprite>("Materials/Job Cards/jc-pink1");
        marketResearchA = Resources.Load<Sprite>("Materials/Job Cards/jc-pink2");
        sysArch = Resources.Load<Sprite>("Materials/Job Cards/jc-pink3");
        creativeDirect = Resources.Load<Sprite>("Materials/Job Cards/jc-purple1");
        researchDirect = Resources.Load<Sprite>("Materials/Job Cards/jc-purple2");
        mPlanner = Resources.Load<Sprite>("Materials/Job Cards/jc-purple3");
        uxDesign = Resources.Load<Sprite>("Materials/Job Cards/jc-red2");
        uiDesign = Resources.Load<Sprite>("Materials/Job Cards/jc-red3");
        contentStrategist = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow1");
        corpCommManager = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow2");
        prDirect = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow4");

        aBack = Resources.Load<Sprite>("Materials/Background/FieldChoices/Advertisement");
        bdaBack = Resources.Load<Sprite>("Materials/Background/FieldChoices/Business Data");
        mBack = Resources.Load<Sprite>("Materials/Background/FieldChoices/Marketing");
        gmmBack = Resources.Load<Sprite>("Materials/Background/FieldChoices/Graphic Media");
        prBack = Resources.Load<Sprite>("Materials/Background/FieldChoices/Public Relations");
        dBack = Resources.Load<Sprite>("Materials/Background/FieldChoices/Design");
        updatePlayers(playerPlace);
    }

    void Update()
    {
        /*
        if (GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email != null && GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email != "yourname@email.com")
        {
            cLearnMore.SetActive(false);
            cEmailInput.SetActive(false);
            cSubmitButton.SetActive(false);
            fLearnMore.SetActive(false);
            fEmailInput.SetActive(false);
            fSubmitButton.SetActive(false);
        }
        else
        {
            if(isField)
            {
                fLearnMore.SetActive(true);
                fEmailInput.SetActive(true);
                fSubmitButton.SetActive(true);
            }
            else
            {
                cLearnMore.SetActive(true);
                cEmailInput.SetActive(true);
                cSubmitButton.SetActive(true);
            }
            
            
        }
        */
        if (GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice != null) changeFieldDisplay(GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice);
    }

    public void swapPanels(TMPro.TextMeshProUGUI text)
    {
        if (isField)
        {
            GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().fieldChoice = text.text;
            selection.GetComponent<TMPro.TextMeshProUGUI>().text = "Nice choice! You selected the " + text.text + " field!";
            fieldPanel.SetActive(false);
            careerPanel.SetActive(true);
            isField = false;
        }
        else
        {
            fieldPanel.SetActive(true);
            careerPanel.SetActive(false);
            isField = true;
        }
        //updatePlayers(playerPlace);
    }

    public void goBack()
    {
        swapPanels(null);
    }

    public void shiftChoices()
    {
        lower = !lower;
    }
    private void changeFieldDisplay(string choice)
    {
        switch (choice)
        {
            case "Design":
                careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple1");
                careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-red2");
                careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-red3");
                upArrow.SetActive(false);
                downArrow.SetActive(false);
                fieldBackdrop.GetComponent<Image>().sprite = dBack;
                break;
            case "Public Relations":
                upArrow.SetActive(true);
                downArrow.SetActive(true);
                if (lower)
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-yellow4");
                }
                else
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue4");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue5");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue6");
                }
                fieldBackdrop.GetComponent<Image>().sprite = prBack;
                break;
            case "Graphic Media Management":

                careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-green1");
                careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-green2");
                careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-green3");
                upArrow.SetActive(false);
                downArrow.SetActive(false);
                fieldBackdrop.GetComponent<Image>().sprite = gmmBack;
                break;
            case "Advertising":
                upArrow.SetActive(true);
                downArrow.SetActive(true);
                if (lower)
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue3");
                }
                else
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue4");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue7");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue8");
                }
                fieldBackdrop.GetComponent<Image>().sprite = aBack;
                break;
            case "Business Data Analytics":
                careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-pink1");
                careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-pink2");
                careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-pink3");
                upArrow.SetActive(false);
                downArrow.SetActive(false);
                fieldBackdrop.GetComponent<Image>().sprite = bdaBack;
                break;
            case "Marketing":
                upArrow.SetActive(true);
                downArrow.SetActive(true);
                if (lower)
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-purple3");
                }
                else
                {
                    careerOptionLeft.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue1");
                    careerOptionMid.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue2");
                    careerOptionRight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/Job Cards/jc-blue3");
                }
                fieldBackdrop.GetComponent<Image>().sprite = mBack;
                break;
        }
    }
    public void confirmChoice(GameObject g)
    {
        confirmButton.SetActive(true);
        GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice = g.GetComponent<Image>().sprite;
        if (g == careerOptionLeft)
        {
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
        else if (g == careerOptionMid)
        {
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        }
        else if (g == careerOptionRight)
        {
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        }

    }
    public void submitEmail(GameObject email)
    {
        //if (emailInput.GetComponent<TMPro.TextMeshProUGUI>().text != "yourname@email.com" && emailInput.GetComponent<TMPro.TextMeshProUGUI>().text.Contains("@") && emailInput.GetComponent<TMPro.TextMeshProUGUI>().text.Contains("."))
        if (email.GetComponent<TMPro.TMP_InputField>().text != "yourname@email.com" && email.GetComponent<TMPro.TMP_InputField>().text.Contains("@") && email.GetComponent<TMPro.TMP_InputField>().text.Contains("."))
        {
            Debug.Log("submitEmail() called");
            Debug.Log(email.GetComponent<TMPro.TMP_InputField>().text);
            GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().email = email.GetComponent<TMPro.TMP_InputField>().text;
        }
    }
    public void congratsPrompt()
    {
        congrats.SetActive(true);
        Sprite shortcut = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice;
        // switch case to check sprites
        if (shortcut == advertAccount) career = "Advertising Account Manager";
        else if (shortcut == bpManager) career = "Brand/Product Manager";
        else if (shortcut == salesProf) career = "Sales Professional";
        else if (shortcut == marketResearchS) career = "Marketing Research Specialist";
        else if (shortcut == mDirector) career = "Marketing Director";
        else if (shortcut == salesManage) career = "Sales Manager";
        else if (shortcut == freelancer) career = "Freelance Writer";
        else if (shortcut == healthMarketer) career = "Healthcare Marketer";
        else if (shortcut == gmTech) career = "Graphic Media Technician";
        else if (shortcut == gmTechSales) career = "Graphic Media Technical Sales Representative";
        else if (shortcut == customerProject) career = "Customer Service Project Manager";
        else if (shortcut == bdAnalyst) career = "Business Data Analyst";
        else if (shortcut == marketResearchA) career = "Market Research Analyst";
        else if (shortcut == sysArch) career = "System Architect";
        else if (shortcut == creativeDirect) career = "Creative Director";
        else if (shortcut == researchDirect) career = "Research Director";
        else if (shortcut == mPlanner) career = "Media Planner";
        else if (shortcut == uxDesign) career = "User Experience Designer";
        else if (shortcut == uiDesign) career = "User Interface Designer";
        else if (shortcut == contentStrategist) career = "Content Strategist";
        else if (shortcut == corpCommManager) career = "Corporate Communications Manager";
        else if (shortcut == prDirect) career = "Public Relations Director";

        greatJobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "You'll make a great " + career + "!";
        randomCongrats();

    }

    private void randomCongrats()
    {
        int randChoice = Mathf.FloorToInt(Random.Range(1, 7));
        switch (randChoice)
        {
            case 1:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Kudos on your new career path, " + cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 2:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "I'm impressed! Nice choice, " + cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 3:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "What an awesome career choice, " + cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 4:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Way to go on your promotion, " + cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 5:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "Kudos on the new job! You earned it, " + cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;
            case 6:
                congratsPlayer.GetComponent<TMPro.TextMeshProUGUI>().text = "What a cool career! Nice going, " + cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text + "!";
                break;

        }
    }
    void updatePlayers(int place)
    {
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            if (GameManager.instance.players[i].GetComponent<PlayerInfo>().place == place) currPlayer = i;
        }
        fPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName;
        mTokens.GetComponent<TMPro.TextMeshProUGUI>().text = " x " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[0].ToString();
        gmmTokens.GetComponent<TMPro.TextMeshProUGUI>().text = " x " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[1].ToString();
        gdTokens.GetComponent<TMPro.TextMeshProUGUI>().text = " x " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[2].ToString();
        bdaTokens.GetComponent<TMPro.TextMeshProUGUI>().text = " x " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[3].ToString();
        prTokens.GetComponent<TMPro.TextMeshProUGUI>().text = " x " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[4].ToString();
        aTokens.GetComponent<TMPro.TextMeshProUGUI>().text = " x " + GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().tokens[5].ToString();
        //fLearnMore.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName + ", want to learn more or schedule a visit to Ferris State's campus? Enter your email to find out more!";

        cPlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName;
        //cLearnMore.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().playerName + ", want to learn more or schedule a visit to Ferris State's campus? Enter your email to find out more!";
        fMainAvatar.GetComponent<Image>().sprite = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().avatar;
        cMainAvatar.GetComponent<Image>().sprite = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().avatar;
        congratsAvatar.GetComponent<Image>().sprite = GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().avatar;
    }

    public void nextPlayer()
    {
        playerPlace++;
        if (playerPlace >= GameManager.instance.currPlayers + 1) SceneManager.LoadScene("resultsScene");
        else
        {
            updatePlayers(playerPlace);
            congrats.SetActive(false);
            confirmButton.SetActive(false);
            careerOptionMid.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            careerOptionRight.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            careerOptionLeft.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            GameManager.instance.players[currPlayer].GetComponent<PlayerInfo>().careerChoice = null;
            swapPanels(null);
        }

    }
}
