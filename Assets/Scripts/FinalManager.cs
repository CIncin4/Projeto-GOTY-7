using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    [Header("Componentes da UI")]
    public Image fundoImagem;
    public TextMeshProUGUI textoDialogo;
    public GameObject painelDialogo;

    [Header("Fading Final")]
    public CanvasGroup fadeOverlayGroup;
    public float duracaoFadeOut = 1.5f;

    private AudioSource musicaFundo;
    private float volumeInicialAudio;

    [Header("Configurações")]
    public float velocidadeDigitacao = 0.05f;
    public float delayInicial = 1f;

    [Header("História Final")]
    public Sprite[] imagens;
    [TextArea(3, 5)]
    public string[] dialogos;

    private int indiceAtual = 0;
    private bool podeAvancar = false;
    private bool estaEscrevendo = false;

    void Start()
    {
        fadeOverlayGroup.alpha = 0f;
        fadeOverlayGroup.gameObject.SetActive(false);

        musicaFundo = Object.FindFirstObjectByType<AudioSource>();
        if (musicaFundo != null)
        {
            volumeInicialAudio = musicaFundo.volume;
        }

        StartCoroutine(ExibirCena(indiceAtual));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (estaEscrevendo)
            {
                StopAllCoroutines();
                textoDialogo.text = dialogos[indiceAtual];
                estaEscrevendo = false;
                podeAvancar = true;
            }
            else if (podeAvancar)
            {
                AvancarCena();
            }
        }
    }

    void AvancarCena()
    {
        indiceAtual++;
        if (indiceAtual < imagens.Length)
        {
            StartCoroutine(ExibirCena(indiceAtual));
        }
        else
        {
            StartCoroutine(FadeOutAndLoadMenu());
        }
    }

    IEnumerator FadeOutAndLoadMenu()
    {
        podeAvancar = false;

        fadeOverlayGroup.gameObject.SetActive(true);
        fadeOverlayGroup.blocksRaycasts = true;

        float counter = 0f;

        while (counter < duracaoFadeOut)
        {
            counter += Time.deltaTime;
            float progresso = counter / duracaoFadeOut;

            fadeOverlayGroup.alpha = Mathf.Lerp(0f, 1f, progresso);

            if (musicaFundo != null)
            {
                musicaFundo.volume = Mathf.Lerp(volumeInicialAudio, 0f, progresso);
            }

            yield return null;
        }

        fadeOverlayGroup.alpha = 1f;

        if (musicaFundo != null)
        {
            Destroy(musicaFundo.gameObject);
        }

        GameManager.moneyTotal = 0;
        GameManager.speed = 1f;
        GameManager.shootingSpeed = 1f;
        GameManager.damage = 1f;

        SceneManager.LoadScene(0);
    }

    IEnumerator ExibirCena(int index)
    {
        podeAvancar = false;
        textoDialogo.text = "";
        fundoImagem.sprite = imagens[index];
        painelDialogo.SetActive(false);
        yield return new WaitForSeconds(delayInicial);
        painelDialogo.SetActive(true);
        StartCoroutine(DigitarTexto(dialogos[index]));
    }

    IEnumerator DigitarTexto(string frase)
    {
        estaEscrevendo = true;
        textoDialogo.text = "";
        foreach (char letra in frase.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }
        estaEscrevendo = false;
        podeAvancar = true;
    }
}