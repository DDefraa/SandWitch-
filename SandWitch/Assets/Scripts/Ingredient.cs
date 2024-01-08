using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int id;
    public bool isFlipped;

    // Implementa il flip dell'ingrediente
    public void Flip()
    {
        // Logica per il flip dell'ingrediente
        isFlipped = !isFlipped;
        // Aggiorna l'aspetto grafico dell'ingrediente (sprite o rotazione)
    }
}
