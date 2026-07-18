using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    public TMP_InputField nickname;
    string defaultName;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (nickname != null)
        {
            if (PlayerPrefs.HasKey("PlayerName"))
            {
                defaultName = PlayerPrefs.GetString("PlayerName");
                nickname.text = defaultName;
            }
        }
    }
    public void OnConnectPressed()
    {
        Debug.Log("OnConnect!!");
        SetPlayerName(nickname.text);
        score = SaveManager.GetScore(defaultName);
        SaveManager.SetScore(defaultName, score);
        Debug.Log("NickName : " + defaultName);
        score = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("SavedScore : " + score);
        SceneManager.LoadScene("CharactorPickScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            value = "Ghost " + Random.Range(0, 101);
            //return;
        }
        PlayerPrefs.SetString("PlayerName",value);
    }
}
