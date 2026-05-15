// script pour gérer la question sur l'histoire niveau 3
// auteur : sammuel
// date : 10 Mars 2026

// desc : ** Nova doit répondre à une question
//        et si la réponse est correcte
//        la porte du puzzle se débloque **

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class QuestionHistoire2
{
    [TextArea(2, 5)]
    public string question;

    public string[] reponses;

    public int bonneReponse;
}

public class Puzzle4QuestionSurLHistoire : MonoBehaviour
{
    [Header("Questions du niveau 3")]
    public QuestionHistoire2[] questions;

    [Header("UI Canvas")]
    public TextMeshProUGUI texteQuestion;
    public TextMeshProUGUI[] textesReponses;

    private int questionActuelle = 0;

    [Header("Images des réponses")]
    public GameObject[] imagesReponses;

    [Header("Canvas du puzzle")]
    public GameObject canvasPuzzle;

    [Header("Nova")]
    public Nova3 nova;

    private bool puzzleBloque = false;
    private static bool puzzleEchoueGlobal = false;

    public int choixJoueur = -1;

    [Header("Porte du puzzle")]
    public GameObject portePuzzle4;

    void Start()
    {
        canvasPuzzle.SetActive(false);

        if (puzzleEchoueGlobal)
        {
            return;
        }

        if (!Puzzle2Cle.cleRamassee)
        {
            nova.puzzleActif = false;
            return;
        }

        nova.puzzleActif = true;

        canvasPuzzle.SetActive(true);

        AfficherQuestion();
    }

    void AfficherQuestion()
    {
        if (puzzleBloque)
        {
            canvasPuzzle.SetActive(false);
            return;
        }

        QuestionHistoire2 q = questions[questionActuelle];

        texteQuestion.text = q.question;

        for (int i = 0; i < textesReponses.Length; i++)
        {
            textesReponses[i].text = q.reponses[i];
        }
    }

    public void ChoisirReponse(int indexChoisi)
    {
        choixJoueur = indexChoisi;

        QuestionHistoire2 q = questions[questionActuelle];

        for (int i = 0; i < imagesReponses.Length; i++)
        {
            imagesReponses[i].SetActive(false);
        }

        if (canvasPuzzle != null)
            canvasPuzzle.SetActive(false);

        if (indexChoisi == q.bonneReponse)
        {
            if (nova != null)
                nova.SetCanMove(true);

            DebarrerPorte();
        }
        else
        {
            puzzleEchoueGlobal = true;

            Invoke("RechargerScene", 20f);
        }
    }

    void DebarrerPorte()
    {
        if (portePuzzle4 != null)
        {
            portePuzzle4.SetActive(false);
        }
    }

    void RechargerScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}