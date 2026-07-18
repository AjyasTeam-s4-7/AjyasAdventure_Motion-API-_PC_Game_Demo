using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVItemCon : MonoBehaviour
{
    public GameObject evapple;
    public GameObject evbamsongi;
    public GameObject evbomb;
    public GameObject evgoldshell;
    public GameObject evgrenade;
    public float dt = 1f;
    float ct;
    GameObject item;
    int dice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ct += Time.deltaTime;
        if (ct > dt)
        {
            ct = 0;
            dice = Random.Range(1, 11);
            if (dice >= 1 && dice <= 4)
            {
                item = Instantiate(evapple) as GameObject;
            }
            else if (dice >= 5 && dice <= 6)
            {
                item = Instantiate(evbamsongi) as GameObject;
            }
            else if (dice >= 7 && dice <= 8)
            {
                item = Instantiate(evbomb) as GameObject;
            }
            else if (dice == 9)
            {
                item = Instantiate(evgoldshell) as GameObject;
            }
            else
            {
                item = Instantiate(evgrenade) as GameObject;
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 3.5f, z);
        }
    }
}
