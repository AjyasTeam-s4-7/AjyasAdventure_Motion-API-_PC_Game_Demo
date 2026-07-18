using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    private int score;
    private string defaultName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Go_Login()
    {
        SceneManager.LoadScene("LoginScene");
    }
    public void Go_Login_SaveScore()
    {
        defaultName = PlayerPrefs.GetString("PlayerName");
        score = PlayerPrefs.GetInt("Score", 0);
        SaveManager.SetScore(defaultName, score);
        SceneManager.LoadScene("LoginScene");
    }
    public void Go_Start()
    {
        SceneManager.LoadScene("CharactorPickScene");
    }
    /*public void Robot1()
    {
        Debug.Log("·Îº¿1.76È£");
        PlayerPrefs.SetInt("Robot",1);
        SceneManager.LoadScene("MainScene");
    }
    public void Robot2()
    {
        Debug.Log("·Îº¿2.84È£");
        PlayerPrefs.SetInt("Robot", 2);
        SceneManager.LoadScene("MainScene");
    }*/
    public void Robot3()
    {
        Debug.Log("·Îº¿ 0396.301È£");
        PlayerPrefs.SetInt("Robot", 3);
        SceneManager.LoadScene("MainScene");
    }
}
