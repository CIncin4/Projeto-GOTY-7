using UnityEngine;
using UnityEngine.SceneManagement;

public class SaidaFase : MonoBehaviour
{
    [Header("Configuração de Fluxo")]
    [SerializeField] private string esteProximoLevel;

    private void OnTriggerExit2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Player"))
        {
            if (!ShipControl.instance.restartCheck)
            {
                ShipControl.instance.Stop();
                Invoke("PassarFase", 2f);
            }
            else
            {
                ShipControl.instance.restartCheck = false;
            }
        }
    }

    private void PassarFase()
    {
        GameManager.proximoLevel = esteProximoLevel;
        SceneManager.LoadScene("Loja");
    }
}