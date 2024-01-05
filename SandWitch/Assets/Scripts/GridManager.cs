using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSize = 4;
    public float cellSize = 1.0f;
    public Vector3 gridOffset = Vector3.zero;
    public GameObject cellPrefab;  // Trascina il tuo prefab della cella qui

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                // Calcola la posizione della cella con l'offset
                Vector3 cellPosition = new Vector3(col * cellSize, 0, row * cellSize) + gridOffset;

                // Crea una cella utilizzando il prefab
                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);

                // Personalizza l'aspetto della cella come desiderato

                // Aggiungi uno script per gestire l'interazione con la cella
                cell.AddComponent<CellInteraction>();
            }
        }
    }
}
