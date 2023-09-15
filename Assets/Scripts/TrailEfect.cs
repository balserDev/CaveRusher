using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEfect : MonoBehaviour
{
    public float TimeToSpawn;
    public float StartTime;
    public GameObject Echo;
    public GameObject parentsaver;
    public Sprite[] Skins;
    public int Skinvalue;
    public PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per fram
    void Update()
    {

        if(Player.OnbeingRevived == false)
        {
            if (TimeToSpawn <= 0)
            {
                GameObject instance = (GameObject)Instantiate(Echo, parentsaver.transform.position, Quaternion.identity);
                instance.GetComponent<SpriteRenderer>().sprite = Skins[Skinvalue];
                instance.transform.parent = parentsaver.transform;
                Destroy(instance, 3f);

                TimeToSpawn = StartTime;
            }
            else
            {
                TimeToSpawn -= Time.deltaTime;
            }
        }
       
    }
}
