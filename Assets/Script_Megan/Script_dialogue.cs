//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet d'écrire progressivement les textes de dialogue et de détecter
// quand le joueur clique sur le bouton pour passer à la ligne suivante
//------------------------------------------*

using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Script_dialogue : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Button buttonNext;

    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        buttonNext.onClick.AddListener(NextButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        foreach (char c in lines[index].ToCharArray())
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
        if (index < lines.Length -1)
        {
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }

    //------------------------------------------*
    // Fonction NextButtonClicked()
    // Description : Cette fonction permet de détecter le click du bouton et de
    // lancer la fonction NextLine ou de finir d'écrire le texte qui est entrain de s'écrire
    //------------------------------------------*
    void NextButtonClicked()
    {
        //Debug.Log("changer de dialogue");

        // Sécurité
        if (index >= lines.Length) return;

        if (textComponent.text == lines[index])
        {
            textSpeed = 0.1f;
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
}
