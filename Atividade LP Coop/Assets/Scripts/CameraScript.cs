using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector2 interpolation;
    public GameObject berserkerCoord;
    public GameObject vandalCoord;
    public float delay;
    private Camera props;
    public float distance;
    GameObject system;

    void Start()
    {
        props = GetComponent<Camera>();
        system = GameObject.Find("System");
    }

    // Update is called once per frame
    void Update()
    {
        if(system.GetComponent<Game>().isGameOver){
            props.orthographicSize = Mathf.Lerp(props.orthographicSize, distance + 2f, 0.5f*Time.deltaTime);
            interpolation = new Vector2(0,0);
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(interpolation.x,interpolation.y + 0.5f,-10), delay*Time.deltaTime);
            //distance = Vector3.Distance(berserkerCoord.transform.position,vandalCoord.transform.position)*0.5f;         
        }

        else{
            props.orthographicSize = Mathf.Lerp(props.orthographicSize , distance + 0.5f, delay*Time.deltaTime);
            interpolation.x = Mathf.Lerp(berserkerCoord.transform.position.x, vandalCoord.transform.position.x, 0.5f);
            interpolation.y = Mathf.Lerp(berserkerCoord.transform.position.y, vandalCoord.transform.position.y, 0.5f);
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(interpolation.x,interpolation.y + 0.5f,-10), delay*Time.deltaTime);
            distance = Vector3.Distance(berserkerCoord.transform.position,vandalCoord.transform.position)*0.5f;         
            props.orthographicSize = Mathf.Lerp(props.orthographicSize , distance + 0.5f, delay*Time.deltaTime);
        }
    }
}
