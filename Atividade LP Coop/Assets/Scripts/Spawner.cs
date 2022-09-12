using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Leo;
    public GameObject Felipe;
    public GameObject Boost;
    GameObject system;
    float[] cooldown;
    bool alreadySpawned;
    float cdCoeficient;
    void Start()
    {
        system = GameObject.Find("System");
        cooldown = new float[2];
        cooldown[0] = Random.value*5;
        cooldown[1] = Random.value*8;
    }

    // Update is called once per frame
    void Update()
    {   
        cdCoeficient = system.GetComponent<Game>().currentTime/10;
        
        if(cooldown[0] > 0f){
            cooldown[0] -= Time.deltaTime;
        }
        if(cooldown[0] <= 0f){
            Instantiate (Leo, transform.position + new Vector3(0f,Random.value,0f), Quaternion.identity);
            cooldown[0] = Random.Range(1,8-cdCoeficient);
        }
        
        if (cdCoeficient <= 0){
            if(Mathf.Round(system.GetComponent<Game>().currentTime)%20+cdCoeficient == 0 && Mathf.Round(system.GetComponent<Game>().currentTime) != 0){
                if(alreadySpawned == false){
                    Instantiate (Felipe, transform.position + new Vector3(0f,Random.value,0f), Quaternion.identity);
                    alreadySpawned = !alreadySpawned;
                }
            }            
        }
        else{
            if(Mathf.Round(system.GetComponent<Game>().currentTime)%20 == 0 && Mathf.Round(system.GetComponent<Game>().currentTime) != 0){
                if(alreadySpawned == false){
                    Instantiate (Felipe, transform.position + new Vector3(0f,Random.value,0f), Quaternion.identity);
                    alreadySpawned = !alreadySpawned;
                }
            }
            else{
                alreadySpawned = false;
            }
        }     

        if(cooldown[1] > 0f){
            cooldown[1] -= Time.deltaTime;
        }
        if(cooldown[1] <=0f){
            if(transform.position.x < GameObject.Find("Marmita").transform.position.x){
                GameObject powerUp = Instantiate(Boost, new Vector2(Random.value*1.25f,Random.value*0.9f-0.35f), Quaternion.identity);
                Destroy(powerUp, 3); 
            }
            if(transform.position.x > GameObject.Find("Marmita").transform.position.x){
                GameObject powerUp = Instantiate(Boost, new Vector2(Random.value*-1.25f,Random.value*0.9f-0.35f), Quaternion.identity);
                Destroy(powerUp, 3); 
            }
            
            
            cooldown[1] = Random.Range(5,20-cdCoeficient);
        }
    }

    void FixedUpdate(){
        if(system.GetComponent<Game>().isGameOver == true){
            gameObject.SetActive(false);
        }
    }
}
