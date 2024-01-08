using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int id;
    public bool isFlipped;

    
    public void Flip()
    {
        
        isFlipped = !isFlipped;
        
    }
}
