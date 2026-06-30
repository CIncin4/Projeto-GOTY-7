using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] private float vidaMax;
    [SerializeField] private GameObject bala;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] waypoints;

    private int waypointIndex = 0;
    private float vida;
    private Transform trTiro;
    private GameObject jogador;
    private ContadorPNT display;
    private bool canShoot = false;

    private void Start()
    {
        trTiro = GameObject.FindGameObjectWithTag("BossAim").GetComponent<Transform>();
        jogador = GameObject.FindWithTag("Player");
        vida = vidaMax;
        display = GameObject.Find("DisplayPontos").GetComponent<ContadorPNT>();
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projetil"))
        {
            vida -= collision.GetComponent<Projectile_logic>().dano;
            display.MostarVida(vida, vidaMax);
            if (vida <= 0)
            {
                Destroy(jogador);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (bala != null)
            Instantiate(bala, trTiro.position, trTiro.rotation);

        yield return new WaitForSeconds(0.1f + (10f * (vida / vidaMax)));
        canShoot = true;
    }
}