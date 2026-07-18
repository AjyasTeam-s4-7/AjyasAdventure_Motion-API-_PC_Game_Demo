using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject itembulletUpgrade;
    public GameObject resipi;
    public GameObject ranking;
    private int score;
    private string defaultName;
    //public GameObject itembulletcnt;
    // Start is called before the first frame update
    void Start()
    {
        //menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            resipi.SetActive(true);
        }
        if (!Input.GetKey(KeyCode.Tab))
        {
            resipi.SetActive(false);
        }
        if (Input.GetKey(KeyCode.R))
        {
            ranking.SetActive(true);
        }
        if (!Input.GetKey(KeyCode.R))
        {
            ranking.SetActive(false);
        }
    }
    public void Game_Exit()
    {
        Debug.Log("꼬시다 맛동산~~");
        Application.Quit();
    }
    public void Game_Exit_SaveScore()
    {
        Debug.Log("모토 호러야호러~~");
        defaultName = PlayerPrefs.GetString("PlayerName");
        score = PlayerPrefs.GetInt("Score", 0);
        SaveManager.SetScore(defaultName, score);
        Application.Quit();
    }
    /*public void GO_Pick()
    {
        SceneManager.LoadScene("CharactorPickScene");
    }*/
    public void GO_MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Go_Menu()
    {
        menu.SetActive(true);
    }
    public void Go_Game()
    {
        menu.SetActive(false);
    }
    public void Go_ItemBulletcnt()
    {
        itembulletUpgrade.SetActive(true);
    }
    public void Go_BasicShell()
    {
        itembulletUpgrade.SetActive(false);
    }
}
