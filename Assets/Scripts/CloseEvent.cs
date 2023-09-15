using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEvent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}