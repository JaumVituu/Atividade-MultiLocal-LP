using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    float remainingTime;   
    void Start()
    {
        remainingTime = 5f;
    }

    
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0f){
            Destroy(gameObject);
        }
    }
    
    
}
