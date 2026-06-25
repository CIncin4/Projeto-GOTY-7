using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ContadorPNT : MonoBehaviour
{
    public static ContadorPNT instance;

    private TextMeshProUGUI txmp;
<<<<<<< Updated upstream
    public int maxPontos;
    public int pontos;
=======
    public int pontos;
    public float money;
>>>>>>> Stashed changes

    void Start(){
        txmp = GetComponent<TextMeshProUGUI>();
    }

<<<<<<< Updated upstream
    private void Update(){
        txmp.text = pontos + " kg";
=======
    public void UpdateScore(int points){
        pontos += points;
        txmp.text = pontos * 100 + " kg";
>>>>>>> Stashed changes
    }
}
