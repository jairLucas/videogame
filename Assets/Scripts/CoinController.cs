using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinController : MonoBehaviour
{
    public int numDeObjetivos;
    int numDeRecogidos = 0;
    public TextMeshProUGUI texto;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("Coin").Length;
        texto.text = "Monedas Recogidas : " + numDeRecogidos + "\n Monedas Restantes : " + numDeObjetivos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Coin"){
            Destroy(other.transform.gameObject);
            numDeRecogidos++;
            numDeObjetivos--;
            texto.text = "Monedas Recogidas : " + numDeRecogidos + "\n Monedas Restantes : " + numDeObjetivos;
            if (numDeObjetivos <= 0){
                texto.text = "Misión Completada";
                button.SetActive(true);
            }
        }
    }
}
