using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    public GameObject prefabObstaculo;
    private Vector3 posicionGenerador = new Vector3(25, 0, 0);
    private float tiempoRetraso = 2;
    private float intervaloRepeticion = 2;
    private ControlJugador scriptControlJugador;

    // Start is called before the first frame update
    void Start()
    {
        scriptControlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
        InvokeRepeating("GenerarObstaculo", tiempoRetraso, intervaloRepeticion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerarObstaculo()
    {
        if (!scriptControlJugador.gameOver)
        {
            Instantiate(prefabObstaculo, posicionGenerador, prefabObstaculo.transform.rotation);
        }

    }
}
