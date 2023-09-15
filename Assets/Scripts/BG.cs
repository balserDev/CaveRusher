using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    
    public GameManager Depth;
    public GameObject Camera;
    bool ONCHECK = true;
    public float BGSpeed;
    public Animator CameraAnimator;
    // Start is called before the first frame update
    void Start()
    {
      Depth =  GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Depth.Depth >50 && Depth.Depth < 100)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (Depth.Depth > 99 && Depth.Depth < 200)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (Depth.Depth > 199 && Depth.Depth < 300 )
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(Depth.Depth >299 && Depth.Depth < 400)
        {
            GetComponent<SpriteRenderer>().color = Color.magenta;
            CameraAnimator.SetBool("CameraShake", true);
        }
        if (Depth.Depth > 399 && Depth.Depth < 500)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            CameraAnimator.SetBool("CameraShake", false);
        }
        if (Depth.Depth > 499)
        {
            GetComponent<SpriteRenderer>().color = Color.white;

        }
        //BGmovement
        transform.position = transform.position + new Vector3(0, 1, 0) * Time.deltaTime * BGSpeed;
      
        
        if(transform.position.y >= -1f)
        {
            if (ONCHECK == true)
            {

                GameObject BG = Instantiate(this.gameObject);
                BG.transform.position = new Vector3(0, -13.8f, 0);
                ONCHECK = false;
           
                    
            }
            if(transform.position.y> 15)
            {
                Destroy(this.gameObject);
            }
            
            
        }
    }


}
