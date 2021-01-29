using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverALaIzquierda : MonoBehaviour
{
    private float velocidad = 20;
    private float limiteIzquierdo = -15;
    private ControlJugador scriptControlJugador;

    // Start is called before the first frame update
    void Start()
    {
        scriptControlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptControlJugador.gameOver)
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }        
        if(transform.position.x < limiteIzquierdo && gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}
