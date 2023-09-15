using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Batarang");
        if (collision.transform.tag == "Fire")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Batarang2");
        if (collision.transform.tag == "Fire")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Batarang3");
        if (collision.transform.tag == "Fire")
        {
            Destroy(this.gameObject);
        }
    }

}
