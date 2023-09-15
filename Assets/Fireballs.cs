using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
     public GameObject Proyectile;
    public Transform Player;
     public GameObject[] ShootFireballs;      
     private bool MovingBalls;
    public AudioSource FireSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireInstance());
    }

    // Update is called once per frame
    void Update()
    {
        if(MovingBalls == true)
        {
            FireMovemet();
        }
    }

    IEnumerator FireInstance()
    {

        for(int i = 0; i < ShootFireballs.Length; i++)
        {
            ShootFireballs[i] = Instantiate(Proyectile, Player.position, Quaternion.identity);

           // ShootFireballs[i].transform.parent = transform;
           
        }
        MovingBalls = true;
        FireSound.Play();
        //yield return new WaitForSeconds(0.1f);
        //ShootFireballs[0].GetComponent<BoxCollider2D>().isTrigger = false;
        //ShootFireballs[1].GetComponent<BoxCollider2D>().isTrigger = false;
        //ShootFireballs[2].GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(1);
        MovingBalls = false;
        Destroy(ShootFireballs[0]);
        Destroy(ShootFireballs[1]);
        Destroy(ShootFireballs[2]);
     
        StartCoroutine(FireInstance());
    }

    public void FireMovemet()
    {
        int Speed = 10;
        ShootFireballs[0].transform.position += new Vector3(0, 1, 0) * Time.deltaTime * Speed;
        ShootFireballs[1].transform.position += new Vector3(1, 0, 0) * Time.deltaTime * Speed;
        ShootFireballs[2].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * Speed;

    }
}
