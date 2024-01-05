using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInteraction : MonoBehaviour
{
    private Renderer cellRenderer;
    private Color originalColor;

    private void Start()
    {
        // Memorizza il colore originale della cella
        cellRenderer = GetComponent<Renderer>();
        originalColor = cellRenderer.material.color;
    }

    private void OnMouseDown()
    {
        // Chiamato quando la cella viene cliccata
        HandleInteraction();
    }

    private void Update()
    {
        // Controllo del tocco per dispositivi mobili
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Verifica se il tocco colpisce questa cella
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    HandleInteraction();
                }
            }
        }
    }

    private void HandleInteraction()
    {
        // Logica per l'interazione con la cella
        Debug.Log("Cella toccata: " + transform.position);

        // Cambia il colore della cella in rosso
        cellRenderer.material.color = Color.red;

        // Aggiungi qui la logica per ulteriori azioni quando una cella viene toccata
    }

    // Metodo per ripristinare il colore originale della cella
    public void ResetColor()
    {
        cellRenderer.material.color = originalColor;
    }
}
