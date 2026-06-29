using UnityEngine;

public class ApontarProJogador : MonoBehaviour
{
    private Transform jogadorTr;
    private void Start()
    {
        jogadorTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 rotation = jogadorTr.position - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
