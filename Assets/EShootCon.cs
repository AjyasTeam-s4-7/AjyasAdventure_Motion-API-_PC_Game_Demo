using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EShootCon : MonoBehaviour
{
    public GameObject eshell;
    GameObject eitem;
    private int cur_stage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void eshoot()
    {
        eitem = Instantiate(eshell, gameObject.transform);
        StartCoroutine(EShootDelay());
    }
    public void eshoot1()
    {
        eitem = Instantiate(eshell, gameObject.transform);
        StartCoroutine(EShootDelay1());
        
    }
    public void eshoot2()
    {
        eitem = Instantiate(eshell, gameObject.transform);
        StartCoroutine(EShootDelay2());
    }
    IEnumerator EShootDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 basedir = Vector3.back;
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        Vector3 throwdir = rot * basedir;
        eitem.GetComponent<EBulletCon>().EShoot(throwdir.normalized * 25);
    }
    IEnumerator EShootDelay1()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 basedir = Vector3.back;
        Quaternion rot = Quaternion.Euler(-15, 0, 0);
        Vector3 throwdir = rot * basedir;
        eitem.GetComponent<EBulletCon>().EShoot(throwdir.normalized * 25);
    }
    IEnumerator EShootDelay2()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 basedir = Vector3.back;
        Quaternion rot = Quaternion.Euler(-15, 0, 0);
        Vector3 throwdir = rot * basedir;
        eitem.GetComponent<EBulletCon>().EShoot(throwdir.normalized * 50);
    }
}
