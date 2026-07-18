using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletCon : MonoBehaviour
{
    Rigidbody rb;
    public ParticleSystem pung;
    private bool touch = false;
    private int ArmorUP;
    private int scr;
    public void EShoot(Vector3 edir)
    {
        rb.AddForce(edir, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.z < -30)
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
        ArmorUP = PlayerPrefs.GetInt("ArmorUP", 0);
        if (collision.collider.tag == "Player")
        {
            if (touch == false)
            {
                touch = true;
                rb.isKinematic = true;
                pung.Play();
                scr = Random.Range(1, 6);   // 1~5
                Debug.Log(9);
                Debug.Log("점수 : " + -scr);
                HpCon.Instance.MyHP_cur(9);
                ScoreCon.Instance.Get_Score(-scr);
                Destroy(gameObject, 0.5f);
            }
        }
        if (collision.collider.tag == "Player1")
        {
            if (touch == false)
            {
                touch = true;
                rb.isKinematic = true;
                pung.Play();
                scr = Random.Range(6, 42);   // 6~41
                Debug.Log(45);
                Debug.Log("점수 : " + -scr);
                Debug.Log(ArmorUP);
                HpCon.Instance.MyHP_cur(45 - ArmorUP);
                ScoreCon.Instance.Get_Score(-scr);
                Destroy(gameObject, 0.5f);
            }
        }
        if (collision.collider.tag == "Player2")
        {
            if (touch == false)
            {
                touch = true;
                rb.isKinematic = true;
                pung.Play();
                scr = Random.Range(43, 204);   // 43~203
                Debug.Log(176);
                Debug.Log("점수 : " + -scr);
                Debug.Log(ArmorUP);
                HpCon.Instance.MyHP_cur(176 - ArmorUP);
                ScoreCon.Instance.Get_Score(-scr);
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
