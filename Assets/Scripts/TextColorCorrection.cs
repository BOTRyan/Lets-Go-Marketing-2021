using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorCorrection : MonoBehaviour
{
    public InputField[] allInputs;
    private PlayerInfo tempInfo;
    private PlayerInfo tempInfoComp;

    public void changeTextColorBack(InputField input)
    {
        input.GetComponent<InputField>().textComponent.color = new Color(0.8156863f, 0.7686275f, 0.772549f);
        if (SwitchScenes.instance.nameChangedNeeded)
        {
            changeAllTextColorBack();
        }
    }

    public void changeButtonColorBack(Button button)
    {
        button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = new Color(0.8156863f, 0.7686275f, 0.772549f);
    }

    public void changeAllTextColorBack()
    {
        for (int i = 0; i < GameManager.instance.currPlayers; i++)
        {
            tempInfo = GameManager.instance.players[i].GetComponent<PlayerInfo>();

            for (int j = 0; j < GameManager.instance.players.Count; j++)
            {
                tempInfoComp = GameManager.instance.players[j].GetComponent<PlayerInfo>();

                if (tempInfo.playerName == tempInfoComp.playerName && tempInfo.GetComponent<PlayerMovement>().yourPlayerNum != tempInfoComp.GetComponent<PlayerMovement>().yourPlayerNum)
                {
                    SwitchScenes.instance.nameChangedNeeded = true;
                    GameManager.instance.playerInputs[i].textComponent.color = new Color(.75f, 0, 0);
                    GameManager.instance.playerInputs[j].textComponent.color = new Color(.75f, 0, 0);
                }
                else
                {
                    allInputs[j].GetComponent<InputField>().textComponent.color = new Color(0.8156863f, 0.7686275f, 0.772549f);
                    SwitchScenes.instance.nameChangedNeeded = false;
                }
            }
        }
    }
}
