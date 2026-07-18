using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextWorkManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    GameObject p;
    //public TMP_InputField nickname;
    string nickname;
    string defaultName;
    static NextWorkManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            StartCoroutine(ReactivatePlayers());
        }
        else
        {
            //DeactivateAllPlayers();
            SetAllplayersVisible(false);
        }
    }
    void SetAllplayersVisible(bool visible)
    {
        foreach (var pv in FindObjectsByType<PhotonView>(FindObjectsSortMode.None))
        {
            foreach (var renderer in pv.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = visible;
            }
        }
    }
    IEnumerator ReactivatePlayers()
    {
        yield return null;
        SetAllplayersVisible(true);
        /*yield return null;
        foreach(var obj in GameObject.FindGameObjectsWithTag("NetWork"))
        {
            obj.SetActive(true);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "kr";
        PhotonNetwork.ConnectUsingSettings();
        //if (nickname != null)
        //{
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            defaultName = PlayerPrefs.GetString("PlayerName");
            nickname = defaultName;
        }
        //}
        if (PhotonNetwork.InRoom)
        {
            if (GetMyPlayer() == null)
            {
                Debug.Log("유나");
                SpawnPlayer();
            }
        }
        else if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinLobby();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    GameObject GetMyPlayer()
    {
        foreach (var pv in FindObjectsByType<PhotonView>(FindObjectsSortMode.None))
        {
            if (pv.IsMine)
            {
                return photonView.gameObject;
            }
        }
        return null;
    }
    public void OnConnectPressed()
    {
        Debug.Log("OnConnect!!");
        //SceneManager.LoadScene("CharactorPickScene");
    }
    public override void OnConnectedToMaster()
    {
        if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.ConnectedToMasterServer)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("ConnetedToMaster");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 8;
        PhotonNetwork.JoinOrCreateRoom("MainRoom", roomOptions, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"리전:{PhotonNetwork.CloudRegion}");
        Debug.Log($"방 이름:{PhotonNetwork.CurrentRoom.Name}");
        Debug.Log($"플레이어 수 :{PhotonNetwork.CurrentRoom.PlayerCount}");
        SetPlayerName(nickname);
        Debug.Log("JoinedRoom");
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        p = PhotonNetwork.Instantiate(player.name, new Vector3(0, 1, 0), Quaternion.identity, 0);
        DontDestroyOnLoad(p); //플레이어도 Scene 전환시 유지
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            value = "Ghost " + Random.Range(0, 101);
            return;
        }
        PhotonNetwork.NickName = value;
        Debug.Log(PhotonNetwork.NickName);
        PlayerPrefs.SetString("PlayerName", value);
    }
}
