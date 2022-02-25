using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClientTCP : MonoBehaviour
{
    public static ClientTCP singleton;
    private TcpClient socket = new TcpClient();
    private Buffer buffer = Buffer.Alloc(0);

    private string serverHost = "127.0.0.1";
    private int port = 1111;

    public TMP_InputField roomInput;
    public GameObject roomPanel, joinPanel, hostPanel, playerPanel, errorPanel;
    public bool isHost = false;
    public string connectedRoom, attemptedRoom;

    public TMP_Text roomName, responseFeedback, errorNum;
    public TMP_Text playerNum;

    public TMP_InputField usernameInputField;

    public Sprite[] avatarImages = new Sprite[6];
    public GameObject[] avatarPositions = new GameObject[6];
    public GameObject[] avatarButtons = new GameObject[6];
    public GameObject avatarBase;
    public GameObject myAvatar;
    private List<GameObject> currAvatars = new List<GameObject>();

    private int currAvatarSelection = 0;
    private string usernameInput;

    // i need by next week to also get stuff on the player page, 6 buttons and an input box

    private void Awake()
    {
        if(singleton)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private async void StartReceivingPackets()
    {
        int maxPacketSize = 4096;

        while(socket.Connected)
        {
            byte[] data = new byte[maxPacketSize];
            try
            {
                int bytesRead = await socket.GetStream().ReadAsync(data, 0, maxPacketSize);
                buffer.Concat(data, bytesRead);
                ProcessPackets();
            }
            catch (Exception e)
            {
                print("ERROR HANDLING DATA: " + e);
            }
        }
    }

    public async void SendPacketToServer(Buffer packet)
    {
        if (!socket.Connected) return;
        print(packet);

        await socket.GetStream().WriteAsync(packet.Bytes, 0, packet.Bytes.Length);
    }

    private void ProcessPackets()
    {
        if (buffer.Length < 4) return;

        string id = buffer.ReadString(0, 4);

        switch(id)
        {
            case "JOIN":
                if (buffer.Length < 5) return;

                var response = buffer.ReadUInt8(4);

                if (response == 1)
                {
                    isHost = true;
                    connectedRoom = buffer.ReadString(5, 4);
                    roomName.text = "Room Code: " + connectedRoom;
                    SwapScreens("room");
                }
                else if (response == 2)
                {
                    connectedRoom = attemptedRoom;
                    SwapScreens("join");
                }
                else if (response == 3)
                {
                    ServerError("This room is full", response);
                }
                else if (response == 4)
                {
                    ServerError("Unable to find room", response);
                }
                else if (response == 5)
                {
                    ServerError("This game has already started", response);
                }
                else
                {
                    ServerError("Unknown Error", response);
                }
                

                break;
            case "LOBY":
                var numberOfPlayers = buffer.ReadUInt8(4);

                if (isHost)
                {
                    playerNum.text = "Players in room: " + numberOfPlayers.ToString();
                    foreach(GameObject a in currAvatars)
                    {
                        Destroy(a);
                    }
                    currAvatars.Clear();
                    for(int i = 0; i < numberOfPlayers; i++)
                    {
                        Canvas c = FindObjectOfType<Canvas>();
                        GameObject newAvatar = Instantiate(avatarBase, c.transform);
                        newAvatar.GetComponentInChildren<TMP_Text>().text = "Waiting...";
                        newAvatar.transform.position = avatarPositions[i].transform.position;
                        
                        currAvatars.Add(newAvatar);
                    }
                }
                break;
            case "REDY":
                if (buffer.Length < 6) return;

                int userResponse = buffer.ReadUInt8(4);
                if(userResponse > 1)
                {
                    // Send username error message
                }
                int avatarResponse = buffer.ReadUInt8(5);
                if(avatarResponse == 0)
                {
                    currAvatarSelection = 0;
                }

                if(userResponse == 1 && avatarResponse == 1)
                {
                    UpdatePersonalAvatar(usernameInput, currAvatarSelection);
                }

                break;
            case "HUPD":
                
                if (!isHost) return;
                if (buffer.Length < 7) return;
                int lengthOfUsername = buffer.ReadUInt8(6);
                
                if (buffer.Length < 7 + lengthOfUsername) return;

                int slot = buffer.ReadUInt8(4);
                int avatar = buffer.ReadUInt8(5);
                string username = buffer.ReadString(7, lengthOfUsername);
                

                currAvatars[slot-1].GetComponentInChildren<Image>().sprite = avatarImages[avatar - 1];
                currAvatars[slot-1].GetComponentInChildren<TMP_Text>().text = username;


                break;
            case "PUPD":
                if (buffer.Length < 10) return;
                int offset = 4;
                for(int i = 0; i < 6; i++)
                {
                    int avatarCheck = buffer.ReadUInt8(offset + i);
                    if (avatarCheck == 0) avatarButtons[i].SetActive(false);
                    if (avatarCheck == 1) avatarButtons[i].SetActive(true);
                }
                break;
            case "GAME":
                break;
            case "CARD":
                break;
            case "FINL":
                break;
            case "RSET":
                break;

            default:
                print("Unknown identifier: " + id);
                break;
        }
        buffer.Clear();
    }

    private void UpdatePersonalAvatar(string name, int avatarNum)
    {
        myAvatar.GetComponentInChildren<Image>().sprite = avatarImages[avatarNum];
        myAvatar.GetComponentInChildren<TMP_Text>().text = name;

        myAvatar.SetActive(true);
    }

    public async void TryConnect(string host, int port)
    {
        if (socket.Connected) return;
        try
        {
            await socket.ConnectAsync(host, port);

            StartReceivingPackets();
        }
        catch (Exception e)
        {
            print("ERROR: " + e);
        }
    }

    public void OnButtonJoin()
    {
        SwapScreens("join");
    }

    public void OnButtonBack()
    {
        SwapScreens("back");
    }

    public void OnConnectRoom()
    {
        TryConnect(serverHost, port);
        attemptedRoom = roomInput.text;
        
        Buffer packet = PacketBuilder.Join(attemptedRoom);
        SendPacketToServer(packet);
    }

    public void OnChooseAvatar(int selection)
    {
        currAvatarSelection = selection - 1;
    }
    public void OnUsernameEndEdit()
    {
        usernameInput = usernameInputField.text;
    }
    public void OnSubmitPlayer()
    {
        Buffer packet = PacketBuilder.Ready(usernameInput, currAvatarSelection + 1);
        SendPacketToServer(packet);
    }

    public void OnButtonHost()
    {
        TryConnect(serverHost, port);
        Buffer packet = PacketBuilder.Join();
        SendPacketToServer(packet);
    }

    private void ServerError(string feedbackTxt, int errNum)
    {
        errorPanel.SetActive(true);
        responseFeedback.text = feedbackTxt;
        errorNum.text = "Error Number: " + errNum;
    }

    private void SwapScreens(string newScreen)
    {
        if(newScreen == "join")
        {
            joinPanel.SetActive(false);
            playerPanel.SetActive(true);
        }
        else if(newScreen == "room")
        {
            joinPanel.SetActive(false);
            hostPanel.SetActive(true);
        }
    }
}
