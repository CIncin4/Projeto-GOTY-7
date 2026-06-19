using UnityEngine;

public class SpawnerInimigos : MonoBehaviour
{
    [Header("Configurações do Spawner")]
    public GameObject prefabNaveInimiga;
    public float intervaloDeSpawn = 3f;

    [Header("Locais de Nascimento")]
    public Transform[] pontosDeSpawn; 

    void Start()
    {
        InvokeRepeating(nameof(GerarInimigo), 2f, intervaloDeSpawn);
    }

    void GerarInimigo()
    {
        if (pontosDeSpawn.Length == 0) return;

        int indexSorteado = Random.Range(0, pontosDeSpawn.Length);
        Transform pontoEscolhido = pontosDeSpawn[indexSorteado];

        Instantiate(prefabNaveInimiga, pontoEscolhido.position, pontoEscolhido.rotation);
    }
}