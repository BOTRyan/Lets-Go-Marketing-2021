using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    #region Singleton

    public static PlayerInfo instance;

    private void Awake()
    {
        instance = this;

        if (SceneManager.GetActiveScene().buildIndex != 2) DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public Sprite careerChoice;
    public Sprite avatar;
    public string playerName;
    public string email;
    public string fieldChoice;
    public int[] tokens;
    public int[] spaces = new int[] {0, 0, 0, 0, 0};
    public int place = 0;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        tokens = new int[] { 0, 0, 0, 0, 0, 0 };
    }

    // Update is called once per frame
    void Update()
    {

        //GetComponent<SpriteRenderer>().sprite = avatar;
        if (GameManager.instance.currPlayerTurn == GetComponent<PlayerMovement>().yourPlayerNum)
        {
            GetComponentInChildren<TMPro.TextMeshPro>().text = playerName;
        }
        else
        {
            GetComponentInChildren<TMPro.TextMeshPro>().text = "";
        }

        if (SceneManager.GetActiveScene().buildIndex != 4 && GetComponent<PlayerMovement>().yourPlayerNum > GameManager.instance.currPlayers)
        {
            gameObject.SetActive(false);
        }
    }
}
