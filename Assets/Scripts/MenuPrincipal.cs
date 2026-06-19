using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SairDoJogo()
    {
        Debug.Log("Você saiu do jogo!");
        Application.Quit(); 
    }
}