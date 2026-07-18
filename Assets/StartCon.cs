using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start=====>");
        PlayerPrefs.SetInt("gamestage", 0);
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("SpCoin", 0);
        PlayerPrefs.SetInt("Life", 3);
        PlayerPrefs.SetInt("ArmorUP", 0);
        PlayerPrefs.SetInt("DamageUP", 0);
        PlayerPrefs.SetInt("ItemBulletNum", 0);
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
