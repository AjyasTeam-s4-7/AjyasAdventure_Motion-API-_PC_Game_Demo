using ExitGames.Client.Photon.StructWrapping;
using Mediapipe;
using Mediapipe.Unity.Sample.Holistic;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCon : MonoBehaviourPun
{
    public TextMesh nickname;
    PhotonView pv;
    Animator ani;
    Rigidbody rb;
    private int PickID;
    private int Cur_Stage;
    private bool isMovingScene = false;
    //private Gyroscope gyro; // 자이로센서 API 선언
    //private Quaternion inRo;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        PickID = PlayerPrefs.GetInt("Robot", 0);
        //nickname.text = PhotonNetwork.NickName;
        nickname.text = pv.Owner.NickName;
        Debug.Log("===============>" + nickname.text);
        /*if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            inRo = transform.rotation;
        }
        else
        {
            Debug.Log("자이로스코프 지원X");
        }*/
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("앞");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(0, 0, 0.05f));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("앞");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(0, 0, 0.1f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("좌");
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.Translate(new Vector3(0, 0, 0.05f));
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("좌");
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.Translate(new Vector3(0, 0, 0.1f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("뒤");
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(new Vector3(0, 0, 0.05f));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("뒤");
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(new Vector3(0, 0, 0.1f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("우");
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(new Vector3(0, 0, 0.05f));
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("우");
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(new Vector3(0, 0, 0.1f));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            //Debug.Log("좌앞");
            transform.rotation = Quaternion.Euler(0, -45, 0);
            transform.Translate(new Vector3(0, 0, 0.01f));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("좌앞");
            transform.rotation = Quaternion.Euler(0, -45, 0);
            transform.Translate(new Vector3(0, 0, 0.02f));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //Debug.Log("우앞");
            transform.rotation = Quaternion.Euler(0, 45, 0);
            transform.Translate(new Vector3(0, 0, 0.01f));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("우앞");
            transform.rotation = Quaternion.Euler(0, 45, 0);
            transform.Translate(new Vector3(0, 0, 0.02f));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            //Debug.Log("좌뒤");
            transform.rotation = Quaternion.Euler(0, 225, 0);
            transform.Translate(new Vector3(0, 0, 0.01f));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("좌뒤");
            transform.rotation = Quaternion.Euler(0, 225, 0);
            transform.Translate(new Vector3(0, 0, 0.02f));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            //Debug.Log("우뒤");
            transform.rotation = Quaternion.Euler(0, 135, 0);
            transform.Translate(new Vector3(0, 0, 0.01f));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("우뒤");
            transform.rotation = Quaternion.Euler(0, 135, 0);
            transform.Translate(new Vector3(0, 0, 0.02f));
        }
        /*if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, 0.1f, 0));
        }*/
        if (Input.GetKey(KeyCode.F))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(2, 0.65f, -6.57f);
        }
        if (transform.position.z > 50 && !isMovingScene)
        {
            isMovingScene = true;
            Cur_Stage = PlayerPrefs.GetInt("gamestage", 0);
            switch (Cur_Stage)
            {
                case 0:
                    SceneManager.LoadScene("HOBattleScene1");
                    break;
                case 1:
                    SceneManager.LoadScene("HOBattleScene2");
                    break;
                case 2:
                    SceneManager.LoadScene("HOBattleScene3");
                    break;
                default:
                    SceneManager.LoadScene("HOBattleScene1");
                    break;
            }
            transform.position = new Vector3(2, 0.65f, -6.57f);
            isMovingScene = false;
        }
        //Quaternion gyroROT = gyro.attitude; // 자이로
        //gyroROT = new Quaternion(gyroROT.x,gyroROT.y,-gyroROT.z,-gyroROT.w);
        //transform.rotation = inRo * gyroROT;
        /*if (gyro != null && gyro.enabled)
         {
             float pitch = GetPitch();
         }*/
    }
    /*float GetPitch()
    {
        Quaternion gyroQuat = new Quaternion(gyro.attitude.x, gyro.attitude.y, -gyro.attitude.z, -gyro.attitude.w);
        Quaternion rotation = Quaternion.Euler(0, 90, 0) * gyroQuat;
        rotation = Quaternion.Euler(0, 90, 0) * gyroQuat;
        float pitch = rotation.eulerAngles.x;
        if(pitch > 180)
        {
            pitch -= 360;
        }
        return Mathf.Clamp(pitch, -90, 90);
    }*/
}
