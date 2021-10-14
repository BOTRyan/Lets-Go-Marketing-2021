using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("sceneManager");
        if (objs.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public List<InputField> playerInputs = new List<InputField>();
    public List<Button> bulldogButtons = new List<Button>();
    public int currPlayers = 1;

    public Canvas screen;
    public GameObject background3, background4, background5;
    public GameObject bulldogMenu;
    public List<GameObject> players = new List<GameObject>();

    public InputField player1Name, player2Name, player3Name, player4Name, player5Name, player6Name;
    public Button bulldog1, bulldog2, bulldog3, bulldog4, bulldog5, bulldog6;
    public Button addPlayerButton, playButton;
    public Button remove2, remove3, remove4, remove5, remove6;
    public GameObject player1, player2, player3, player4, player5, player6;
    public GameObject player1Avatar, player2Avatar, player3Avatar, player4Avatar, player5Avatar, player6Avatar;
    public List<GameObject> avatarObjects = new List<GameObject>();
    private List<Button> removers = new List<Button>();

    public float gameTime = 0f;

    public bool spinModalOnce, didYouModalOnce, bossModalOnce, pointModalOnce;

    public int currPlayerTurn = 1;
    public int playersDone = 0;

    void Start()
    {
        bulldogButtons.Add(bulldog1);
        bulldogButtons.Add(bulldog2);
        bulldogButtons.Add(bulldog3);
        bulldogButtons.Add(bulldog4);
        bulldogButtons.Add(bulldog5);
        bulldogButtons.Add(bulldog6);
        playerInputs.Add(player1Name);
        playerInputs.Add(player2Name);
        playerInputs.Add(player3Name);
        playerInputs.Add(player4Name);
        playerInputs.Add(player5Name);
        playerInputs.Add(player6Name);
        background3.GetComponent<Image>().enabled = true;
        background4.GetComponent<Image>().enabled = false;
        background5.GetComponent<Image>().enabled = false;
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
        players.Add(player5);
        players.Add(player6);
        avatarObjects.Add(player1Avatar);
        avatarObjects.Add(player2Avatar);
        avatarObjects.Add(player3Avatar);
        avatarObjects.Add(player4Avatar);
        avatarObjects.Add(player5Avatar);
        avatarObjects.Add(player6Avatar);
        removers.Add(remove2);
        removers.Add(remove3);
        removers.Add(remove4);
        removers.Add(remove5);
        removers.Add(remove6);
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<PlayerInfo>().avatar = null;
        }

        for (int i = removers.Count - 1; i > 1; i--)
        {
            removers[i].GetComponent<Image>().enabled = false;
            removers[i].GetComponent<Button>().enabled = false;
            //removers[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
        }
        setBulldogVis(false);

        AudioManager.instance.loadPlayerData();
        AudioManager.instance.clearPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            for (int i = 0; i < avatarObjects.Count; i++)
            {
                avatarObjects[i].GetComponent<Image>().sprite = players[i].GetComponent<PlayerInfo>().avatar;
            }
            for (int i = 0; i < playerInputs.Count; i++)
            {
                players[i].GetComponent<PlayerInfo>().playerName = playerInputs[i].GetComponent<InputField>().textComponent.text;
            }
        }

        if (currPlayerTurn > currPlayers)
        {
            currPlayerTurn = 1;
            CameraControl.instance.targetPosY = CameraControl.instance.p1.camOffset;
            CameraControl.instance.jumpToOnce = false;
        }
    }

    void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "gameScene") gameTime += Time.fixedDeltaTime;
        else if (SceneManager.GetActiveScene().name == "startScene") gameTime = 0f;
    }

    public void openBulldogSelection(Button b)
    {
        bulldogMenu.GetComponent<AvatarMenu>().currButton = b;
        setBulldogVis(!bulldogMenu.activeSelf);
    }

    public void addNewPlayer()
    {
        if (currPlayers < 6)
        {
            players[currPlayers].SetActive(true);//Justin: added this to solve players getting destroyed
            currPlayers++;
            for (int i = 0; i < currPlayers; i++)
            {
                if (players[i].GetComponent<PlayerInfo>().avatar == null)
                {
                    bulldogButtons[i].GetComponent<Image>().enabled = true;
                    bulldogButtons[i].GetComponent<Button>().enabled = true;
                    bulldogButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = true;
                }

                playerInputs[i].GetComponent<Image>().enabled = true;
                playerInputs[i].GetComponent<InputField>().interactable = true;
                playerInputs[i].GetComponent<InputField>().enabled = true;
                playerInputs[i].GetComponent<InputField>().textComponent.enabled = true;
                if (i > 0)
                {
                    removers[i - 1].GetComponent<Image>().enabled = true;
                    removers[i - 1].GetComponent<Button>().enabled = true;
                    //removers[i - 1].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = true;
                }

            }
            updateButtonLocations();
        }
    }
    public void removePlayer(Button b)
    {
        if (currPlayers > 1)
        {
            int temp = 0;
            for (int i = 0; i < removers.Count; i++)
            {
                if (b == removers[i]) temp = i + 1;
            }
            shiftInfo(temp);
            currPlayers--;
            players[currPlayers].SetActive(false);//Justin: added this to solve players getting destroyed
            {
                for (int i = 5; i > currPlayers - 1; i--)
                {
                    bulldogButtons[i].GetComponent<Image>().enabled = false;
                    bulldogButtons[i].GetComponent<Button>().enabled = false;
                    bulldogButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
                    playerInputs[i].GetComponent<Image>().enabled = false;
                    playerInputs[i].GetComponent<InputField>().interactable = false;
                    playerInputs[i].GetComponent<InputField>().enabled = false;
                    playerInputs[i].GetComponent<InputField>().textComponent.enabled = false;
                    playerInputs[i].GetComponent<InputField>().textComponent.text = "Add Name";
                    playerInputs[i].GetComponent<InputField>().text = "Add Name";
                    players[i].GetComponent<PlayerInfo>().avatar = null;
                    avatarObjects[i].GetComponent<Image>().enabled = false;
                    if (i > 0)
                    {
                        removers[i - 1].GetComponent<Image>().enabled = false;
                        removers[i - 1].GetComponent<Button>().enabled = false;
                        //removers[i - 1].GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = false;
                    }
                    if (bulldogMenu.GetComponent<AvatarMenu>().currButton == bulldogButtons[i]) setBulldogVis(false);
                }
                SwitchScenes.instance.nameChangedNeeded = false;
                updateButtonLocations();
            }
        }
    }

    public void updateButtonLocations()
    {
        Vector3 temp = addPlayerButton.transform.position;
        switch (currPlayers)
        {
            case 1:
                currPlayers = 1;
                temp = new Vector3(addPlayerButton.transform.position.x, playerInputs[1].transform.position.y, playerInputs[1].transform.position.z);
                addPlayerButton.transform.position = temp;
                addPlayerButton.gameObject.SetActive(true);
                background3.GetComponent<Image>().enabled = true;
                break;
            case 2:
                currPlayers = 2;
                temp = new Vector3(addPlayerButton.transform.position.x, playerInputs[2].transform.position.y, playerInputs[2].transform.position.z);
                addPlayerButton.transform.position = temp;
                addPlayerButton.gameObject.SetActive(true);
                background3.GetComponent<Image>().enabled = true;
                break;
            case 3:
                temp = new Vector3(addPlayerButton.transform.position.x, playerInputs[3].transform.position.y, playerInputs[3].transform.position.z);
                addPlayerButton.transform.position = temp;
                addPlayerButton.gameObject.SetActive(true);
                background3.GetComponent<Image>().enabled = true;
                background4.GetComponent<Image>().enabled = false;
                background5.GetComponent<Image>().enabled = false;
                currPlayers = 3;
                break;
            case 4:
                temp = new Vector3(addPlayerButton.transform.position.x, playerInputs[4].transform.position.y, playerInputs[4].transform.position.z);
                addPlayerButton.transform.position = temp;
                addPlayerButton.gameObject.SetActive(true);
                background3.GetComponent<Image>().enabled = false;
                background4.GetComponent<Image>().enabled = true;
                background5.GetComponent<Image>().enabled = false;
                currPlayers = 4;
                break;
            case 5:
                temp = new Vector3(addPlayerButton.transform.position.x, playerInputs[5].transform.position.y, playerInputs[5].transform.position.z);
                addPlayerButton.transform.position = temp;
                addPlayerButton.gameObject.SetActive(true);
                background3.GetComponent<Image>().enabled = false;
                background4.GetComponent<Image>().enabled = false;
                background5.GetComponent<Image>().enabled = true;
                currPlayers = 5;
                break;
            case 6:
                addPlayerButton.gameObject.SetActive(false);
                background3.GetComponent<Image>().enabled = false;
                background4.GetComponent<Image>().enabled = false;
                background5.GetComponent<Image>().enabled = true;
                currPlayers = 6;
                break;
        }
    }

    public void setBulldogVis(bool vis)
    {
        if (vis)
        {
            bulldogMenu.SetActive(true);
        }
        else
        {
            bulldogMenu.SetActive(false);
        }
    }

    public void beginPlay()
    {
        SceneManager.LoadScene("gameScene");
    }

    private void shiftInfo(int pos)
    {
        for (int i = pos; i < currPlayers - 1; i++)
        {
            playerInputs[i].GetComponent<InputField>().textComponent.text = playerInputs[i + 1].GetComponent<InputField>().textComponent.text;
            playerInputs[i].GetComponent<InputField>().text = playerInputs[i + 1].GetComponent<InputField>().text;
            players[i].GetComponent<PlayerInfo>().name = players[i + 1].GetComponent<PlayerInfo>().name;
            players[i].GetComponent<PlayerInfo>().avatar = players[i + 1].GetComponent<PlayerInfo>().avatar;
        }
    }
}
