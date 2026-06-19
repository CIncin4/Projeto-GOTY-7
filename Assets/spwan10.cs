using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawner : MonoBehaviour
{
    [Header("Configurações do Spawn")]
    [Tooltip("Prefab do objeto ou personagem que será spawnado")]
    public GameObject prefabToSpawn;

    [Tooltip("Quantidade total de objetos a spawnar")]
    public int totalSpawns = 10;

    [Tooltip("Duração total do spawn em segundos")]
    public float totalDuration = 20f;

    [Header("Área de Spawn")]
    [Tooltip("Centro da área de spawn")]
    public Vector3 spawnAreaCenter;

    [Tooltip("Tamanho da área de spawn (X, Y, Z)")]
    public Vector3 spawnAreaSize = new Vector3(50f, 20f, 50f);

    [Header("Opcional")]
    [Tooltip("Se verdadeiro, os objetos spawnados serão filhos deste spawner")]
    public bool spawnAsChildren = false;

    private int _spawnedCount = 0;

    void Start()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogError("SpaceSpawner: Nenhum prefab foi atribuído! Arraste um prefab no Inspector.");
            return;
        }

        if (totalSpawns <= 0)
        {
            Debug.LogWarning("SpaceSpawner: totalSpawns deve ser maior que zero.");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        float fixedInterval = totalDuration / totalSpawns;

        for (int i = 0; i < totalSpawns; i++)
        {
            Vector3 randomPosition = GetRandomPositionInArea();

            GameObject spawned = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

            if (spawnAsChildren)
            {
                spawned.transform.SetParent(transform);
            }

            _spawnedCount++;

            yield return new WaitForSeconds(fixedInterval);
        }

        Debug.Log($"SpaceSpawner: Spawn completo! Total spawnado: {_spawnedCount}");
    }

    Vector3 GetRandomPositionInArea()
    {
        float x = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float y = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
        float z = Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f);

        return spawnAreaCenter + new Vector3(x, y, z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.3f);
        Gizmos.DrawCube(spawnAreaCenter, spawnAreaSize);
    }
}