using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bat");
        if (collision.transform.tag == "Bat")
        {
            Destroy(collision.gameObject);
          
        }
    }
   
}
