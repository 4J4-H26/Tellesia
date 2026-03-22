// script pour gérer la porte barrée avec l'objet clé.
// auteur : sammuel
// date : 07 Mars 2026

// desc : le joueur avance, récupère la clé qui disparaît de la scène,
//        ce qui déclenche l’ouverture de la porte et fait apparaître une question historique

using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Puzzle2PorteBarrée : MonoBehaviour
{
    // ** on déclare les variables **

        [Header("réf à la cé")]
        bool laCle = false;

        [Header("réf à la porte")]
        public GameObject porte;

        [Header("question en ui")]
        public GameObject panneauQuestion;

    void Start()
    {
        // ** on cache le panneau ** 
        if (panneauQuestion != null)
        {
            panneauQuestion.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D objet)
    {
        // ** si le joueur touche la clé **
        if (objet.CompareTag("clé"))
        {
            laCle = true;

            // ** on détruit la clé **
            Destroy(objet.gameObject);

            // ** on ouvre cette porte barrée **
            if (porte != null)
            {
                porte.SetActive(false);
            }

            //  ** on affiche la question sur l'histoire **
            if (panneauQuestion != null)
            {
                panneauQuestion.SetActive(true);
            }
        }
    }
}
