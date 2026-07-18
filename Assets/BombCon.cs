using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCon : MonoBehaviour
{
    Rigidbody rb;
    public ParticleSystem pung;
    private bool touch = false;
    private int cn;
    private int scn;
    private int scr;
    private int ItemDamage = 0;
    private int DamageUP3 = 0;
    private int mujuk = 0;
    public void Shoot(Vector3 dir)
    {
        //Debug.Log(dir);
        rb.AddForce(dir, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.z > 5)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
        if (rb.position.y < 0.2f)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        mujuk = Random.Range(0, 2);
        ItemDamage = 37 * mujuk;
        if (collision.collider.tag == "Target")
        {
            if (touch == false)
            {
                touch = true;
                rb.isKinematic = true;
                pung.Play();
                cn = Random.Range(1, 11);   // 1~10
                scn = Random.Range(0, 2);   // 0~1
                scr = Random.Range(1, 3);   // 1~2
                Debug.Log(ItemDamage);
                Debug.Log(DamageUP3);
                Debug.Log("재화 : " + cn);
                Debug.Log("미네랄 : " + scn);
                Debug.Log("점수 : " + scr);
                HpCon.Instance.EnermyHP_cur(ItemDamage + DamageUP3);
                CoinCon.Instance.Get_Coin(cn);
                CoinCon.Instance.Get_SpecialCoin(scn);
                ScoreCon.Instance.Get_Score(scr);
                Destroy(gameObject, 1);
            }
        }
        if (collision.collider.tag == "Target1")
        {
            if (touch == false)
            {
                touch = true;
                rb.isKinematic = true;
                pung.Play();
                cn = Random.Range(11, 21);  // 11~20
                scn = Random.Range(2, 4);   // 2~3
                scr = Random.Range(3, 6);   // 3~5
                Debug.Log(ItemDamage);
                Debug.Log(DamageUP3);
                Debug.Log("재화 : " + cn);
                Debug.Log("미네랄 : " + scn);
                Debug.Log("점수 : " + scr);
                HpCon.Instance.EnermyHP_cur(ItemDamage + DamageUP3);
                CoinCon.Instance.Get_Coin(cn);
                CoinCon.Instance.Get_SpecialCoin(scn);
                ScoreCon.Instance.Get_Score(scr);
                Destroy(gameObject, 1);
            }
        }
        if (collision.collider.tag == "Target2")
        {
            if (touch == false)
            {
                touch = true;
                rb.isKinematic = true;
                pung.Play();
                cn = Random.Range(21, 51);  // 21~50
                scn = Random.Range(4, 8);   // 4~7
                scr = Random.Range(6, 10);   // 6~9
                Debug.Log(ItemDamage);
                Debug.Log(DamageUP3);
                Debug.Log("재화 : " + cn);
                Debug.Log("미네랄 : " + scn);
                Debug.Log("점수 : " + scr);
                HpCon.Instance.EnermyHP_cur(ItemDamage + DamageUP3);
                CoinCon.Instance.Get_Coin(cn);
                CoinCon.Instance.Get_SpecialCoin(scn);
                ScoreCon.Instance.Get_Score(scr);
                Destroy(gameObject, 1);
            }
        }
    }
}
