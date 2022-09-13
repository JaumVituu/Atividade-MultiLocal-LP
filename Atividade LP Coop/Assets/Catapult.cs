using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public GameObject Rock;
    public float speed;
    float direcao;
    public LayerMask inimigo;
    float cooldown;

    void Start(){
        cooldown = 0f;      
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        transform.localScale = new Vector2(1*direcao,1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position+new Vector3(0.2f,0,0), new Vector2(-direcao,0), Mathf.Infinity,inimigo);
        if(hit.collider != null){
            Debug.Log("Acertou: " + hit.collider.name);
            if(cooldown <= 0f && (hit.collider.tag == "Leo" || hit.collider.tag == "Felipe")){
            GameObject Projetile = Instantiate(Rock, transform.position, Quaternion.identity);
            Destroy(Projetile, 3);
            Projetile.GetComponent<Rigidbody2D>().velocity = new Vector2(speed*-direcao,0);
            Projetile.GetComponent<Rigidbody2D>().angularVelocity = 500f;
            cooldown = 1f;
            GetComponent<Animator>().SetBool("Tiro",true);
            }
            else{
                GetComponent<Animator>().SetBool("Tiro",false);
            }
        }
        else{
            Debug.Log("Não Acertou");
        }

        
        
        if(this.gameObject.transform.position.x < GameObject.Find("Marmita").gameObject.transform.position.x){
            direcao = 1;        
        }
        else{
            direcao = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "Leo" || colisao.gameObject.tag == "Felipe"){
            Destroy(gameObject);
        }
    }
}
