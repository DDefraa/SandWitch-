using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Ingredient[] ingredients;
    public Transform[] slots;
    public GameObject resetButton;
    public GameObject undoButton;

    private Ingredient selectedIngredient;
    private Ingredient lastIngredient;

    private GameObject selectedObject;

    public bool isDragging = false;

    private void Start()
    {
        // Inizializza le variabili di gioco
        selectedIngredient = null;
        lastIngredient = null;
    }

    private void Update()
    {
        // Rileva il movimento swipe del giocatore
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Controlla se il tocco ha colpito un oggetto selezionabile
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        selectedObject = hit.transform.gameObject;
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Ended:
                    // Sposta l'oggetto solo quando il dito viene rilasciato
                    if (isDragging && selectedObject != null)
                    {
                        // Effettua la verifica se la posizione finale coincide con un altro oggetto
                        Collider[] colliders = Physics.OverlapSphere(selectedObject.transform.position, 0.5f);
                        bool canMove = true;

                        foreach (var collider in colliders)
                        {
                            if (collider.gameObject != selectedObject)
                            {
                                // La posizione finale coincide con un altro oggetto, non muovere
                                canMove = true;
                                break;
                            }
                        }

                        if (canMove)
                        {
                            isDragging = false;
                            selectedObject = null;
                        }
                       
                    }
                    break;
            }
        }

        // Se lo stato di trascinamento è attivo, muovi l'oggetto
        if (isDragging && selectedObject != null)
        {
            // Muovi l'oggetto selezionato in base al movimento swipe
            Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Limita lo spostamento massimo a 3 unità lungo gli assi x e z
            float newX = Mathf.Clamp(selectedObject.transform.position.x + touchDeltaPosition.x * Time.deltaTime, -3f, 3f);
            float newZ = Mathf.Clamp(selectedObject.transform.position.z + touchDeltaPosition.y * Time.deltaTime, -3f, 3f);

            // Applica la traslazione limitata
            selectedObject.transform.position = new Vector3(newX, selectedObject.transform.position.y, newZ);
        }
    }

}
