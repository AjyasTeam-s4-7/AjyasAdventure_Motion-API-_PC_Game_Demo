using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCon : MonoBehaviour
{
    public Text Coin;
    public Text SpecialCoin;
    private int Co = 0;
    private int SCo = 0;
    public static CoinCon Instance { get; private set; }
    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Co = PlayerPrefs.GetInt("Coin", 0);
        SCo = PlayerPrefs.GetInt("SpCoin",0);
        Debug.Log("Coin : " + Co);
        Debug.Log("SpCoin : " + SCo);
        Coin.text = Co.ToString();
        SpecialCoin.text = SCo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Coin", Co);
        PlayerPrefs.SetInt("SpCoin", SCo);
    }
    public void Get_Coin(int gco)
    {
        Co += gco;
        Coin.text = Co.ToString();
    }
    public void Get_SpecialCoin(int gsco)
    {
        SCo += gsco;
        SpecialCoin.text = SCo.ToString();
    }
}
