using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject Scene;
    public GameObject Coin;
    public float Speed;
    public float XDirection;
    public float YDireccion;
   [SerializeField]
    AudioSource[] SoundEffect;
    public AudioClip[] BatEffect;
   
    // Start is called before the first frame update
    void Start()
    {
        Scene = GameObject.Find("Scene");
        SoundEffect[1] = GameObject.Find("Effects01").GetComponent<AudioSource>();
        SoundEffect[0] = GameObject.Find("Effects02").GetComponent<AudioSource>();     
        SoundEffect[0].clip = BatEffect[0];
        SoundEffect[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
        transform.position = transform.position + new Vector3(XDirection, YDireccion, 0) * Time.deltaTime * Speed;
        if (transform.position.y > 15f || transform.position.y < -15f)
        {
            Destroy(this.gameObject);
        }
        for (int i = 0; i < transform.childCount; i++)
        {

         //   transform.GetChild[[0].SetActiveBool;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    void MouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 raycasPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycasPos, Vector2.zero);
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Bat")
                {
                   GameObject Coiner = Instantiate(Coin);
                    Coiner.transform.position = hit.transform.position;
                
                    Destroy(hit.transform.gameObject);
                    SoundEffect[1].clip = BatEffect[1];
                    SoundEffect[1].Play();

                }
            }
        }
    }
}
