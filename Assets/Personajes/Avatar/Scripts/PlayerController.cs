using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedRotation = 200.0f;
    private Animator animator;
    public float x,y;

    //Variables para el salto
    public Rigidbody rb;
    public float jumpForce = 8f;
    public bool canJump;

    //Variables agachado
    public float speedInitial;
    public float speedCrouch;

    //Variables del ataque
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoDeGolpe;

    void Start()
    {
        canJump = false;
        animator = GetComponent<Animator>();

        speedInitial = speed;
        speedCrouch = speed*0.5f;
    }

    void FixedUpdate(){
        if(!estoyAtacando){
            transform.Rotate(0,x*Time.deltaTime*speedRotation,0);
            transform.Translate(0,0,y*Time.deltaTime*speed);
        }
        if(avanzoSolo){
            rb.velocity = transform.forward*impulsoDeGolpe;
        }
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Mouse1) && canJump && !estoyAtacando){
            animator.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY",y);
        

        if(canJump){
            if(!estoyAtacando){
                if(Input.GetKeyDown(KeyCode.Space)){
                    animator.SetBool("salte",true);
                    rb.AddForce(new Vector3(0,jumpForce,0),ForceMode.Impulse);
                }
                if(Input.GetKey(KeyCode.LeftControl)){
                    animator.SetBool("agachado",true);
                    speed = speedCrouch;
                }else{
                    animator.SetBool("agachado",false);
                    speed = speedInitial;
                }
            }
            animator.SetBool("tocoSuelo",true);
        }else{
            FallingDown();  
        }
    }

    public void FallingDown(){
        animator.SetBool("salte",false);
        animator.SetBool("tocoSuelo",false);
    }

    public void DejeDeGolpear(){
        estoyAtacando = false;
    }
    public void AvanzoSolo(){
        avanzoSolo = true;
    }
    public void DejoDeAvanzar(){
        avanzoSolo = false;
    }
}
