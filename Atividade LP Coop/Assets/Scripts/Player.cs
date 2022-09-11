using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animacao;
    float InputVertical;
    float InputHorizontal;
    private Rigidbody2D rb;
    public float speed;
    public GameObject Axe;
    public GameObject ChainSaw;
    float currentSide;
    float colldown;
    GameObject system;
    public GameObject dieAnimation;
    float poUpDuration;
    float axeBuff;
    

    void Start()
    {
        system = GameObject.Find("System");
        colldown = 0f;
        currentSide = 1f;
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        poUpDuration = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        if(poUpDuration <= 0f){
            speed = 1f;
            GetComponent<SpriteRenderer>().color = Color.white;
            animacao.speed = 1;
            if(this.gameObject.tag == "Vandal"){
                ChainSaw.GetComponent<Animator>().speed = 1f;
            }
            if(this.gameObject.tag == "Berserker"){
                Axe.GetComponent<Animator>().speed = 1f;
                axeBuff = 1f;
            } 
        }
        else{
            speed = 1.5f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            poUpDuration -=Time.deltaTime;
            animacao.speed = 1.5f;
            if(this.gameObject.tag == "Vandal"){
                ChainSaw.GetComponent<Animator>().speed = 3f;
            }
            if(this.gameObject.tag == "Berserker"){
                Axe.GetComponent<Animator>().speed = 3f;
                axeBuff = 2f;
            }       
        }

        gameObject.transform.localScale = new Vector2(currentSide,1f);
        Anima();
        //Debug.Log(InputHorizontal);
        Ataca();
    }

    void FixedUpdate(){
        Movimenta();
        if(system.GetComponent<Game>().isGameOver){
            Morrer();
        }
    }

    void Anima(){
        if(InputHorizontal != 0 || InputVertical != 0){
            animacao.SetBool("IsRunning", true);
        }
        else{
            animacao.SetBool("IsRunning", false);
        }
        if(InputHorizontal > 0){
            currentSide = 1f;
        }
        if(InputHorizontal < 0){
            currentSide = -1f;
        }
    }

    void Movimenta(){
        if(this.tag == "Berserker"){
            InputVertical = Input.GetAxisRaw("Vertical");
            InputHorizontal = Input.GetAxisRaw("Horizontal");           
        }
        if(this.tag == "Vandal"){
            InputVertical = Input.GetAxisRaw("Vertical1");
            InputHorizontal = Input.GetAxisRaw("Horizontal1");
        }
        
        if (InputHorizontal != 0f || InputVertical != 0f){
            Vector2 direction = new Vector2(InputHorizontal, InputVertical);
            direction.Normalize();
            rb.velocity = direction*speed;
        }
        else{
            rb.velocity = new Vector2(0,0);
        }
    }

    void Ataca(){
            
        colldown -= Time.deltaTime;
        if(this.tag == "Berserker"){
            if(Input.GetMouseButtonDown(0)){
                if(colldown <= 0f){
                    GameObject axe = Instantiate(Axe, transform.position + new Vector3(0,0.2f,0), Quaternion.identity);
                    axe.GetComponent<Rigidbody2D>().velocity = new Vector2 (2*currentSide*axeBuff,0);
                    if(poUpDuration <= 0f){                   
                        colldown = 0.5f;
                    }
                    else{
                        colldown = 0.125f;
                    }                     
                } 
            }
        }
        if(this.tag == "Vandal"){
            if(Input.GetKeyDown(KeyCode.Space)){
                ChainSaw.GetComponent<Animator>().SetBool("IsAttacking",true);
            }
            else{
                ChainSaw.GetComponent<Animator>().SetBool("IsAttacking",false);
            }
        }
    }

    void Morrer(){
        GameObject ghost = Instantiate(dieAnimation, transform.position, Quaternion.identity);
        ghost.transform.localScale = transform.localScale;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "PowerUp"){
            poUpDuration =+ 3f;
            Destroy(colisao.gameObject);
        }
    }
}
