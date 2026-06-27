using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Timer : MonoBehaviour
{
    [SerializeField] private float tempoFase;
    private float tempoAtual;
    private bool isStopped;

    void Update()
    {
        if (!isStopped)
        {
            if (tempoAtual > 0)
                tempoAtual -= Time.deltaTime;
            else if (tempoAtual < 0)
            {
                isStopped = true;
                tempoAtual = 0;
                ShipControl.instance.Restart();
            }
        }
        int minute = Mathf.FloorToInt(tempoAtual / 60);
        int seconds = Mathf.FloorToInt(tempoAtual % 60);
        GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minute, seconds);
    }

    public void RestartTimer()
    {
        tempoAtual = tempoFase;
        isStopped = false;
    }

    public void Stop()
    {
        isStopped = true;
    }

    public void Go()
    {
        isStopped = false;
    }
}
