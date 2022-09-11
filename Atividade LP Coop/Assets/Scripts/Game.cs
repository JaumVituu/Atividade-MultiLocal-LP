using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float currentTime;
    public int points;
    public bool isGameOver;
    bool isEnd;
    void Start()
    {
        currentTime = 0f;
        isGameOver = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {       
        currentTime += Time.deltaTime;       
    }
}
