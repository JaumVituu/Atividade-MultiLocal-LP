using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSaw_Sound : MonoBehaviour
{
    public bool tocaAudio;
    public new AudioSource audio;

    void Start(){
        tocaAudio = false;
    }

    void Update(){

        if(tocaAudio){
            audio.Play();
            tocaAudio = false;
        }
    }
}
