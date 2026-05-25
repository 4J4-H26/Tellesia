using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class QuestionHistoire3
{
    [TextArea(2, 5)]
    public string question;

    public string[] reponses;

    public int bonneReponse;
}

public class Puzzle5QuestionSurLHistoire : MonoBehaviour
{
    [Header("Questions du niveau 3")]
    public QuestionHistoire3[] questions;

    [Header("UI Canvas")]
    public TextMeshProUGUI texteQuestion;
    public TextMeshProUGUI[] textesReponses;

    private int questionActuelle = 0;

    [Header("Images des réponses")]
    public GameObject[] imagesReponses;

    [Header("Canvas du puzzle")]
    public GameObject canvasPuzzle;

    //[Header("Nova")]
    //public Nova5 nova;

    private bool puzzleBloque = false;
    private static bool puzzleEchoueGlobal = false;

    public int choixJoueur = -1;
    private bool puzzleTermine = false;
    void Start()
    {
        if (canvasPuzzle != null)
            canvasPuzzle.SetActive(false);

        if (puzzleEchoueGlobal)
            return;

        //if (nova != null)
        //    nova.puzzleActif = true;
    }

    public void OuvrirPuzzle()
    {
        if (puzzleTermine) return;
        canvasPuzzle.SetActive(true);
        AfficherQuestion();
    }

    void AfficherQuestion()
    {
        if (puzzleBloque || puzzleTermine)
        {
            canvasPuzzle.SetActive(false);
            return;
        }

        QuestionHistoire3 q = questions[questionActuelle];

        texteQuestion.text = q.question;

        for (int i = 0; i < textesReponses.Length; i++)
        {
            textesReponses[i].text = q.reponses[i];
        }
    }

    public void ChoisirReponse(int indexChoisi)
    {
        choixJoueur = indexChoisi;

        QuestionHistoire3 q = questions[questionActuelle];

        for (int i = 0; i < imagesReponses.Length; i++)
        {
            imagesReponses[i].SetActive(false);
        }

        if (canvasPuzzle != null)
            canvasPuzzle.SetActive(false);

        if (indexChoisi == q.bonneReponse)
        {
            puzzleTermine = true;
            //if (nova != null)
            //    nova.SetCanMove(true);
        }
        else
        {
            puzzleEchoueGlobal = true;
            Invoke("RechargerScene", 0.5f);
        }
    }

    void RechargerScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}