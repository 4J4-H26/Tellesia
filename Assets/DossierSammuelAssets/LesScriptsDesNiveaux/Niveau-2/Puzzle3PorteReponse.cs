// script pour gérer la question sur l'histoire niveau 2 - PORTE REPONSE
// auteur : sammuel
// date : 10 Mars 2026

// desc : ** script qui est attaché à chaque porte correspondant à un choix A, B ou C
//        et quand le joueur (Nova) touche la porte, elle appelle le script de la question pour 
//        vérifier si la réponse est correcte et ouvrir la porte correspondante (3ème porte) **

using UnityEngine;

public class Puzzle3PorteReponse : MonoBehaviour
{
    // ** on déclare les variables **

        // ** on a nos choix de réponses **
        public enum lettresChoixDeRep { A, B, C }

            [Header("réponse")]
            public lettresChoixDeRep reponse;

            [Header("script de la question sur l'histoire puzzle au niv 2")]
            public Puzzle3QuestionSurLHistoire questionScript;

    void OnTriggerEnter(Collider joueur)
    {
        if (joueur.CompareTag("Nova"))
        {
            Nova novaScript = joueur.GetComponent<Nova>();

            // ** on souhaite vérifier que Nova a la carte en main **
            if (novaScript != null && novaScript.contientLaCarte) 
            {
                questionScript.ChoisirReponseQH1(reponse.ToString());
            }
            else
            {
               //
            }
        }
    }
}