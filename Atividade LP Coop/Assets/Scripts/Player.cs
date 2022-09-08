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
    

    void Start()
    {
        colldown = 0f;
        currentSide = 1f;
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();              
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector2(currentSide,1f);
        Anima();
        Debug.Log(InputHorizontal);
        Ataca();
    }

    void FixedUpdate(){
        Movimenta();
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
            Vector2 direction = new Vector2(InputHorizontal * speed, InputVertical * speed);
            direction.Normalize();
            rb.velocity = direction;
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
                    axe.GetComponent<Rigidbody2D>().velocity = new Vector2 (2*currentSide,0);                   
                    colldown = 0.5f;                     
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
}
