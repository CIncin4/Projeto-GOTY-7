using System.Collections;
using UnityEngine;
using Unity.Mathematics;

public class BalaBoss : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Vector3 direction;
    private float ang;
    void Start()
    {
        ang = GameObject.FindWithTag("BossAim").GetComponent<Transform>().eulerAngles.z / 180 * math.PI;
        StartCoroutine(BulletLifespan());
    }

    private IEnumerator BulletLifespan()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
    }
}
