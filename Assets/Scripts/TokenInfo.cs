using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenInfo : MonoBehaviour
{
    private float alpha = 0;
    private float animAlpha = 0;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 handlePosition;
    public int playerWhoPressed = 0;
    public int tokenType = 0;
    public int color = 0;
    private List<PlayerInfo> playersInfo = new List<PlayerInfo>();
    // private bool infoOnce = true;

    private bool startLerp = false;
    private float animDelay = 1;

    void Start()
    {
        startPosition = TokenAnimation.instance.buttonLocation;
        endPosition = TokenAnimation.instance.endPosition.position;
        handlePosition = TokenAnimation.instance.gameObject.transform.position;
        GetComponent<Image>().sprite = TokenAnimation.instance.playerSprite;
        transform.localScale = new Vector3(8, 8, 0);
        playerWhoPressed = TokenAnimation.instance.playerWhoPressed;
        tokenType = TokenAnimation.tokenColor;
        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            playersInfo.Add(GameManager.instance.players[i].GetComponent<PlayerInfo>());
        }
    }

    void FixedUpdate()
    {
        if (startLerp)
        {
            if (Vector3.Distance(transform.position, endPosition) <= 4)
            {
                GiveTokenToPlayer();
                Destroy(this.gameObject);
            }
            else
            {
                animAlpha += Time.fixedDeltaTime;
                transform.position = CalculatePosition(animAlpha);
                transform.localScale = CalculateScale(animAlpha);
            }
        }
        else
        {
            alpha += Time.fixedDeltaTime;
            transform.position = new Vector3(transform.position.x, AnimMath.Slide(transform.position.y, startPosition.y + 150, alpha), transform.position.z);
            animDelay -= Time.fixedDeltaTime;
            if (animDelay <= 0)
            {
                animDelay = 0;
                startLerp = true;
                startPosition = new Vector3(startPosition.x, startPosition.y + 150, startPosition.z);
            }
        }
    }

    private void GiveTokenToPlayer()
    {
        switch (playerWhoPressed)
        {
            case 1:
                playersInfo[0].tokens[tokenType - 1]++;
                UIPlayerInfo.instance.setTokenAmounts();
                break;
            case 2:
                playersInfo[1].tokens[tokenType - 1]++;
                UIPlayerInfo.instance.setTokenAmounts();
                break;
            case 3:
                playersInfo[2].tokens[tokenType - 1]++;
                UIPlayerInfo.instance.setTokenAmounts();
                break;
            case 4:
                playersInfo[3].tokens[tokenType - 1]++;
                UIPlayerInfo.instance.setTokenAmounts();
                break;
            case 5:
                playersInfo[4].tokens[tokenType - 1]++;
                UIPlayerInfo.instance.setTokenAmounts();
                break;
            case 6:
                playersInfo[5].tokens[tokenType - 1]++;
                UIPlayerInfo.instance.setTokenAmounts();
                break;
            default:
                break;
        }
    }

    private Vector3 CalculateScale(float alpha)
    {
        Vector3 scaleValue = AnimMath.Lerp(transform.localScale, new Vector3(3, 3, 1), alpha);
        return scaleValue;
    }

    private Vector3 CalculatePosition(float percent)
    {
        Vector3 positionC = AnimMath.Lerp(startPosition, handlePosition, percent);

        Vector3 positionD = AnimMath.Lerp(handlePosition, endPosition, percent);
        Vector3 positionE = AnimMath.Lerp(positionC, positionD, percent);

        return positionE;
    }
}
