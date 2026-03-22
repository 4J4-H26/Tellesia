// script pour Nova et les cartes
// auteur : sammuel
// date : 21 Mars 2026

// desc : 

using UnityEngine;

public class Nova : MonoBehaviour
{

    [Header("réf`à la carte")]
    public bool contientLaCarte = false; 

    void OnTriggerEnter(Collider joueur)
    {
        // ** si Nova touche la carte
        if (joueur.CompareTag("Carte"))
        {
            contientLaCarte = true; 
            Destroy(joueur.gameObject); 
        }
    }
}