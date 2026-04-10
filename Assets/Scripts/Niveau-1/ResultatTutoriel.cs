// script pour gérer le résultat du tutoriel (niveau 1)
// auteur : sammuel
// date : 08 Mars 2026

// desc : ** un levier au début **

using UnityEngine;

public class ResultatTutoriel : MonoBehaviour
{
    public GameObject LevierDeCommande1;
    public GameObject LevierDeCommande2;
    public GameObject LevierDeCommande3;

    public bool porteActive = false;

    bool messageAffiche = false;

    void Update()
    {
        if (reussite())
        {
            if (!porteActive)
                Debug.Log("Porte activée !");

            porteActive = true;
        }
        else
        {
            if (!messageAffiche)
            {
                // Debug.Log("Il manque des leviers");
                messageAffiche = true;
            }
        }
    }

    bool reussite()
    {
        return LevierDeCommande1.CompareTag("reussit") &&
               LevierDeCommande2.CompareTag("reussit") &&
               LevierDeCommande3.CompareTag("reussit");
    }
}