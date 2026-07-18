using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingCon : MonoBehaviour
{
    public Text[] score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    private void OnEnable()
    {
        Debug.Log("RankingCon");
        List<UserScore> top = SaveManager.GetTopScores(10);
        int i = 0;
        foreach (UserScore x in top)
        {
            Debug.Log(x.id + " : " + x.score);
            score[i++].text = i + "µî   " + x.id + "   " + x.score + "Á¡";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
