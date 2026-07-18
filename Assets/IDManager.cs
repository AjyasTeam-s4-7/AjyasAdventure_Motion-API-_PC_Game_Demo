using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IDManager : MonoBehaviourPunCallbacks
{
    public Text nickname;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PhotonNetwork.NickName);
        //nickname.text = "닉네임 ID : " + PhotonNetwork.NickName;
        nickname.text = PlayerPrefs.GetString("PlayerName");
        nickname.text = "닉네임 ID : " + nickname.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
