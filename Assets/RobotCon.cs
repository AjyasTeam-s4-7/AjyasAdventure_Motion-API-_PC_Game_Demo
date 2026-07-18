using Mediapipe.Unity.Sample.Holistic;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Mediapipe;
using UnityEngine.UI;

public class RobotCon : MonoBehaviour
{
    public ShootCon bullet;
    public ShootCon re;
    public HolisticTrackingSolution hs;
    public HpCon hpc;
    public Text FPS;
    private float now = 0f;
    private float lasttime = 0f;
    private float fps;
    Animator ani;
    Rigidbody rb;
    private int PickID;
    private HolisticTrackingGraph graphRunner;
    //public float gotil = 0.2f; // 감지 민감도(가속도 센서)
    private bool isInitialized = false;
    private bool right_flag = false;
    private bool left_flag = false;
    private bool face_right_flag = false;
    private bool face_left_flag = false;
    //public GameObject leftHand;
    //public GameObject rightHand;
    private Vector3 LeftsPos;
    private Vector3 RightsPos;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        PickID = PlayerPrefs.GetInt("Robot", 0);

        //hs = GetComponent<HolisticTrackingSolution>();
        //leftHand.SetActive(false);
        //rightHand.SetActive(false);
        if (hs == null)
        {
            Debug.LogError("HolisticTrackingSolution not found!");
            return;
        }

        //hs.Play();
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
                    var wrist = landmarks.Landmark[0];
                    float X = wrist.X;
                    float Y = wrist.Y;
                    float Z = wrist.Z;
                    float SX = X * Screen.width;
                    float SY = (1 - Y) * Screen.height;
                    Debug.Log($"rightHand:{SX},{SY}");
                    RightsPos = new Vector3(SX, SY, 0);
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
                    var wrist = landmarks.Landmark[0];
                    float X = wrist.X;
                    float Y = wrist.Y;
                    float Z = wrist.Z;
                    float SX = X * Screen.width;
                    float SY = (1 - Y) * Screen.height;
                    Debug.Log($"leftHand:{SX},{SY}");
                    LeftsPos = new Vector3(SX, SY, 0);
                }
            }
        };
        graphRunner.OnFaceLandmarksOutput += (sender, eventArgs) =>
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
                    /*if (noseOffset > threshold && !face_left_flag)
                    {
                        face_left_flag = true;
                        Debug.Log("얼굴 오른쪽 감지!!");
                    }
                    else if (noseOffset < -threshold && !face_right_flag)
                    {
                        face_right_flag = true;
                        Debug.Log("얼굴 왼쪽 감지!!");
                    }*/
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
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (face_left_flag)
        {
            transform.Translate(new Vector3(-0.05f, 0, 0));
            now = Time.realtimeSinceStartup;
            fps = 1.0f / (now - lasttime);
            lasttime = now;
            FPS.text = "FPS : " + (int)fps;
            face_left_flag = false;
        }
        if (face_right_flag)
        {
            transform.Translate(new Vector3(0.05f, 0, 0));
            now = Time.realtimeSinceStartup;
            fps = 1.0f / (now - lasttime);
            lasttime = now;
            FPS.text = "FPS : " + (int)fps;
            face_right_flag = false;
        }
        if (right_flag)
        {
            right_flag = false;
            bullet.BulletShell();
        }
        if (left_flag)
        {
            left_flag = false;
            re.BulletRe();
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(0, 0, -25);
        }
        /*float goX = Input.acceleration.x;   // 좌우 기울기: -1.0 ~ 1.0
        if (goX > gotil)
        {
            transform.Translate(new Vector3(0.1f, 0, 0));
        }
        if (goX < -gotil)
        {
            transform.Translate(new Vector3(-0.1f, 0, 0));
        }*/
        if (hpc.Get_mhp() <= 0)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(0, 0, -25);
        }
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(0, 0, -25);
        }
    }
}
