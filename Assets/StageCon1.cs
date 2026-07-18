using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCon1 : MonoBehaviour
{
    public Text StageText;
    private int Cur_Stage1;
    // Start is called before the first frame update
    void Start()
    {
        Cur_Stage1 = PlayerPrefs.GetInt("gamestage", 0);
        StageText.text = "Stage " + (Cur_Stage1 + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
