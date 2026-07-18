using ExitGames.Client.Photon.StructWrapping;
using Mediapipe;
using Mediapipe.Unity.Sample.Holistic;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class EvBasketCon : MonoBehaviour
{
    public EvGameManager evgm;
    private int randc;
    private int randsc;
    public HolisticTrackingSolution hs;
    private HolisticTrackingGraph graphRunner;
    private bool isInitialized = false;
    private bool right_flag = false;
    private bool left_flag = false;
    private bool face_right_flag = false;
    private bool face_left_flag = false;
    private Vector3 LeftsPos;
    private Vector3 RightsPos;
    public Text psx;
    public Text psy;
    private float righthandX = 0f;
    private float righthandY = 0f;
    private float lefthandX = 0f;
    private float lefthandY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (hs == null)
        {
            Debug.LogError("HolisticTrackingSolution not found!");
            return;
        }
        StartCoroutine("DebugGraphRunner");
        Debug.Log("===== PUBLIC FIELDS =====");
        var fields = hs.GetType().GetFields();
        foreach (var field in fields)
        {
            Debug.Log($"========> Field: {field.Name} - Type: {field.FieldType}");
        }

        Debug.Log("===== ALL FIELDS (including private) =====");
        var allFields = hs.GetType().GetFields(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance
        );
        foreach (var field in allFields)
        {
            Debug.Log($"Field: {field.Name} - Type: {field.FieldType}");
        }

        Debug.Log("===== PROPERTIES =====");
        var properties = hs.GetType().GetProperties();
        foreach (var prop in properties)
        {
            Debug.Log($"Property: {prop.Name} - Type: {prop.PropertyType}");
        }

        Debug.Log("===== METHODS =====");
        var methods = hs.GetType().GetMethods();
        foreach (var method in methods)
        {
            if (!method.Name.StartsWith("get_") && !method.Name.StartsWith("set_"))
            {
                Debug.Log($"Method: {method.Name}");
            }
        }
    }
    IEnumerator DebugGraphRunner()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log($"========> 시도 {i + 1}");
            var graphField = hs.GetType().GetField("graphRunner", BindingFlags.NonPublic | BindingFlags.Instance);
            if (graphField != null)
            {
                graphRunner = graphField.GetValue(hs) as HolisticTrackingGraph;
                Debug.Log("GraphRunner 연결 성공ㅋㅋㅋ잡초맨");
                //이벤트 구독
                SubscribeToEvents();

                isInitialized = true;
                yield break;
            }
            else
            {
                Debug.Log("GraphRunner 연결 실패ㅋㅋㅋ꼬시다맛동산ㅋㅋ");
            }
        }
    }
    void SubscribeToEvents()
    {
        graphRunner.OnRightHandLandmarksOutput += (sender, eventArgs) =>
        {
            var packet = eventArgs.packet;
            if (packet != null)
            {
                var landmarks = packet.Get(NormalizedLandmarkList.Parser);
                if (landmarks != null && landmarks.Landmark.Count > 0)
                {
                    Debug.Log("오른손감지!!");
                    //cat.GetComponent<CatCon>().Go_Right();
                    if (right_flag == false)
                        right_flag = true;
                    var middle_figer_MCP = landmarks.Landmark[9];
                    float X = middle_figer_MCP.X;
                    float Y = middle_figer_MCP.Y;
                    float Z = middle_figer_MCP.Z;
                    float SX = X * Screen.width;
                    float SY = (1 - Y) * Screen.height;
                    Debug.Log($"rightHand:{SX},{SY}");
                    RightsPos = new Vector3(SX, SY, 0);
                    righthandX = SX;
                    righthandY = SY;
                }
            }
        };
        graphRunner.OnLeftHandLandmarksOutput += (sender, eventArgs) =>
        {
            var packet = eventArgs.packet;
            if (packet != null)
            {
                var landmarks = packet.Get(NormalizedLandmarkList.Parser);
                if (landmarks != null && landmarks.Landmark.Count > 0)
                {
                    Debug.Log("왼손감지!!");
                    //cat.GetComponent<CatCon>().Go_Right();
                    if (left_flag == false)
                        left_flag = true;
                    var middle_figer_MCP = landmarks.Landmark[9];
                    float X = middle_figer_MCP.X;
                    float Y = middle_figer_MCP.Y;
                    float Z = middle_figer_MCP.Z;
                    float SX = X * Screen.width;
                    float SY = (1 - Y) * Screen.height;
                    Debug.Log($"leftHand:{SX},{SY}");
                    LeftsPos = new Vector3(SX, SY, 0);
                    lefthandX = SX;
                    lefthandY = SY;
                }
            }
        };
        /*graphRunner.OnFaceLandmarksOutput += (sender, eventArgs) =>
        {
            var packet = eventArgs.packet;
            if (packet != null)
            {
                var landmarks = packet.Get(NormalizedLandmarkList.Parser);
                if (landmarks != null && landmarks.Landmark.Count > 0)
                {
                    Debug.Log("얼굴감지!!");
                    //var noseTip = landmarks.Landmark[1];
                    //var leftCheek = landmarks.Landmark[234];
                    //var rightCheek = landmarks.Landmark[454];
                    var rightEye = landmarks.Landmark[33];
                    var leftEye = landmarks.Landmark[263];
                    //float faceCenter = (leftCheek.X + rightCheek.X) / 2f;
                    //float noseOffset = noseTip.X - faceCenter;
                    //float threshold = 0.08f;
                    float eyeYDiff = leftEye.Y - rightEye.Y;
                    float thilthreshold = 0.03f;
                    if (noseOffset > threshold && !face_left_flag)
                    {
                        face_left_flag = true;
                        Debug.Log("얼굴 오른쪽 감지!!");
                    }
                    else if (noseOffset < -threshold && !face_right_flag)
                    {
                        face_right_flag = true;
                        Debug.Log("얼굴 왼쪽 감지!!");
                    }
                    if (eyeYDiff > thilthreshold && !face_left_flag)
                    {
                        face_left_flag = true;
                        Debug.Log("얼굴 오른쪽 감지!!");
                    }
                    else if (eyeYDiff < -thilthreshold && !face_right_flag)
                    {
                        face_right_flag = true;
                        Debug.Log("얼굴 왼쪽 감지!!");
                    }
                }
            }
        };*/
    }
    // Update is called once per frame
    void Update()
    {
        if (right_flag)
        {
            right_flag = false;
            float px;
            float pz;
            psx.text = "SX : " + righthandX.ToString("F2");
            psy.text = "SY : " + righthandY.ToString("F2");
            if(righthandX >= 801 && righthandX <= 1200)
            {
                px = -1;
            }
            else if(righthandX >=401 && righthandX <= 800)
            {
                px = 0;
            }
            else if(righthandX >= -20 && righthandX <= 400)
            {
                px = 1;
            }
            else
            {
                px = 100;
            }
            if(righthandY >= 533 && righthandY <= 800)
            {
                pz = 1;
            }
            else if (righthandY >= 266 && righthandY <= 532)
            {
                pz = 0;
            }
            else if (righthandY >= -20 && righthandY <= 265)
            {
                pz = -1;
            }
            else
            {
                pz = 100;
            }
            if(px!=100 && pz != 100)
            {
                transform.position = new Vector3(px, 0.1f, pz);
            }
        }
        if (left_flag)
        {
            left_flag = false;
            float px;
            float pz;
            psx.text = "SX : " + lefthandX.ToString("F2");
            psy.text = "SY : " + lefthandY.ToString("F2");
            if (lefthandX >= 801 && lefthandX <= 1200)
            {
                px = -1;
            }
            else if (lefthandX >= 401 && lefthandX <= 800)
            {
                px = 0;
            }
            else if (lefthandX >= -20 && lefthandX <= 400)
            {
                px = 1;
            }
            else
            {
                px = 100;
            }
            if (lefthandY >= 533 && lefthandY <= 800)
            {
                pz = 1;
            }
            else if (lefthandY >= 266 && lefthandY <= 532)
            {
                pz = 0;
            }
            else if (lefthandY >= -20 && lefthandY <= 265)
            {
                pz = -1;
            }
            else
            {
                pz = 100;
            }
            if (px != 100 && pz != 100)
            {
                transform.position = new Vector3(px, 0.1f, pz);
            }
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask boardLayer = LayerMask.GetMask("Board");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, boardLayer))
            {
                /*Debug.Log("X:");
                Debug.Log(hit.point.x);
                Debug.Log("Z:");
                Debug.Log(hit.point.z);
                //if (hit.collider.CompareTag("Board"))
                //{
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0.1f, z);
                //}
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "EVApple")
        {
            randc = Random.Range(0, 11);
            randsc = Random.Range(0, 2);
            Debug.Log("얻은재화 : " + randc);
            Debug.Log("얻은보석 : " + randsc);
            evgm.update_coin(randc);
            evgm.update_spcoin(randsc);
        }
        else if (other.tag == "EVBamsongi")
        {
            randc = Random.Range(0, 21);
            randsc = Random.Range(0, 3);
            Debug.Log("얻은재화 : " + randc);
            Debug.Log("얻은보석 : " + randsc);
            evgm.update_coin(randc);
            evgm.update_spcoin(randsc);
        }
        else if (other.tag == "EVBomb")
        {
            randc = Random.Range(0, 51);
            randsc = Random.Range(0, 6);
            Debug.Log("얻은재화 : " + randc);
            Debug.Log("얻은보석 : " + randsc);
            evgm.update_coin(randc);
            evgm.update_spcoin(randsc);
        }
        else if (other.tag == "EVGoldshell")
        {
            randc = Random.Range(10, 201);
            randsc = Random.Range(1, 32);
            Debug.Log("얻은재화 : " + randc);
            Debug.Log("얻은보석 : " + randsc);
            evgm.update_coin(randc);
            evgm.update_spcoin(randsc);
        }
        else if (other.tag == "EVGrenade")
        {
            randc = Random.Range(10, 501);
            randsc = Random.Range(1, 81);
            Debug.Log("얻은재화 : " + randc);
            Debug.Log("얻은보석 : " + randsc);
            evgm.update_coin(randc);
            evgm.update_spcoin(randsc);
        }
    }
}
