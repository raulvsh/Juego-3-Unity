using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour
{
    private Vector3 posInicio;
    private float anchoRepeticion;
    // Start is called before the first frame update
    void Start()
    {
        posInicio = transform.position;
        anchoRepeticion = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < posInicio.x - anchoRepeticion)
        {
            transform.position = posInicio;
        }
    }
}
