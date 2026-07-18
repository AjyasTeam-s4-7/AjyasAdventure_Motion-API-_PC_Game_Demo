using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PhotonView pv = other.GetComponent<PhotonView>();
        if (other.transform.tag == "NetWork")
        {
            other.gameObject.transform.position = new Vector3(0, 0, -6.57f);
        }
        if (pv != null && pv.IsMine)
       {
            Debug.Log("EVENT");
            SceneManager.LoadScene("HoEventScene");
        }
    }
}
