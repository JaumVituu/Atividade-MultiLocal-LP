using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject target;
    public GameObject dieAnimation;
    private GameObject gameSystem;
    public int direction;
    public int life;
    SpriteRenderer spriteColor;
    float delay;
    void Start()
    {
        delay = 0;
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();
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
        //Debug.Log(Mathf.Round(this.transform.position.x*10));
        if(this.tag == "Leo"|| this.tag =="Felipe"){         
            if(Mathf.Round(this.transform.position.x*10) != target.transform.position.x){
                rb.velocity = new Vector2(1*direction*speed,0);
            }
            else{
                rb.velocity = new Vector2(0,0);
            }

            if(Mathf.Round(this.transform.position.x*10) <= target.transform.position.x){
                direction = 1;
            }        
            else if(Mathf.Round(this.transform.position.x*10) > target.transform.position.x){
                direction = -1;
                this.transform.localScale = new Vector2(-1f,1f);
            }
                                  
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
    }

    void Morrer(){
        
        GameObject smoke = Instantiate(dieAnimation,transform.position, Quaternion.identity);
        if(this.tag == "Felipe"){
            smoke.transform.localScale = new Vector2(2,2);
            smoke.transform.position = transform.position + new Vector3(0,0.2f,0);
        }
        Destroy (smoke, smoke.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        if(this.tag == "Leo" || this.tag == "Felipe"){
            gameSystem = GameObject.Find("System");
            if(gameSystem != null){
                Debug.Log("ok");
            }
            gameSystem.GetComponent<Game>().points += 1;
            Debug.Log(gameSystem.GetComponent<Game>().points);
            Destroy(gameObject);
        }
    }
}