using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [SerializeField] private AudioClip colectSFX;
    [SerializeField] private int valor;
    private Transform tr;
    

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coletor"))
        {
            AudioSource.PlayClipAtPoint(colectSFX, tr.position, 1f);
            ContadorPNT.instance.UpdateScore(valor);
            Destroy(this.gameObject);
        }
    }
}

