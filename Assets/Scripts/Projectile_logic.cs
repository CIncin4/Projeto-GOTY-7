using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile_logic : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeSpan;
    public float dano;

    private void Awake()
    {
        dano = ShipControl.instance.damage * 10;
        StartCoroutine(Lifespan());
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Destroy(this.gameObject);
    }

    private void Update(){
        transform.Translate(0, (bulletSpeed + (bulletSpeed * (ShipControl.instance.speed / 5))) * Time.deltaTime, 0);
    }

    private IEnumerator Lifespan(){
        yield return new WaitForSeconds(bulletLifeSpan);
        Destroy(this.gameObject);
    }
}
