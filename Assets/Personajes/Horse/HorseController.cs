using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;
    public Transform  player;

    public float speed = 4.0f;
    public float accuracy = 10.0f; 
    
    public int radio_peligroso = 10;
    public int radio_seguro = 50;

    public bool endangered = false;
    


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)<radio_peligroso){
            if(!(Vector3.Distance(transform.position, player.transform.position)>radio_seguro)){
                flee();
            }
        }else{
            wander();
        }
    }

    void wander(){
        animator.SetBool("run",false);
        cronometro += 1*Time.deltaTime;
        if(cronometro>=3){
            rutina = Random.Range(0,2);
            cronometro = 0;
        }
        switch(rutina){
            case 0:
                animator.SetBool("walk",false);
                break;
            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                float walk_speed = speed*0.5f;
                transform.Translate(Vector3.forward*walk_speed*Time.deltaTime);
                animator.SetBool("walk",true);
                break;
        }
    }

    void flee(){
        var direccion = player.transform.position - transform.position;
        direccion.y = 0;
        var rotation = Quaternion.LookRotation(-direccion);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
        animator.SetBool("walk",false);
        animator.SetBool("run",true);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}


