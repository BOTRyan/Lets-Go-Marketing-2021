using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{

    #region Singleton

    public static UIPlayerInfo instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Player1Info;
    public GameObject Player2Info;
    public GameObject Player3Info;
    public GameObject Player4Info;
    public GameObject Player5Info;
    public GameObject Player6Info;

    public GameObject placeEven1, placeEven2, placeEven3, placeEven4, placeEven5, placeEven6, placeOdd1, placeOdd2, placeOdd3, placeOdd4, placeOdd5;

    public List<GameObject> p1Tokens = new List<GameObject>();
    public List<GameObject> p2Tokens = new List<GameObject>();
    public List<GameObject> p3Tokens = new List<GameObject>();
    public List<GameObject> p4Tokens = new List<GameObject>();
    public List<GameObject> p5Tokens = new List<GameObject>();
    public List<GameObject> p6Tokens = new List<GameObject>();

    private PlayerInfo[] playersInfo = new PlayerInfo[6];
    private GameObject[] playersInfoUI;

    private int playerAmt;

    void Start()
    {
        playerAmt = GameManager.instance.currPlayers;

        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            playersInfo[i] = GameManager.instance.players[i].GetComponent<PlayerInfo>();
        }

        playersInfoUI = new GameObject[] { Player1Info, Player2Info, Player3Info, Player4Info, Player5Info, Player6Info };

        GetTokenChildren();

        checkPlayerCount();

        setPlayerNameAndAvatar();

        setTokenAmounts();

        setTagLocation();
    }

    public void setTokenAmounts()
    {
        if (playerAmt >= 1)
        {
            for (int i = 0; i < p1Tokens.Count; i++)
            {
                p1Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[0].tokens[i].ToString();
                if (playersInfo[0].tokens[i] <= 0) p1Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";
            }
        }
        if (playerAmt >= 2)
        {
            for (int i = 0; i < p2Tokens.Count; i++)
            {
                p2Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[1].tokens[i].ToString();
                if (playersInfo[1].tokens[i] <= 0) p2Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";
            }
        }
        if (playerAmt >= 3)
        {
            for (int i = 0; i < p3Tokens.Count; i++)
            {
                p3Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[2].tokens[i].ToString();
                if (playersInfo[2].tokens[i] <= 0) p3Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";
            }
        }
        if (playerAmt >= 4)
        {
            for (int i = 0; i < p4Tokens.Count; i++)
            {
                p4Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[3].tokens[i].ToString();
                if (playersInfo[3].tokens[i] <= 0) p4Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";
            }
        }
        if (playerAmt >= 5)
        {
            for (int i = 0; i < p5Tokens.Count; i++)
            {
                p5Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[4].tokens[i].ToString();
                if (playersInfo[4].tokens[i] <= 0) p5Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";
            }
        }
        if (playerAmt == 6)
        {
            for (int i = 0; i < p6Tokens.Count; i++)
            {
                p6Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[5].tokens[i].ToString();
                if (playersInfo[5].tokens[i] <= 0) p6Tokens[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "0";
            }
        }
    }

    private void setPlayerNameAndAvatar()
    {
        for (int i = 0; i < playerAmt; i++)
        {
            playersInfoUI[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playersInfo[i].playerName;
        }
    }

    private void checkPlayerCount()
    {
        for (int i = playersInfoUI.Length - 1; i >= playerAmt; i--)
        {
            playersInfoUI[i].SetActive(false);
        }
    }

    private void GetTokenChildren()
    {
        for (int i = 0; i < Player1Info.transform.childCount; i++)
        {
            p1Tokens.Add(Player1Info.transform.GetChild(i).gameObject);
        }
        p1Tokens.RemoveAt(0);

        for (int i = 0; i < Player2Info.transform.childCount; i++)
        {
            p2Tokens.Add(Player2Info.transform.GetChild(i).gameObject);
        }
        p2Tokens.RemoveAt(0);

        for (int i = 0; i < Player3Info.transform.childCount; i++)
        {
            p3Tokens.Add(Player3Info.transform.GetChild(i).gameObject);
        }
        p3Tokens.RemoveAt(0);

        for (int i = 0; i < Player4Info.transform.childCount; i++)
        {
            p4Tokens.Add(Player4Info.transform.GetChild(i).gameObject);
        }
        p4Tokens.RemoveAt(0);

        for (int i = 0; i < Player5Info.transform.childCount; i++)
        {
            p5Tokens.Add(Player5Info.transform.GetChild(i).gameObject);
        }
        p5Tokens.RemoveAt(0);

        for (int i = 0; i < Player6Info.transform.childCount; i++)
        {
            p6Tokens.Add(Player6Info.transform.GetChild(i).gameObject);
        }
        p6Tokens.RemoveAt(0);
    }

    private void setTagLocation()
    {
        switch(playerAmt)
        {
            case 1:
                playersInfoUI[0].transform.position = placeOdd3.transform.position;
                break;
            case 2:
                playersInfoUI[0].transform.position = placeEven3.transform.position;
                playersInfoUI[1].transform.position = placeEven4.transform.position;
                break;
            case 3:
                playersInfoUI[0].transform.position = placeOdd2.transform.position;
                playersInfoUI[1].transform.position = placeOdd3.transform.position;
                playersInfoUI[2].transform.position = placeOdd4.transform.position;
                break;
            case 4:
                playersInfoUI[0].transform.position = placeEven2.transform.position;
                playersInfoUI[1].transform.position = placeEven3.transform.position;
                playersInfoUI[2].transform.position = placeEven4.transform.position;
                playersInfoUI[3].transform.position = placeEven5.transform.position;
                break;
            case 5:
                playersInfoUI[0].transform.position = placeOdd1.transform.position;
                playersInfoUI[1].transform.position = placeOdd2.transform.position;
                playersInfoUI[2].transform.position = placeOdd3.transform.position;
                playersInfoUI[3].transform.position = placeOdd4.transform.position;
                playersInfoUI[4].transform.position = placeOdd5.transform.position;
                break;
            case 6:
                playersInfoUI[0].transform.position = placeEven1.transform.position;
                playersInfoUI[1].transform.position = placeEven2.transform.position;
                playersInfoUI[2].transform.position = placeEven3.transform.position;
                playersInfoUI[3].transform.position = placeEven4.transform.position;
                playersInfoUI[4].transform.position = placeEven5.transform.position;
                playersInfoUI[5].transform.position = placeEven6.transform.position;
                break;
        }
    }
}
