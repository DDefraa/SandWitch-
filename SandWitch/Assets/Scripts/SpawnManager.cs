using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToInstantiate;  // Trascina i tuoi prefabbricati qui
    public Transform[] spawnPoints;              // Trascina i transform degli spawn points qui

    void Start()
    {
        InstantiatePrefabs();
    }

    void InstantiatePrefabs()
    {
        //if (prefabsToInstantiate.Length != 4 || spawnPoints.Length != 4)
        //{
        //    Debug.LogError("Devi fornire esattamente 4 prefabbricati e 4 punti di spawn.");
        //    return;
        //}

        for (int i = 0; i < 4; i++)
        {
            // Ottieni il prefab e il punto di spawn dall'array
            GameObject prefab = prefabsToInstantiate[i];
            Transform spawnPoint = spawnPoints[i];

            // Verifica che il prefab e il punto di spawn non siano nulli
            if (prefab != null && spawnPoint != null)
            {
                // Istanzia il prefab alla posizione del punto di spawn
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.LogError("Prefab o punto di spawn mancante alla posizione: " + i);
            }
        }
    }
}
