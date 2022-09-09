using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Leo;
    public GameObject Felipe;
    GameObject system;
    float colldown;
    void Start()
    {
        system = GameObject.Find("System");
        colldown = Random.value*5;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(colldown);
        if(colldown > 0f){
            colldown -= Time.deltaTime;
        }
        if(colldown <= 0f){
            Instantiate (Felipe, transform.position + new Vector3(0f,Random.value*0.5f,0f), Quaternion.identity);
            colldown = Random.Range(2,5);
        }
    }
}
