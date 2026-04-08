//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet d'écrire progressivement les textes de dialogue et de détecter
// quand le joueur clique sur le bouton pour passer à la ligne suivante
//------------------------------------------*

using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public enum QuiParle
{
    Nova,
    Ella,
    Vide
}

[System.Serializable]
public class LignesDialogue
{
    public QuiParle speaker;
    public string text;
}

[System.Serializable]
public class Segment
{
    public int[] lignes;
}

public class ScriptDialogue : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textComponent;
    public LignesDialogue[] lines;
    public float[] delaisParLigne;
    public float textSpeed;
    public Button buttonNext;

    private int index;

    public TextMeshProUGUI nom;

    public Nova nova;

    private bool dialogueActif = false;

    [Header("Programmes de dialogues séparés")]
    public Segment[] segments;
    public float[] delaisSegment;

    [Header("Options Canvas")]
    public float delaiReapparition = 5f;                  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        dialogueCanvas.SetActive(true);

        if (nova != null) nova.SetCanMove(false);

        StartDialogue();

        buttonNext.onClick.AddListener(NextButtonClicked);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActif)
        {
            NextButtonClicked();
        }
    }
    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    //------------------------------------------*
    // Fonction StartDialogue
    // Description : Cette fonction permet de commencer la fonction 
    // (plus tard déclencher avec une interaction/event)
    //------------------------------------------*
    public void StartDialogue()
    {
        index = 0;
        dialogueActif = true;

        if (nova != null) nova.SetCanMove(false);

        StartCoroutine(TypeLine()); 
    }

  
 


    void EndSegment(int segmentIndex)
    {
        dialogueActif = false;
        if (nova != null) nova.SetCanMove(true);

        if (segmentIndex + 1 < segments.Length)
        {
            StartCoroutine(SegmentProgrammé(segmentIndex + 1));
        }
        else
        {
            dialogueCanvas.SetActive(false);
        }
    }
    IEnumerator SegmentProgrammé(int segmentIndex)
    {
        if (delaisSegment != null && segmentIndex < delaisSegment.Length)
            yield return new WaitForSeconds(delaisSegment[segmentIndex]);

        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(true);

        for (int i = 0; i < segments[segmentIndex].lignes.Length; i++)
        {
            index = segments[segmentIndex].lignes[i];
            if (!string.IsNullOrEmpty(lines[index].text))
                yield return StartCoroutine(TypeLine());
        }

        EndSegment(segmentIndex);
    }

    //------------------------------------------*
    // Fonction TypeLine()
    // Description : Cette fonction permet d'écrire le texte progressivement 
    // un caractère à la fois dans les strings
    //------------------------------------------*
    IEnumerator TypeLine()
    {
        string currentText = lines[index].text;
        QuiParle currentSpeaker = lines[index].speaker;

        if (string.IsNullOrWhiteSpace(currentText) || currentSpeaker == QuiParle.Vide)
        {
            dialogueCanvas.SetActive(false);
            yield break;
        }

        textComponent.text = "";
        nom.text = "";

        dialogueCanvas.SetActive(true);

        RectTransform nomRect = nom.GetComponent<RectTransform>();
        Vector2 pos = nomRect.anchoredPosition;

        if (currentSpeaker == QuiParle.Ella)
        {
            pos.x = -64.4f;
        }
        else if (currentSpeaker == QuiParle.Nova)
        {
            pos.x = -83.3f;
        }

        nomRect.anchoredPosition = pos;

        nom.text = currentSpeaker.ToString();
        textComponent.text = "";

        foreach (char c in currentText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    //------------------------------------------*
    // Fonction NextLine()
    // Description : Cette fonction permet de passer à la prochaine ligne dans 
    // le tableau lines[] contenant toutes les lignes
    //------------------------------------------*
    void NextLine()
    {
        StopAllCoroutines();

        do
        {
            index++;

            if (index >= lines.Length)
            {
                EndDialogue();
                return;
            }

        } while (
            lines[index].speaker == QuiParle.Vide ||
            string.IsNullOrWhiteSpace(lines[index].text)
        );

        dialogueCanvas.SetActive(true);
        StartCoroutine(TypeLine());
    }
    IEnumerator PasserLignesVidesAvecDelai()
    {
        dialogueCanvas.SetActive(false);

        yield return new WaitForSeconds(delaiReapparition);

        NextLine();
    }

    //------------------------------------------*
    // Fonction NextButtonClicked()
    // Description : Cette fonction permet de détecter le click du bouton et de
    // lancer la fonction NextLine ou de finir d'écrire le texte qui est entrain de s'écrire
    //------------------------------------------*
    void NextButtonClicked()
    {
        if (index >= lines.Length) return;

        if (!dialogueCanvas.activeSelf)
        {
            NextLine();
            return;
        }

        LignesDialogue currentLine = lines[index];


        if (currentLine.speaker == QuiParle.Vide || string.IsNullOrWhiteSpace(currentLine.text))
        {
            StopAllCoroutines(); 
            StartCoroutine(PasserLignesVidesAvecDelai());
            return;
        }

        if (textComponent.text == currentLine.text)
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = currentLine.text;
        }
    }
    //------------------------------------------*
    // Fonction EndDialogue()
    // Description : Cette fonction termine le dialogue en cours,
    // désactive le Canvas et redonne la possibilité de déplacer Nova
    //------------------------------------------
    void EndDialogue()
    {
        dialogueActif = false;

        if (nova != null)
            nova.SetCanMove(true);

        if (segments != null && segments.Length > 1)
        {

            if (dialogueCanvas != null)
                dialogueCanvas.SetActive(true);

            StartCoroutine(SegmentProgrammé(1));
        }
        else if (dialogueCanvas != null)
        {
            dialogueCanvas.SetActive(false);
        }
    }

}