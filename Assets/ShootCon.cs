using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootCon : MonoBehaviour
{
    public GameObject shell;
    public GameObject apple;
    public GameObject bamsongi;
    public GameObject bomb;
    public GameObject basket;
    public GameObject goldShell;
    public GameObject grenada;
    GameObject item;
    GameObject item1;
    GameObject item2;
    GameObject item3;
    GameObject item4;
    GameObject item5;
    GameObject item6;
    public Text itemcnt;
    private int Count;
    private int ItemNum;
    // Start is called before the first frame update
    void Start()
    {
        ItemNum = PlayerPrefs.GetInt("ItemBulletNum", 0);
        if (ItemNum == 0)
        {
            Count = 25;
            itemcnt.text = Count + "/25";
        }
        if (ItemNum == 1)
        {
            Count = 10;
            itemcnt.text = Count + "/10";
        }
        if (ItemNum == 2)
        {
            Count = 8;
            itemcnt.text = Count + "/8";
        }
        if (ItemNum == 3)
        {
            Count = 6;
            itemcnt.text = Count + "/6";
        }
        if (ItemNum == 4)
        {
            Count = 5;
            itemcnt.text = Count + "/5";
        }
        if (ItemNum == 5)
        {
            Count = 4;
            itemcnt.text = Count + "/4";
        }
        if (ItemNum == 6)
        {
            Count = 3;
            itemcnt.text = Count + "/3";
        }
    }

    public void BulletShell()
    {
        ItemNum = PlayerPrefs.GetInt("ItemBulletNum", 0);
        if (ItemNum == 0)
        {
            item = Instantiate(shell, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 25;
                    itemcnt.text = Count + "/25";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/25";
            StartCoroutine(ShootDelay(item, "basic"));
        }
        if (ItemNum == 1)
        {
            item1 = Instantiate(apple, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 10;
                    itemcnt.text = Count + "/10";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/10";
            StartCoroutine(ShootDelay(item1, "apple"));
        }
        if (ItemNum == 2)
        {
            item2 = Instantiate(bamsongi, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 8;
                    itemcnt.text = Count + "/8";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/8";
            StartCoroutine(ShootDelay(item2, "bamsongi"));
        }
        if (ItemNum == 3)
        {
            item3 = Instantiate(bomb, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 6;
                    itemcnt.text = Count + "/6";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/6";
            StartCoroutine(ShootDelay(item3, "bomb"));
        }
        if (ItemNum == 4)
        {
            item4 = Instantiate(basket, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 5;
                    itemcnt.text = Count + "/5";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/5";
            StartCoroutine(ShootDelay(item4, "basket"));
        }
        if (ItemNum == 5)
        {
            item5 = Instantiate(goldShell, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 4;
                    itemcnt.text = Count + "/4";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/4";
            StartCoroutine(ShootDelay(item5, "goldshell"));
        }
        if (ItemNum == 6)
        {
            item6 = Instantiate(grenada, gameObject.transform);
            if (Count <= 0)
            {
                /*if (Input.GetMouseButtonDown(0))
                {
                    Count = 3;
                    itemcnt.text = Count + "/3";
                }*/
                return;
            }
            Count--;
            itemcnt.text = Count + "/3";
            StartCoroutine(ShootDelay(item6, "grenade"));
        }
    }
    public void BulletRe()
    {
        if (ItemNum == 0)
        {
            Count = 25;
            itemcnt.text = Count + "/25";
        }
        if (ItemNum == 1)
        {
            Count = 10;
            itemcnt.text = Count + "/10";
        }
        if (ItemNum == 2)
        {
            Count = 8;
            itemcnt.text = Count + "/8";
        }
        if (ItemNum == 3)
        {
            Count = 6;
            itemcnt.text = Count + "/6";
        }
        if (ItemNum == 4)
        {
            Count = 5;
            itemcnt.text = Count + "/5";
        }
        if (ItemNum == 5)
        {
            Count = 4;
            itemcnt.text = Count + "/4";
        }
        if (ItemNum == 6)
        {
            Count = 3;
            itemcnt.text = Count + "/3";
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            BulletShell();
        }*/
        /*if (Input.GetKey(KeyCode.R))
        {
            if (ItemNum == 0)
            {
                Count = 25;
                itemcnt.text = Count + "/25";
            }
            if (ItemNum == 1)
            {
                Count = 10;
                itemcnt.text = Count + "/10";
            }
            if (ItemNum == 2)
            {
                Count = 8;
                itemcnt.text = Count + "/8";
            }
            if (ItemNum == 3)
            {
                Count = 6;
                itemcnt.text = Count + "/6";
            }
            if (ItemNum == 4)
            {
                Count = 5;
                itemcnt.text = Count + "/5";
            }
            if (ItemNum == 5)
            {
                Count = 4;
                itemcnt.text = Count + "/4";
            }
            if (ItemNum == 6)
            {
                Count = 3;
                itemcnt.text = Count + "/3";
            }
        }*/
    }
    IEnumerator ShootDelay(GameObject item, string name)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 basedir = Vector3.forward;
        Quaternion rot = Quaternion.Euler(-15, 0, 0);
        Vector3 throwdir = rot*basedir;
        if (name == "basic")
        {
            item.GetComponent<BulletCon>().Shoot(throwdir.normalized * 50);
        }
        if (name == "apple")
        {
            item.GetComponent<AppleCon>().Shoot(throwdir.normalized * 50);
        }
        if(name == "bamsongi")
        {
            item.GetComponent<BamsongiCon>().Shoot(throwdir.normalized * 50);
        }
        if (name == "bomb")
        {
            item.GetComponent<BombCon>().Shoot(throwdir.normalized * 50);
        }
        if (name == "basket")
        {
            item.GetComponent<BasketCon>().Shoot(throwdir.normalized * 50);
        }
        if (name == "goldshell")
        {
            item.GetComponent<GoldShellCon>().Shoot(throwdir.normalized * 50);
        }
        if (name == "grenade")
        {
            item.GetComponent<GrenadeCon>().Shoot(throwdir.normalized * 50);
        }
    }
}
