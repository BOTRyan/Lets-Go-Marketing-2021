using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientTCP : MonoBehaviour
{
    public static ClientTCP singleton;
    private TcpClient socket = new TcpClient();
    private Buffer buffer = Buffer.Alloc(0);

    private string serverHost = "127.0.0.1";
    private int port = 1111;

    public TMP_InputField roomInput;
    public GameObject roomPanel, joinPanel;
    public bool isHost = false;
    public string connectedRoom, attemptedRoom;

    public TMP_Text roomName;

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

                if(response == 1)
                {
                    isHost = true;
                    connectedRoom = buffer.ReadString(5, 4);
                    roomName.text = "ROOM: " + connectedRoom;
                    SwapScreens("room");
                    //SceneManager.LoadScene("mainMenu");
                }
                if(response == 2)
                {
                    connectedRoom = attemptedRoom;
                    SwapScreens("room");
                    //SceneManager.LoadScene("lobbyScene");
                }
                else
                {
                    // Send error message based on denied response
                }

                break;
            case "REDY":
                if (buffer.Length < 11) return;

                var userResponse = buffer.ReadUInt8(4);
                if(userResponse > 1)
                {
                    // Send username error message
                }
                int offset = 5;
                for(int i = 0; i < 6; i++)
                {
                    int thing = buffer.ReadUInt8(offset + i);
                    // Update avatars in lobby scene based on taken avatars
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
                buffer.Clear();
                break;
        }
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

    public void OnButtonHost()
    {
        TryConnect(serverHost, port);
        Buffer packet = PacketBuilder.Join();
        SendPacketToServer(packet);
    }

    private void SwapScreens(string newScreen)
    {
        if(newScreen == "join")
        {
            joinPanel.SetActive(true);
            roomPanel.SetActive(false);
        }
        else if(newScreen == "room")
        {
            joinPanel.SetActive(false);
            roomPanel.SetActive(true);
        }
    }
}
