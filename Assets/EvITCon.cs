using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvITCon : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-0.06f, -0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
        if (transform.position.y < -0.9f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "basket")
        {
            //GetComponent<ParticleSystem>().Play();
            Invoke("Devil", 1f);
            Destroy(gameObject);
        }
    }
    void Devil()
    {
        Destroy(gameObject);
    }
}
