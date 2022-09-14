using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject target;
    public GameObject dieAnimation;
    public GameObject gameOverAnimation;
    private GameObject gameSystem;
    public GameObject deathSound;
    public int[] direction;
    public int life;
    SpriteRenderer spriteColor;
    float delay;
    public new AudioSource[] audio = new AudioSource[3];
    

    void Start()
    {
        gameSystem = GameObject.Find("System");
        direction = new int[2];
        delay = 0;
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();
        if(SceneManager.GetActiveScene().name == "Night"){
            speed += 0.25f;
            if(this.gameObject.tag == "Felipe"){
                life -= 5;
                speed -= 0.15f;
            }
        }

        int audioSelector = (int)Mathf.Round(Random.value*2);
        audio[audioSelector].Play();
        Debug.Log(audioSelector);  
    }

    void Update()
    {
        
        if(life <= 0){
            Morrer();
        }
        delay -= Time.deltaTime;
        if(delay <= 0f){ 
                spriteColor.color = Color.white;
        }
    }
    
    void FixedUpdate(){

        if(gameSystem.GetComponent<Game>().isGameOver){        
            GameObject explosion = Instantiate(gameOverAnimation, target.transform.position + new Vector3(0,0.25f,0), Quaternion.identity);
            Destroy(explosion, explosion.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Morrer();
        }

        //Debug.Log(Mathf.Round(this.transform.position.x*30));
        if(this.tag == "Leo"|| this.tag =="Felipe"){         
            if(Mathf.Round(this.transform.position.x*20) != target.transform.position.x){
                rb.velocity = new Vector2(1*direction[0]*speed,0);
            }
            else{

                if(Mathf.Round(this.transform.position.y*20) != target.transform.position.x){ 
                    rb.velocity = new Vector2(0,1*direction[1]*speed);
                }

                if(Mathf.Round(this.transform.position.y*20) < target.transform.position.y){
                    direction[1] = 1;
                }

                if(Mathf.Round(this.transform.position.y*20) > target.transform.position.y){
                    direction[1] = -1;
                }
            }
                           
            }

            if(Mathf.Round(this.transform.position.x*20) < target.transform.position.x){
                direction[0] = 1;
            }        
            else if(Mathf.Round(this.transform.position.x*20) > target.transform.position.x){
                direction[0] = -1;
                this.transform.localScale = new Vector2(-1f,1f);
            }
                                  
        }

    void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.tag == "ChainSaw" || colisao.tag == "Axe"){
            if(colisao.tag == "Axe"){
                Destroy(colisao.gameObject);
            }

            life -= 1;

            if(delay <= 0){
                spriteColor.color = Color.red;
                delay = 0.25f;
            }          
        }
        if(colisao.gameObject.tag == "Marmita"){
            colisao.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            gameSystem.GetComponent<Game>().isGameOver = true;
        }
        if(colisao.gameObject.tag == "Boulder"){
            Destroy(colisao.gameObject);
            life -= 2;
        }
    }

    void Morrer(){
        
        GameObject smoke = Instantiate(dieAnimation,transform.position, Quaternion.identity);
        
       
        if(this.tag == "Felipe"){
            smoke.transform.localScale = new Vector2(2,2);
            smoke.transform.position = transform.position + new Vector3(0,0.2f,0);
        }
        Destroy (smoke, smoke.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        if(this.tag == "Leo" || this.tag == "Felipe"){
            if(gameSystem.GetComponent<Game>().isGameOver == false){
                if(this.tag == "Felipe"){
                gameSystem.GetComponent<Game>().score += 5;
                GameObject audioMorte = Instantiate(deathSound, transform.position, Quaternion.identity);
                Destroy(audioMorte,3);
            }
            if(this.tag == "Leo"){
                gameSystem.GetComponent<Game>().score += 1;
                GameObject audioMorte = Instantiate(deathSound, transform.position, Quaternion.identity);
                Destroy(audioMorte,3);
            }
            }
            
            //Debug.Log(gameSystem.GetComponent<Game>().score);
            Destroy(gameObject);
        }
    }
}