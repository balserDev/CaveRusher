using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBlock : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player" && collision.gameObject.tag != "Fire")
        {
            Destroy(collision.gameObject);
        }

    }

    public void Update()
    {
        //Vector2 raycasPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(raycasPos, Vector2.zero);
        //if (hit.transform != null)
        //{
        //    if (hit.transform.tag == "Plataform")
        //    {
        
        //    }
        //}


    }

}
