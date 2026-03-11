// script pour gérer le résultat du tutoriel (niveau 1)
// auteur : sammuel
// date : 07 Mars 2026

using UnityEngine;

public class Puzzle2PorteBarrée : MonoBehaviour
{
    // ** on déclare les variables **

        // booléen clé
        bool aLaCle = false;

    void Start()
    {
        //
    }


    void Update()
    {
        //
    }

    void OnTriggerEnter(Collider other)
    {
        // si le joueur touche un objet avec le tag "clé"
        if (other.CompareTag("clé"))
        {
            aLaCle = true; // le joueur a récupéré la clé
            Debug.Log("Clé récupérée !");

            // on peut désactiver l'objet clé pour qu'il disparaisse
            Destroy(other.gameObject);
        }

        // si le joueur touche une porte
        if (other.CompareTag("porte1"))
        {
            if (aLaCle)
            {
                Debug.Log("Porte déverrouillée !");
                // ici tu peux jouer une animation d'ouverture
                other.gameObject.SetActive(false); // ou animation, ou désactiver le collider
            }
            else
            {
                Debug.Log("La porte est verrouillée. Trouve la clé !");
            }
        }
    }
}
