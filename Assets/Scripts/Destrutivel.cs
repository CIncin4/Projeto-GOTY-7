using UnityEngine;

public class Destrutivel : MonoBehaviour
{
    [SerializeField] private AudioClip destroySFX;
    [SerializeField] private GameObject drop;
    [SerializeField] private float dropAmount;
    [SerializeField] private float vida;
    private Transform tr;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projetil"))
        {
            vida -= collision.GetComponent<Projectile_logic>().dano;
            if (vida <= 0)
            {
                if (destroySFX != null)
                    AudioSource.PlayClipAtPoint(destroySFX, tr.position, 1f);
                if (drop != null)
                for (int i = 0; i < dropAmount; i++) Instantiate(drop, tr.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
