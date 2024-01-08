using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToInstantiate;  
    public Transform[] spawnPoints;              

    void Start()
    {
        InstantiatePrefabs();
    }

    void InstantiatePrefabs()
    {
    

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
