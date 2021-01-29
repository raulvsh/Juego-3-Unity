using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    private Rigidbody rbJugador;
    private Animator animJugador;
    private AudioSource sonidoJugador;

    public float fuerzaSalto = 10;
    public float modGravedad = 2;
    public bool estaEnElSuelo = true;
    public bool gameOver;

    public ParticleSystem explosion;
    public ParticleSystem polvareda;

    public AudioClip sonidoSalto;
    public AudioClip sonidoChoque;



    // Start is called before the first frame update
    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        Physics.gravity *= modGravedad;
        animJugador = GetComponent<Animator>();
        sonidoJugador = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo && !gameOver)
        {
            //transform.Translate(Vector3.up * Time.deltaTime);
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnElSuelo = false;
            animJugador.SetTrigger("Jump_trig");
            polvareda.Stop();
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnElSuelo = true;
            polvareda.Play();

        }
        else if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            animJugador.SetBool("Death_b", true);
            //animJugador.SetTrigger("Death_b");
            animJugador.SetInteger("DeathType_int", 1);
            explosion.Play();
            polvareda.Stop();
            sonidoJugador.PlayOneShot(sonidoChoque, 1.0f);

        }
    }
}
