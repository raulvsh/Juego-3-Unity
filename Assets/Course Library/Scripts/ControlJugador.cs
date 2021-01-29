using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody rbJugador;
    private Animator animJugador;

    public float fuerzaSalto = 10;
    public float modGravedad = 2;
    public bool estaEnElSuelo = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        Physics.gravity *= modGravedad;
        animJugador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo)
        {
            //transform.Translate(Vector3.up * Time.deltaTime);
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnElSuelo = false;
            animJugador.SetTrigger("Jump_trig");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnElSuelo = true;
        }
        else if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
