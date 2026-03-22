// script pour gérer la question sur l'histoire niveau 3
// auteur : sammuel
// date : 10 Mars 2026

// desc : nova doit répondre à une question
//        et si la réponse est correcte
//        la porte du puzzle se débloque

using UnityEngine;

public class Puzzle4QuestionSurLHistoire : MonoBehaviour
{
    // ** on déclare les variables **

        [Header("réf porte")]
        public GameObject portepuzzle4;

        [Header("string")]
        public string reponsepuzzle4 = "2"; 

    public void Repondre(string reponseJoueur)
    {
        if (reponseJoueur == reponsepuzzle4)
        {
            DebarrerPorte();
        }
        else
        {
           //
        }
    }

    private void DebarrerPorte()
    {
        portepuzzle4.SetActive(false);
    }

}
