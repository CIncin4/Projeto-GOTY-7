using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string proximoLevel;

    public static float moneyTotal = 0;
    public static float speed = 1f;
    public static float shootingSpeed = 1f;
    public static float damage = 1f;

    public static void ResetarMelhorias()
    {
        moneyTotal = 0;
        speed = 1f;
        shootingSpeed = 1f;
        damage = 1f;
    }
}