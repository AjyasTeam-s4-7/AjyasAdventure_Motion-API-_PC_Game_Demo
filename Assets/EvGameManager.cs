using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvGameManager : MonoBehaviour
{
    //public GameObject gamemenu;
    public Text ui_nujokc;
    public Text ui_nujoksc;
    public Text ui_Coin;
    public Text ui_SpCoin;
    public Text ui_timer;
    int coin;
    int spcoin;
    private int nujokc;
    private int nujoksc;
    public float max_timer;
    float timer;
    public void update_coin(int val)
    {
        coin += val;
        ui_Coin.text = "얻은 재화 : " + coin.ToString();
        PlayerPrefs.SetInt("Coin", nujokc + coin);
        ui_nujokc.text = (nujokc + coin).ToString();
    }
    public void update_spcoin(int val1)
    {
        spcoin += val1;
        ui_SpCoin.text = "얻은 보석 : " + spcoin.ToString();
        PlayerPrefs.SetInt("SpCoin", nujoksc + spcoin);
        ui_nujoksc.text = (nujoksc + spcoin).ToString();
    }
    public void start_game()
    {
        //gamemenu.SetActive(false);
        //Time.timeScale = 1;
        timer = max_timer;
        nujokc = PlayerPrefs.GetInt("Coin", 0);
        nujoksc = PlayerPrefs.GetInt("SpCoin", 0);
        ui_nujokc.text = nujokc.ToString();
        ui_nujoksc.text = nujoksc.ToString();
        coin = 0;
        spcoin = 0;
        ui_Coin.text = "얻은 재화 : " + coin;
        ui_SpCoin.text = "얻은 보석 : " + spcoin;
    }
    /*public void end_game()
    {
        SceneManager.LoadScene("MainScene");
    }*/
    // Start is called before the first frame update
    void Start()
    {
        start_game();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            StartCoroutine(Delay());
            //gamemenu.SetActive(true);
            //Time.timeScale = 0;
        }
        ui_timer.text = "Timer : " + timer.ToString("F1");
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainScene");
    }
}
