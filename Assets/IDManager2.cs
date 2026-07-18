using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IDManager2 : MonoBehaviourPunCallbacks
{
    //public TextMesh ID1;
    //public TextMesh ID2;
    public TextMesh ID3;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PhotonNetwork.NickName);
        //ID1.text = PhotonNetwork.NickName;
        //ID2.text = PhotonNetwork.NickName;
        ID3.text = PhotonNetwork.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
