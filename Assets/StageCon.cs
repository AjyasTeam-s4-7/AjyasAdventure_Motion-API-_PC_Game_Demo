using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCon : MonoBehaviour
{
    private int Cur_Stage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Goto_Next_Stage()
    {
        Cur_Stage = PlayerPrefs.GetInt("gamestage", 0);
        //Debug.Log("Stage : " + (Cur_Stage + 1));
        switch (Cur_Stage)
        {
            case 0:
                SceneManager.LoadScene("HOBattleScene1");
                break;
            case 1:
                SceneManager.LoadScene("HOBattleScene2");
                break;
            case 2:
                SceneManager.LoadScene("HOBattleScene3");
                break;
            default:
                SceneManager.LoadScene("HOBattleScene1");
                break;
        }
    }
}
