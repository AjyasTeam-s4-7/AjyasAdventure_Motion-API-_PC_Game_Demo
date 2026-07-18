using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCon : MonoBehaviour
{
    public Text notice;
    // Start is called before the first frame update
    void Start()
    {
        notice.text = ">_<";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        int co = PlayerPrefs.GetInt("Coin", 0);
        int sco = PlayerPrefs.GetInt("SpCoin", 0);
        if (other.tag == "Apple")
        {
            if(co >= 100 && sco >= 5)
            {
                Debug.Log("사과 Buy!!");
                Debug.Log("재화 : 100냥 지불");
                Debug.Log("보석 : 5개 지불");
                PlayerPrefs.SetInt("ItemBulletNum", 1);
                notice.text = "사과 Buy!!";
                CoinCon.Instance.Get_Coin(-100);
                CoinCon.Instance.Get_SpecialCoin(-5);
                StartCoroutine(NoticeDelay());
            }
            if(co < 100 || sco < 5)
            {
                Debug.Log("사과");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
        if (other.tag == "Bamsongi")
        {
            if (co >= 200 && sco >= 16)
            {
                Debug.Log("밤송이 Buy!!");
                Debug.Log("재화 : 200냥 지불");
                Debug.Log("보석 : 16개 지불");
                PlayerPrefs.SetInt("ItemBulletNum", 2);
                notice.text = "밤송이 Buy!!";
                CoinCon.Instance.Get_Coin(-200);
                CoinCon.Instance.Get_SpecialCoin(-16);
                StartCoroutine(NoticeDelay());
            }
            if (co < 200 || sco < 16)
            {
                Debug.Log("밤송이");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
        if (other.tag == "Bomb")
        {
            if (co >= 500 && sco >= 47)
            {
                Debug.Log("폭탄 Buy!!");
                Debug.Log("재화 : 500냥 지불");
                Debug.Log("보석 : 47개 지불");
                PlayerPrefs.SetInt("ItemBulletNum", 3);
                notice.text = "폭탄 Buy!!";
                CoinCon.Instance.Get_Coin(-500);
                CoinCon.Instance.Get_SpecialCoin(-47);
                StartCoroutine(NoticeDelay());
            }
            if (co < 500 || sco < 47)
            {
                Debug.Log("폭탄");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
        if (other.tag == "Basket")
        {
            if (co >= 1000 && sco >= 112)
            {
                Debug.Log("바구니 Buy!!");
                Debug.Log("재화 : 1000냥 지불");
                Debug.Log("보석 : 112개 지불");
                PlayerPrefs.SetInt("ItemBulletNum", 4);
                notice.text = "바구니 Buy!!";
                CoinCon.Instance.Get_Coin(-1000);
                CoinCon.Instance.Get_SpecialCoin(-112);
                StartCoroutine(NoticeDelay());
            }
            if (co < 1000 || sco < 112)
            {
                Debug.Log("바구니");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
        if (other.tag == "Shell")
        {
            if (co >= 2000 && sco >= 301)
            {
                Debug.Log("황금총알 Buy!!");
                Debug.Log("재화 : 2000냥 지불");
                Debug.Log("보석 : 301개 지불");
                PlayerPrefs.SetInt("ItemBulletNum", 5);
                notice.text = "황금총알 Buy!!";
                CoinCon.Instance.Get_Coin(-2000);
                CoinCon.Instance.Get_SpecialCoin(-301);
                StartCoroutine(NoticeDelay());
            }
            if (co < 2000 || sco < 301)
            {
                Debug.Log("황금총알");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
        if (other.tag == "Grenade")
        {
            if (co >= 5000 && sco >= 800)
            {
                Debug.Log("수류탄 Buy!!");
                Debug.Log("재화 : 5000냥 지불");
                Debug.Log("보석 : 800개 지불");
                PlayerPrefs.SetInt("ItemBulletNum", 6);
                notice.text = "수류탄 Buy!!";
                CoinCon.Instance.Get_Coin(-5000);
                CoinCon.Instance.Get_SpecialCoin(-800);
                StartCoroutine(NoticeDelay());
            }
            if (co < 5000 || sco < 800)
            {
                Debug.Log("수류탄");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
        if (other.tag == "Miniun")
        {
            if (co >= 14000 && sco >= 2468)
            {
                Debug.Log("지원군 업글 Buy!!");
                Debug.Log("재화 : 14000냥 지불");
                Debug.Log("보석 : 2468개 지불");
                notice.text = "지원군 업글 Buy!!";
                CoinCon.Instance.Get_Coin(-14000);
                CoinCon.Instance.Get_SpecialCoin(-2468);
                StartCoroutine(NoticeDelay());
            }
            if (co < 14000 || sco < 2468)
            {
                Debug.Log("지원군 업글");
                Debug.Log("재화 및 보석 부족!!");
                Debug.Log("구매 불가능 ㅠㅠ");
                notice.text = "재화 및 보석 부족!!";
                StartCoroutine(NoticeDelay());
            }
            transform.position = new Vector3(-3, 0, -5);
        }
    }
    IEnumerator NoticeDelay()
    {
        yield return new WaitForSeconds(1.5f);
        notice.text = ">_<";
    }
}
