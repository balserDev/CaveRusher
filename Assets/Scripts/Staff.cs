using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
    public AudioSource BeamManager;
    //public GameObject Staffer;
    public GameObject StaffIcon;
    public Text StafLoadtext;
    public int StaffLoad;
    public GameObject Scene;
    public GameObject Coin;
    [SerializeField]
    GameObject Bat;
    public LineRenderer RayDraw;
    [SerializeField]
    Transform[] RayPosition;

    bool OnShooting = true;
    // Start is called before the first frame update
    void Start()
    {
        StaffIcon.SetActive(true);
        Scene = GameObject.Find("Scene");
        RayDraw.positionCount = 2;
        StaffLoad = 100;
        StafLoadtext.text = "100%";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        if (StaffLoad > 0)
        {
            RayDraw.enabled = true;
            if (Bat.transform.childCount > 0)
            {
                Debug.Log("Pene01");
                RayDraw.enabled = true;
                if (Bat.transform.childCount > 0 && Bat.transform.GetChild(0).transform.childCount > 0 && Bat.transform.GetChild(0).transform.GetChild(0) != null)
                {
                    Debug.Log("Pene02");
                    if (Bat.transform.GetChild(0).transform.GetChild(0) != null)
                    {
                        Debug.Log("Pene03");
                        RayPosition[1] = Bat.transform.GetChild(0).transform.GetChild(0).transform;
                        RayDraw.SetPosition(0, RayPosition[0].position);
                        RayDraw.SetPosition(1, RayPosition[1].position);
                    }
                    if (OnShooting == true)
                    {
                        StartCoroutine(EnemyDestoy());
                    }

                }
                else
                {
                    Destroy(Bat.transform.GetChild(0).gameObject);
                    RayDraw.enabled = false;
                }


            }
            else
            {
                RayDraw.enabled = false;
            }

        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            RayDraw.enabled = false;
        }

        //Staffer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }
    IEnumerator EnemyDestoy()
    {

        Debug.Log("Pene04");
        BeamManager.Play();
        OnShooting = false;
        yield return new WaitForSeconds(1.5f);
        if(Bat.transform.childCount > 0)
        {
            GameObject Coiner = Instantiate(Coin);
            Coiner.transform.position = Bat.transform.GetChild(0).transform.GetChild(0).transform.position;
           
            Debug.Log("Pene05");
            Destroy(Bat.transform.GetChild(0).transform.GetChild(0).gameObject);
            StaffLoad -= 5;
            StafLoadtext.text = StaffLoad.ToString() + "%";

        }
        OnShooting = true;
        BeamManager.Stop();
    }


}
