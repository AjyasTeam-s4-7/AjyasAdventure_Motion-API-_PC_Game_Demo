using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCon : MonoBehaviour
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
        Debug.Log("²¿½Ã´Ù ¸Àµ¿»ê~!!");
        Application.Quit();
    }
}
