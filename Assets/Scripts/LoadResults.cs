using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadResults : MonoBehaviour
{

    public Sprite advertAccount, bpManager, salesProf, marketResearchS, mDirector, salesManage, freelancer, healthMarketer, gmTech, gmTechSales, customerProject, bdAnalyst, marketResearchA, sysArch, creativeDirect, researchDirect, mPlanner, uxDesign, uiDesign, contentStrategist, corpCommManager, prDirect;
    public GameObject jobTitle, salary;
    public GameObject playerName;
    public GameObject avatar;
    public int playerPlace;
    private int playerIndex;
    private Image backdrop;

    private Sprite shortcut;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            if (GameManager.instance.players[i].GetComponent<PlayerInfo>().place == playerPlace) playerIndex = i;
        }
        playerName.GetComponent<TMPro.TextMeshProUGUI>().text = GameManager.instance.players[playerIndex].GetComponent<PlayerInfo>().playerName;
        if (GameManager.instance.players[playerIndex] == null) gameObject.SetActive(false);
        backdrop = gameObject.GetComponent<Image>();
        shortcut = GameManager.instance.players[playerIndex].GetComponent<PlayerInfo>().careerChoice;
        // switch case to check sprites
        if (shortcut == advertAccount)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Advertising Account Manager";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$62,252";
        }
        else if (shortcut == bpManager)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Brand/Product Manager";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$132,840";
        }
        else if (shortcut == salesProf)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Sales Professional";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$62,080";
        }
        else if (shortcut == marketResearchS)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Marketing Research Specialist";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$50,500";
        }
        else if (shortcut == mDirector)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Marketing Director";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$115,000";
        }
        else if (shortcut == salesManage)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Sales Manager";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$74,750";
        }
        else if (shortcut == freelancer)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Freelance Writer";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$49,400";
        }
        else if (shortcut == healthMarketer)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Healthcare Marketer";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$84,000";
        }
        else if (shortcut == gmTech)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Graphic Media Technician";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$49,000";
        }
        else if (shortcut == gmTechSales)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Graphic Media Technical Sales Representative";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$49,000";
        }
        else if (shortcut == customerProject)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Customer Service Project Manager";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$75,000";
        }
        else if (shortcut == bdAnalyst)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Business Data Analyst";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$69,252";
        }
        else if (shortcut == marketResearchA)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Market Research Analyst";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$58,000";
        }
        else if (shortcut == sysArch)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "System Architect";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$105,000";
        }
        else if (shortcut == creativeDirect)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Creative Director";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$132,770";
        }
        else if (shortcut == researchDirect)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Research Director";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$117,000";
        }
        else if (shortcut == mPlanner)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Media Planner";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$54,000";
        }
        else if (shortcut == uxDesign)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "User Experience Designer";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$90,700";
        }
        else if (shortcut == uiDesign)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "User Interface Designer";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$80,500";
        }
        else if (shortcut == contentStrategist)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Content Strategist";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$72,500";
        }
        else if (shortcut == corpCommManager)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Corporate Communications Manager";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$70,401";
        }
        else if (shortcut == prDirect)
        {
            jobTitle.GetComponent<TMPro.TextMeshProUGUI>().text = "Public Relations Director";
            salary.GetComponent<TMPro.TextMeshProUGUI>().text = "$82,800";
        }
        avatar.GetComponent<Image>().sprite = GameManager.instance.players[playerIndex].GetComponent<PlayerInfo>().avatar;
        Color tempColor = new Color();
        switch(GameManager.instance.players[playerIndex].GetComponent<PlayerInfo>().fieldChoice)
        {
            case "Design":
                tempColor = new Color(.937255f, .2039216f, .1372549f);
                break;
            case "Public Relations":
                tempColor = new Color(1f, .7803922f, .1803922f);
                break;
            case "Graphic Media Management":
                tempColor = new Color(.6980392f, .7137255f, .172549f);
                break;
            case "Advertising":
                tempColor = new Color(.2784314f, .7686275f, .8274511f);
                break;
            case "Business Data Analytics":
                tempColor = new Color(.882353f, .4941177f, .627451f);
                break;
            case "Marketing":
                tempColor = new Color(.5176471f, .5568628f, .6980392f);
                break;
        }
        backdrop.color = tempColor;
    }
}
