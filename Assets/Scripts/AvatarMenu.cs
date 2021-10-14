using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarMenu : MonoBehaviour
{
    public Button currButton;
    private List<Button> dogChoice = new List<Button>();
    public Button red, blue, green, yellow, brown, indigo;

    private List<Sprite> avatars = new List<Sprite>();
    private bool[] isChosen = { false, false, false, false, false, false , false};

    // Start is called before the first frame update
    void Start()
    {
        dogChoice.Add(red);
        dogChoice.Add(blue);
        dogChoice.Add(green);
        dogChoice.Add(yellow);
        dogChoice.Add(brown);
        dogChoice.Add(indigo);
       
        for (int i = 0; i < dogChoice.Count; i++)
        {
            avatars.Add(dogChoice[i].GetComponent<Image>().sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y = currButton.transform.position.y;
        transform.position = temp;
        for (int i = 0; i < GameManager.instance.players.Count; i++)
        {
            if(avatars.Contains(GameManager.instance.players[i].GetComponent<PlayerInfo>().avatar)) 
            {
                isChosen[avatars.IndexOf(GameManager.instance.players[i].GetComponent<PlayerInfo>().avatar)] = true;
            } 
        }
        
        
    }

    public void setPlayerAvatar(Button b)
    {
        if(isChosen[dogChoice.IndexOf(b)] == false)
        {
            GameManager.instance.players[GameManager.instance.bulldogButtons.IndexOf(currButton)].GetComponent<PlayerInfo>().avatar = b.GetComponent<Image>().sprite;
            GameManager.instance.setBulldogVis(false);
            GameManager.instance.avatarObjects[GameManager.instance.bulldogButtons.IndexOf(currButton)].GetComponent<Image>().enabled = true;
            GameManager.instance.bulldogButtons[GameManager.instance.bulldogButtons.IndexOf(currButton)].GetComponent<Image>().enabled = false;
        }
        for (int i = 0; i < isChosen.Length; i++)
        {
            isChosen[i] = false;
        }
    }
    
}
