using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCon : MonoBehaviourPunCallbacks
{
    //public GameObject Char1;
    //public GameObject Char2;
    public GameObject Char3;
    private int Pick;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Pick = PlayerPrefs.GetInt("Robot", 0);
        /*if (Pick == 1)
        {
            Char1.SetActive(true);
        }
        if (Pick == 2)
        {
            Char2.SetActive(true);
        }*/
        if (Pick == 3)
        {
            Char3.SetActive(true);
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
