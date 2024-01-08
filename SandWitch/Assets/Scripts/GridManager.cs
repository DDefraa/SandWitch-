using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSize = 4;
    public float cellSize = 1.0f;
    public Vector3 gridOffset = Vector3.zero;
    public GameObject cellPrefab; 

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

               
                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);

               

                
                cell.AddComponent<CellInteraction>();
            }
        }
    }
}
