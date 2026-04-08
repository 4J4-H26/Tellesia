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
    Ella
}

[System.Serializable]
public class LignesDialogue
{
    public QuiParle speaker;
    public string text;
}

public class ScriptDialogue : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textComponent;
    public LignesDialogue[] lines;
    public float textSpeed;
    public Button buttonNext;

    private int index;

    public TextMeshProUGUI nom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        dialogueCanvas.SetActive(true);
        StartDialogue();

        buttonNext.onClick.AddListener(NextButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BarreEspace();
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
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
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

        if (string.IsNullOrEmpty(currentText))
        {
            dialogueCanvas.SetActive(false);
            yield break;
        }

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
        if (index < lines.Length - 1)
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueCanvas.SetActive(false); 
        }
    }

    //------------------------------------------*
    // Fonction NextButtonClicked()
    // Description : Cette fonction permet de détecter le click du bouton et de
    // lancer la fonction NextLine ou de finir d'écrire le texte qui est entrain de s'écrire
    //------------------------------------------*
    void NextButtonClicked()
    {
        if (index >= lines.Length) return;

        if (textComponent.text == lines[index].text)
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index].text;
        }
    }

    //------------------------------------------*
    // Fonction NextButtonClicked()
    // Description : Cette fonction permet de détecter avec la barre d'espacement et de
    // lancer la fonction NextLine ou de finir d'écrire le texte qui est entrain de s'écrire
    //------------------------------------------*
    void BarreEspace()
    {
        NextButtonClicked();
    }

}