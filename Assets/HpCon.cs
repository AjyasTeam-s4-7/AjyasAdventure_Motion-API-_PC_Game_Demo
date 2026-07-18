using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpCon : MonoBehaviour
{
    public Text MyHP;
    public Text EnermyHP;
    public Text Life;
    public GameObject CardMenu;
    public GameObject CardA;
    public GameObject CardB;
    public GameObject CardC;
    //public GameObject robot1;
    //public GameObject robot2;
    public GameObject robot3;
    private int mhp = 0;
    private int ehp = 0;
    private int lif = 0;
    private int Cur_Stage = 0;
    private int pick;
    private int ArmorUP = 0;
    private int DamageUP = 0;
    public Slider mtg;
    public Slider etg;
    public GameObject mtgsld;
    public GameObject etgsld;
    private int ran;
    private int scr;
    private int rs;
    public static HpCon Instance { get; private set; }
    float time = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cur_Stage = PlayerPrefs.GetInt("gamestage", 0);
        lif = PlayerPrefs.GetInt("Life", 0);
        ArmorUP = PlayerPrefs.GetInt("ArmorUP", 0);
        DamageUP = PlayerPrefs.GetInt("DamageUP", 0);
        Debug.Log("Life : " + lif);
        Debug.Log("ArmorUP : " + ArmorUP);
        Debug.Log("DamageUP : " + DamageUP);
        Life.text = lif.ToString();
        switch (Cur_Stage)
        {
            case 0:
                Debug.Log("Stage : " + (Cur_Stage + 1));
                mhp = 50;
                ehp = 200;
                MyHP.text = mhp + "/50";
                EnermyHP.text = ehp + "/200";
                break;
            case 1:
                Debug.Log("Stage : " + (Cur_Stage + 1));
                mhp = 100;
                ehp = 1996;
                MyHP.text = mhp + "/100";
                EnermyHP.text = ehp + "/1996";
                break;
            case 2:
                Debug.Log("Stage : " + (Cur_Stage + 1));
                mhp = 200;
                ehp = 2003;
                MyHP.text = mhp + "/200";
                EnermyHP.text = ehp + "/2003";
                break;
            default:
                Debug.Log("Stage : " + (Cur_Stage + 1));
                mhp = 50;
                ehp = 200;
                MyHP.text = mhp + "/50";
                EnermyHP.text = ehp + "/200";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Life", lif);
        PlayerPrefs.SetInt("ArmorUP", ArmorUP);
        PlayerPrefs.SetInt("DamageUP", DamageUP);
        time -= Time.deltaTime;
    }
    public void MyHP_cur(int val)
    {
        mhp -= val;
        Debug.Log("My HP : " + mhp);
        switch (Cur_Stage)
        {
            case 0:
                MyHP.text = mhp + "/50";
                mtg.value -= val;
                break;
            case 1:
                MyHP.text = mhp + "/100";
                mtg.value -= val;
                break;
            case 2:
                MyHP.text = mhp + "/200";
                mtg.value -= val;
                break;
            default:
                MyHP.text = mhp + "/50";
                mtg.value -= val;
                break;
        }
        if (mhp <= 0)
        {
            Debug.Log("LOSE");
            switch (Cur_Stage)
            {
                case 0:
                    MyHP.text = 0 + "/50";
                    mtg.value = 0;
                    break;
                case 1:
                    MyHP.text = 0 + "/100";
                    mtg.value = 0;
                    break;
                case 2:
                    MyHP.text = 0 + "/200";
                    mtg.value = 0;
                    break;
                default:
                    MyHP.text = 0 + "/50";
                    mtg.value = 0;
                    break;
            }
            lif--;
            PlayerPrefs.SetInt("Life", lif);
            Life.text = lif.ToString();
            mtgsld.SetActive(false);
            StartCoroutine(Delay1());
        }
        if (lif <= 0)
        {
            StartCoroutine(Delay2());
        }
    }
    public void EnermyHP_cur(int val1)
    {
        ehp -= val1;
        Debug.Log("적 HP : " + ehp);
        switch (Cur_Stage)
        {
            case 0:
                EnermyHP.text = ehp + "/200";
                etg.value -= val1;
                break;
            case 1:
                EnermyHP.text = ehp + "/1996";
                etg.value -= val1;
                break;
            case 2:
                EnermyHP.text = ehp + "/2003";
                etg.value -= val1;
                break;
            default:
                EnermyHP.text = ehp + "/200";
                etg.value -= val1;
                break;
        }
        if (ehp <= 0)
        {
            switch (Cur_Stage)
            {
                case 0:
                    EnermyHP.text = 0 + "/200";
                    etg.value = 0;
                    break;
                case 1:
                    EnermyHP.text = 0 + "/1996";
                    etg.value = 0;
                    break;
                case 2:
                    EnermyHP.text = 0 + "/2003";
                    etg.value = 0;
                    break;
                default:
                    EnermyHP.text = 0 + "/200";
                    etg.value = 0;
                    break;
            }
            etgsld.SetActive(false);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        Cur_Stage = PlayerPrefs.GetInt("gamestage", 0);
        int coin1 = PlayerPrefs.GetInt("Coin", 0);
        int spcoin1 = PlayerPrefs.GetInt("SpCoin", 0);
        Cur_Stage++;
        lif++;
        Debug.Log("WIN");
        if (Cur_Stage >= 0 && Cur_Stage <= 2)
        {
            Debug.Log("Coin : " + coin1);
            Debug.Log("SpCoin : " + spcoin1);
            Debug.Log("Clear ==> " + Cur_Stage);
            PlayerPrefs.SetInt("gamestage", Cur_Stage);
            CardMenu.SetActive(true);
        }
        if (Cur_Stage >= 3)
        {
            Debug.Log("Coin : " + coin1);
            Debug.Log("SpCoin : " + spcoin1);
            Debug.Log("Clear ==> " + Cur_Stage);
            PlayerPrefs.SetInt("gamestage", 0);
            SceneManager.LoadScene("ClearScene");
        }
    }
    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(2f);
        pick = PlayerPrefs.GetInt("Robot", 0);
        Cur_Stage = PlayerPrefs.GetInt("gamestage", 0);
        Debug.Log("Pick : " + pick);
        Debug.Log("Stage : " + (Cur_Stage + 1));
        mtgsld.SetActive(true);
        switch (Cur_Stage)
        {
            case 0:
                mhp = 50;
                MyHP.text = mhp + "/50";
                mtg.value = mhp;
                break;
            case 1:
                mhp = 100;
                mtg.value = 50;
                MyHP.text = mhp + "/100";
                mtg.value = mhp;
                break;
            case 2:
                mhp = 200;
                MyHP.text = mhp + "/200";
                mtg.value = mhp;
                break;
            default:
                mhp = 50;
                MyHP.text = mhp + "/50";
                mtg.value = mhp;
                break;
        }
        /*if (pick == 1)
        {
            robot1.SetActive(true);
        }
        if (pick == 2)
        {
            robot2.SetActive(true);
        }*/
        if (pick == 3)
        {
            robot3.SetActive(true);
        }
    }
    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(1.5f);
        scr = PlayerPrefs.GetInt("Score", 0);
        ran = Random.Range(1, 101);  //1~100
        Debug.Log(scr);
        Debug.Log(ran);
        Debug.Log(-scr / ran);
        rs = scr / ran;
        ScoreCon.Instance.Get_Score(-rs);
        SceneManager.LoadScene("GameOverScene");
    }
    public int Get_mhp()
    {
        return mhp;
    }
    public int Get_ehp()
    {
        return ehp;
    }
    public void Click_CardA()
    {
        CardMenu.SetActive(false);
        int aup;
        switch (Cur_Stage)
        {
            case 1:
                aup = Random.Range(1, 5); // 방어력 추가 1~4
                ArmorUP += aup;
                break;
            case 2:
                aup = Random.Range(5, 10); // 방어력 추가 5~9
                ArmorUP += aup;
                break;
        }
        CardA.SetActive(true);
    }
    public void Click_CardB()
    {
        CardMenu.SetActive(false);
        int dup;
        switch (Cur_Stage)
        {
            case 1:
                dup = Random.Range(1, 3); // 공격력 추가 1~2
                DamageUP += dup;
                break;
            case 2:
                dup = Random.Range(3, 5); // 공격력 추가 3~4
                DamageUP += dup;
                break;
        }
        CardB.SetActive(true);
    }
    public void Click_CardC()
    {
        CardMenu.SetActive(false);
        CardC.SetActive(true);
    }
    public void Get_ArmorUP(int val1)
    {

    }
    public void Get_DamageUP(int val2)
    {

    }
}
