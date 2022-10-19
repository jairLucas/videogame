using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootLogic : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        player.canJump = true;
    }

    void OnTriggerExit(Collider other){
        player.canJump  = false;
    }
}
