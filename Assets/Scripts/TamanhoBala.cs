using UnityEngine;

public class TamanhoBala : MonoBehaviour
{
    private Transform tr;
    private Projectile_logic pl;
    private void Start()
    {
        pl = GetComponent<Projectile_logic>();
        tr = GetComponent<Transform>();
        tr.localScale = new Vector3(0.04f + pl.dano/420, 0.05f + pl.dano/240, 0);
    }
}
