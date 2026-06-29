using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LojaManager : MonoBehaviour
{
    [SerializeField] private float custoMelhoria;
    public void ComprarArtilharia()
    {
        if (custoMelhoria <= display.money)
        {
            display.RemoveMoney(custoMelhoria);
            custoMelhoria = custoMelhoria + 1000;
            ShipControl.instance.shootingSpeed++;
            preco.text = "Custo: " + custoMelhoria + "$";
        }
    }
    public void ComprarVelocidade()
    {
        if (custoMelhoria <= display.money)
        {
            display.RemoveMoney(custoMelhoria);
            custoMelhoria = custoMelhoria + 1000;
            ShipControl.instance.speed++;
            preco.text = "Custo: " + custoMelhoria + "$";
        }
    }
        public void ComprarCanhao()
    {
        if (custoMelhoria <= display.money)
        {
            display.RemoveMoney(custoMelhoria);
            custoMelhoria = custoMelhoria + 1000;
            ShipControl.instance.damage++;
            preco.text = "Custo: " + custoMelhoria + "$";
        }
    }

    private ContadorPNT display;
    [SerializeField] private TextMeshProUGUI preco;
    private void Awake()
    {
        display = GameObject.Find("DisplayPontos").GetComponent<ContadorPNT>();
        display.ConvertToMoney();
        preco.text = "Custo: " + custoMelhoria + "$";
    }
    

    public void IrParaProximoPlaneta()
    {
        SceneManager.LoadScene(GameManager.proximoLevel);
        ShipControl.instance.Reset();
    }
}