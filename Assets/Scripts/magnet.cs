using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    Transform PlayerTransform;
    GameObject Magnet;
    private void Start()
    {
        Magnet = GameObject.Find("Magnet");
        PlayerTransform = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if(Magnet)
        {
            
            GetComponent<PlatformController_Type01>().enabled = false;
            if(PlayerTransform.transform.position.x > transform.position.x)
            {
                transform.position = transform.position + new Vector3(1, 0, 0) * Time.deltaTime*5;

            }
            if (PlayerTransform.transform.position.x < transform.position.x)
            {
                transform.position = transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * 5;

            }
            if (PlayerTransform.transform.position.y < transform.position.y)
            {
                transform.position = transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 5;

            }
            if (PlayerTransform.transform.position.y > transform.position.y)
            {
                transform.position = transform.position + new Vector3(0, 1, 0) * Time.deltaTime * 5;

            }

        }
    }


}
