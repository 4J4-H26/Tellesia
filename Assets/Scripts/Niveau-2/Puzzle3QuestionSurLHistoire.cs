// script pour gérer la question sur l'histoire niveau 2
// auteur : sammuel
// date : 10 Mars 2026

// desc : ** Nova est confronté à une question historique après avoir ouvert la porte du niveau 2
//        les trois portes sont présentées A B C correspondant à trois choix de réponse
//        Nova doit marcher vers la porte correspondant à sa réponse
//        la porte choisie s'ouvre,
//        et si c'est la bonne réponse = le joueur passe au niveau suivant
//        si réponse pas bonne = le niveau est réinitialisé **

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle3QuestionSurLHistoire : MonoBehaviour
{

    // ** on déclare les variables **

        // c, la 3ème porte est la bonne
        public enum Lettre { A, B, C }

        [Header("qd c'est la bonne réponse du puzzle")]
        public Lettre bonneReponse = Lettre.C;

        [Header("réf aux portes")]
        public GameObject porteA;
        public GameObject porteB;
        public GameObject porteC;


    public void ChoisirReponseQH1(string reponseChoisieQH1)
    {
        switch (reponseChoisieQH1)
        {
            case "A":
                porteA.SetActive(false);
                break;
            case "B":
                porteB.SetActive(false);
                break;
            case "C":
                porteC.SetActive(false);
                break;
        }

        // ** on charge le niveau suivant si on obtient la bonne réponse **
        if (reponseChoisieQH1 == bonneReponse.ToString())
        {
            SceneManager.LoadScene("Niveau3");
        }
        else
        {
            // ** on recharge le niv 2 en cas d'échec... **
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
