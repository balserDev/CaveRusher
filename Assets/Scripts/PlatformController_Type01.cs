using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController_Type01 : MonoBehaviour
{
    
    Transform PlataformTransform;
    public GameObject Wings;
    public float Speed;
    GameManager  Depth;
    void Start()
    {
        Depth = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlataformTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Depth.Depth > 50 && Depth.Depth < 149)
        {
            Speed = 4;
        }
        if (Depth.Depth > 149 && Depth.Depth < 300)
        {
            if (Wings)
            {
                Speed = 4;
            }
            else
            {
                Speed = 6;
            }

        }
        if (Depth.Depth > 299 && Depth.Depth < 400)
        {
            if (Wings)
            {
                Speed = 4.5f;
            }
            else
            {
                Speed = 7.5f;
            }

        }
        if (Depth.Depth > 399 && Depth.Depth < 499)
        {
            if (Wings)
            {
                Speed = 5.5f;
            }
            else
            {
                Speed = 9;
            }

        }
        if (Depth.Depth >500)
        {
            if (Wings)
            {
                Speed = 8f;
            }
            else
            {
                Speed = 12;
            }

        }

        PlataformTransform.position = PlataformTransform.position + new Vector3(0, 1, 0) * Time.deltaTime * Speed;
        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
