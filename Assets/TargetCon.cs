using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCon : MonoBehaviour
{
    public HpCon hpc;
    public GameObject Gunon1;
    public GameObject Gunon2;
    public GameObject Gunon3;
    public GameObject Knifeon;
    public GameObject Gunon4;
    private int stage;
    private float dt = 0;
    private int toggle = 0;
    private float move = 0;
    private float timeTic = 0;
    // Start is called before the first frame update
    void Start()
    {
        stage = PlayerPrefs.GetInt("gamestage", 0);
        switch (stage)
        {
            case 0:
                move = 0.065f;
                //move = 0.13f;
                break;
            case 1:
                move = -0.065f;
                //move = -0.13f;
                break;
            case 2:
                move = -0.065f;
                //move = -0.13f;
                break;
            default:
                move = 0.065f;
                //move = 0.13f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        stage = PlayerPrefs.GetInt("gamestage", 0);
        timeTic += Time.deltaTime;
        if (timeTic > 1)
        {
            timeTic = 0;
            switch (stage)
            {
                case 0:
                    Gunon3.GetComponent<EShootCon>().eshoot1();
                    Knifeon.GetComponent<EShootCon>().eshoot1();
                    break;
                case 1:
                    Gunon4.GetComponent<EShootCon>().eshoot2();
                    break;
                case 2:
                    Gunon1.GetComponent<EShootCon>().eshoot();
                    Gunon2.GetComponent<EShootCon>().eshoot();
                    Gunon4.GetComponent<EShootCon>().eshoot2();
                    break;
            }
        }
        if (dt > 1)
        {
            dt = 0;
        }
        toggle += 1;
        switch (stage)
        {
            case 0:
            case 1:
            case 2:
                if (toggle < 400)
                {
                    transform.Translate(new Vector3(move, 0, 0));
                    //tg.value += move;
                }
                else if (toggle < 800)
                {
                    transform.Translate(new Vector3(-move, 0, 0));
                    //tg.value -= move;
                }
                else
                {
                    toggle = 1;
                }
                break;
            
        }
        if (hpc.Get_ehp() <= 0)
        {
            gameObject.SetActive(false);
            //tgsld.SetActive(false);
        }
    }
}
