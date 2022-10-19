using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;

    public Transform  target;

    public bool atacando;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        comportamiento_enemigo();
    }

    public void comportamiento_enemigo(){
        
        if(Vector3.Distance(transform.position, target.transform.position)>5){
            animator.SetBool("run",false);

            cronometro += 1*Time.deltaTime;
            if(cronometro>=4){
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
                    transform.Translate(Vector3.forward*1*Time.deltaTime);
                    animator.SetBool("walk",true);
                    break;
            }


        }else{
            if(Vector3.Distance(transform.position, target.transform.position)>1 && !atacando){
                var direccion_jugador = target.transform.position - transform.position;
                direccion_jugador.y = 0;
                var rotation = Quaternion.LookRotation(direccion_jugador);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                animator.SetBool("walk",false);
                animator.SetBool("run",true);
                transform.Translate(Vector3.forward*2*Time.deltaTime);
                animator.SetBool("attack",false);
            }else{
            animator.SetBool("walk",false);
            animator.SetBool("run",false);
            animator.SetBool("attack",true);
            atacando = true;
            
        }
        }

        
    }

    public void final_animacion(){
        animator.SetBool("attack",false);
        atacando = false;
    }


    void seek(){
        var direccion_jugador = target.transform.position - transform.position;
        direccion_jugador.y = 0;
        var rotation = Quaternion.LookRotation(direccion_jugador);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
        animator.SetBool("walk",false);
        animator.SetBool("run",true);
        transform.Translate(Vector3.forward*2*Time.deltaTime);
    }
}
