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

    [Header("les portes")]
    public GameObject porteA;
    public GameObject porteB;
    public GameObject porteC;

    [Header("Animators des portes")]
    public Animator animPorteA;
    public Animator animPorteB;
    public Animator animPorteC;

    [Header("Canvas du puzzle")]
    public GameObject canvasPuzzle;

    [Header("Nova")]
    public Nova2 nova;


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

            if (canvasPuzzle != null)
                canvasPuzzle.SetActive(false);

            if (nova != null)
                nova.SetCanMove(true);

            string tag = "";

            if (indexChoisi == 0) tag = "PorteA";
            else if (indexChoisi == 1) tag = "PorteB";
            else if (indexChoisi == 2) tag = "PorteC";

            OuvrirPorteAvecTag(tag);
        }
        else
        {
            Debug.Log("mauvaise rép");

            mauvaisesReponses++;

            if (mauvaisesReponses >= 2)
            {
                Invoke("RechargerScene", 1.5f);
            }
            else
            {
                //
            }
        }
    }

    void OuvrirPorteAvecTag(string tag)
    {
        Animator anim = TrouverAnimatorParTag(tag);

        if (anim != null)
        {
            Debug.Log("Trigger envoyé à : " + tag);
            anim.SetTrigger("Ouvrir");
        }
        else
        {
            Debug.LogError("Animator introuvable pour : " + tag);
        }
    }

    Animator TrouverAnimatorParTag(string tag)
    {
        GameObject obj = GameObject.FindGameObjectWithTag(tag);

        if (obj != null)
        {
            Animator anim = obj.GetComponent<Animator>();

            if (anim != null)
                return anim;
        }

        Debug.LogError("Animator introuvable pour : " + tag);
        return null;
    }

    void RechargerScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}