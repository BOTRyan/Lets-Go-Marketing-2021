using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenAnimation : MonoBehaviour
{
    #region Singleton

    public static TokenAnimation instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Vector3 buttonLocation;
    public Button[] playerButtons;
    public Transform[] purpleTokens;
    public Transform[] greenTokens;
    public Transform[] redTokens;
    public Transform[] pinkTokens;
    public Transform[] yellowTokens;
    public Transform[] blueTokens;
    public static int tokenColor;
    public Sprite tokenPurple;
    public Sprite tokenGreen;
    public Sprite tokenRed;
    public Sprite tokenPink;
    public Sprite tokenYellow;
    public Sprite tokenBlue;
    public GameObject token;

    public Transform endPosition;
    public Sprite playerSprite;
    public int playerNumber;
    public int playerWhoPressed = 0;
    public Canvas canvas;

    public bool isBoss = false;

    public void SpawnToken(int player, int color)
    {
        tokenColor = color;
        playerWhoPressed = player;
        GetButtonLocationsAndColor(player);
        Instantiate(token, buttonLocation, Quaternion.identity, canvas.transform);
        FindObjectOfType<AudioManager>().PlayUninterrupted("Token Added");
    }

    public void SpriteSwap(int player, int color)
    {
        playerNumber = player;
        switch (color)
        {
            case 1:
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-purple_256x256");
                break;
            case 2:
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-green_256x256");
                break;
            case 3:
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-red_256x256");
                break;
            case 4:
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-pink_256x256");
                break;
            case 5:
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-yellow_256x256");
                break;
            case 6:
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-blue_256x256");
                break;
            default:
                break;
        }
    }

    public void GetButtonLocationsAndColor(int player)
    {
        switch (player)
        {
            case 1:
                //player 1
                playerNumber = 1;
                buttonLocation = playerButtons[0].transform.position;
                GetEndLocation(1);
                break;
            case 2:
                //player 2
                playerNumber = 2;
                buttonLocation = playerButtons[1].transform.position;
                GetEndLocation(2);
                break;
            case 3:
                //player 3
                playerNumber = 3;
                buttonLocation = playerButtons[2].transform.position;
                GetEndLocation(3);
                break;
            case 4:
                //player 4
                playerNumber = 4;
                buttonLocation = playerButtons[3].transform.position;
                GetEndLocation(4);
                break;
            case 5:
                //player 5
                playerNumber = 5;
                buttonLocation = playerButtons[4].transform.position;
                GetEndLocation(5);
                break;
            case 6:
                //player 6
                playerNumber = 6;
                buttonLocation = playerButtons[5].transform.position;
                GetEndLocation(6);
                break;
            default:
                break;
        }
        if (isBoss) buttonLocation = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        switch (tokenColor)
        {
            case 1:
                playerSprite = tokenPurple;
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-check-purple");
                break;
            case 2:
                playerSprite = tokenGreen;
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-check-green");
                break;
            case 3:
                playerSprite = tokenRed;
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-check-red");
                break;
            case 4:
                playerSprite = tokenPink;
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-check-pink");
                break;
            case 5:
                playerSprite = tokenYellow;
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-check-yellow");
                break;
            case 6:
                playerSprite = tokenBlue;
                playerButtons[playerNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/UI/button-check-blue");
                break;
            default:
                break;
        }
    }

    public void GetEndLocation(int player)
    {
        if (isBoss) tokenColor = CardAnimation.instance.bossColor;

        switch (tokenColor)
        {
            case 1:
                switch (player)
                {
                    case 1:
                        endPosition = purpleTokens[0];
                        break;
                    case 2:
                        endPosition = purpleTokens[1];
                        break;
                    case 3:
                        endPosition = purpleTokens[2];
                        break;
                    case 4:
                        endPosition = purpleTokens[3];
                        break;
                    case 5:
                        endPosition = purpleTokens[4];
                        break;
                    case 6:
                        endPosition = purpleTokens[5];
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (player)
                {
                    case 1:
                        endPosition = greenTokens[0];
                        break;
                    case 2:
                        endPosition = greenTokens[1];
                        break;
                    case 3:
                        endPosition = greenTokens[2];
                        break;
                    case 4:
                        endPosition = greenTokens[3];
                        break;
                    case 5:
                        endPosition = greenTokens[4];
                        break;
                    case 6:
                        endPosition = greenTokens[5];
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch (player)
                {
                    case 1:
                        endPosition = redTokens[0];
                        break;
                    case 2:
                        endPosition = redTokens[1];
                        break;
                    case 3:
                        endPosition = redTokens[2];
                        break;
                    case 4:
                        endPosition = redTokens[3];
                        break;
                    case 5:
                        endPosition = redTokens[4];
                        break;
                    case 6:
                        endPosition = redTokens[5];
                        break;
                    default:
                        break;
                }
                break;
            case 4:
                switch (player)
                {
                    case 1:
                        endPosition = pinkTokens[0];
                        break;
                    case 2:
                        endPosition = pinkTokens[1];
                        break;
                    case 3:
                        endPosition = pinkTokens[2];
                        break;
                    case 4:
                        endPosition = pinkTokens[3];
                        break;
                    case 5:
                        endPosition = pinkTokens[4];
                        break;
                    case 6:
                        endPosition = pinkTokens[5];
                        break;
                    default:
                        break;
                }
                break;
            case 5:
                switch (player)
                {
                    case 1:
                        endPosition = yellowTokens[0];
                        break;
                    case 2:
                        endPosition = yellowTokens[1];
                        break;
                    case 3:
                        endPosition = yellowTokens[2];
                        break;
                    case 4:
                        endPosition = yellowTokens[3];
                        break;
                    case 5:
                        endPosition = yellowTokens[4];
                        break;
                    case 6:
                        endPosition = yellowTokens[5];
                        break;
                    default:
                        break;
                }
                break;
            case 6:
                switch (player)
                {
                    case 1:
                        endPosition = blueTokens[0];
                        break;
                    case 2:
                        endPosition = blueTokens[1];
                        break;
                    case 3:
                        endPosition = blueTokens[2];
                        break;
                    case 4:
                        endPosition = blueTokens[3];
                        break;
                    case 5:
                        endPosition = blueTokens[4];
                        break;
                    case 6:
                        endPosition = blueTokens[5];
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}
