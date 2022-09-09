using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float currentTime;
    public int points;
    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {       
        currentTime += Time.deltaTime;       
    }
}
