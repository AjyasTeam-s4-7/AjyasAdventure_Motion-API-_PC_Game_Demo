using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ReStart=====>");
        PlayerPrefs.SetInt("gamestage", 0);
        PlayerPrefs.SetInt("Life", 3);
        PlayerPrefs.SetInt("ArmorUP", 0);
        PlayerPrefs.SetInt("DamageUP", 0);
        PlayerPrefs.SetInt("ItemBulletNum", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
