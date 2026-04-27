// script pour gérer la question sur l'histoire niveau 2
// auteur : sammuel
// date : 10 Mars 2026

// desc : ** Nova est confronté à une question historique après avoir ouvert la porte du niveau 2
//        les trois portes sont présentées A B C correspondant à trois choix de réponse
//        Nova doit marcher vers la porte correspondant à sa réponse
//        la porte choisie s'ouvre,
//        et si c'est la bonne réponse = le joueur passe au niveau suivant
//        si réponse pas bonne = le niveau est réinitialisé **

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class QuestionHistoire
{
    [TextArea(2, 5)]
    public string question;

    public string[] reponses;

    public int bonneReponse;
}

public class Puzzle3QuestionSurLHistoire : MonoBehaviour
{
    [Header("Questions du niveau 2")]
    public QuestionHistoire[] questions;

    [Header("UI Canvas")]
    public TextMeshProUGUI texteQuestion;
    public TextMeshProUGUI[] textesReponses;

    private int questionActuelle = 0;

    [Header("Images des réponses")]
    public GameObject[] imagesReponses;

    private int mauvaisesReponses = 0;

    void Start()
    {
        AfficherQuestion();
    }

    void AfficherQuestion()
    {
        QuestionHistoire q = questions[questionActuelle];

        texteQuestion.text = q.question;

        for (int i = 0; i < textesReponses.Length; i++)
        {
            textesReponses[i].text = q.reponses[i];
        }
    }

    public void ChoisirReponse(int indexChoisi)
    {
        QuestionHistoire q = questions[questionActuelle];

        for (int i = 0; i < imagesReponses.Length; i++)
        {
            imagesReponses[i].SetActive(false);
        }

        imagesReponses[indexChoisi].SetActive(true);

        if (indexChoisi == q.bonneReponse)
        {
            Debug.Log("bonne rép");

            Invoke("ChargerNiveauSuivant", 1.5f);
        }
        else
        {
            Debug.Log("mauvaise rép");

            mauvaisesReponses++;

            if (mauvaisesReponses >= 2)
            {
                Debug.Log("erreurs, on recommence");
                Invoke("RechargerScene", 1.5f);
            }
            else
            {
                //
            }
        }
    }

    void ChargerNiveauSuivant()
    {
        SceneManager.LoadScene("Niveau3");
    }

    void RechargerScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}