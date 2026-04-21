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
}

public enum ImagePerso
{
    Ella1,
    Ella2,
    Ella3,
    Nova1,
    Nova2,
    Nova3,
    None
}

[System.Serializable]
public class LignesDialogue
{
    public QuiParle speaker;
    public string text;
    public ImagePerso image;
}

[System.Serializable]
public class PauseEntreLignes
{
    public int entreElement; 
    public float duree;
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

    bool isTyping = false;
    public bool autoNext = true;

    [Header("Images des Sprites pour qui qui parle")]
    public GameObject ImageSpriteElla1;
    public GameObject ImageSpriteNova1;

    public GameObject ImageSpriteElla2;
    public GameObject ImageSpriteNova2;

    public GameObject ImageSpriteElla3;
    public GameObject ImageSpriteNova3;

    private ImagePerso currentImage = ImagePerso.None;

    [Header("Pauses entre lignes")]
    public PauseEntreLignes[] pauses;

    private Coroutine typeLineCoroutine;
    private bool isPaused = false;


    [Header("Les leviers de commande 3D")]
    public GameObject LevierDeCommande1;
    public GameObject LevierDeCommande2;
    public GameObject LevierDeCommande3;

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

    void StopTyping()
    {
        if (typeLineCoroutine != null)
        {
            StopCoroutine(typeLineCoroutine);
            typeLineCoroutine = null;
        }
    }

    bool TousLeviersReussis()
    {
        return LevierDeCommande1.CompareTag("reussit") &&
               LevierDeCommande2.CompareTag("reussit") &&
               LevierDeCommande3.CompareTag("reussit");
    }
    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    //------------------------------------------*
    // Fonction UpdateImage
    // Description : Cette fonction gère l’affichage des sprites de dialogue.
    // Elle désactive toutes les images puis active uniquement celle correspondant
    // à la ligne actuelle. Elle évite aussi de rejouer inutilement le changement
    // si l’image demandée est déjà affichée.
    //------------------------------------------*
    void UpdateImage(ImagePerso img)
    {
        if (img == currentImage)
            return;

        currentImage = img;

        ImageSpriteElla1.SetActive(false);
        ImageSpriteElla2.SetActive(false);
        ImageSpriteElla3.SetActive(false);

        ImageSpriteNova1.SetActive(false);
        ImageSpriteNova2.SetActive(false);
        ImageSpriteNova3.SetActive(false);

        GameObject target = null;

        switch (img)
        {
            case ImagePerso.Ella1:
                target = ImageSpriteElla1;
                break;
            case ImagePerso.Ella2:
                target = ImageSpriteElla2;
                break;
            case ImagePerso.Ella3:
                target = ImageSpriteElla3;
                break;

            case ImagePerso.Nova1:
                target = ImageSpriteNova1;
                break;
            case ImagePerso.Nova2:
                target = ImageSpriteNova2;
                break;
            case ImagePerso.Nova3:
                target = ImageSpriteNova3;
                break;
        }

        if (target != null)
        {
            target.SetActive(true);
        }
    }


    
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

        typeLineCoroutine = StartCoroutine(TypeLine());
    }

    //------------------------------------------*
    // Fonction TypeLine()
    // Description : Cette fonction permet d'écrire le texte progressivement 
    // un caractère à la fois dans les strings
    //------------------------------------------*
    IEnumerator TypeLine()
    {
        if (nova != null)
            nova.SetCanMove(false);

        string currentText = lines[index].text;
        QuiParle currentSpeaker = lines[index].speaker;

        UpdateImage(lines[index].image);

        textComponent.text = "";
        nom.text = "";

        dialogueCanvas.SetActive(true);

        RectTransform nomRect = nom.GetComponent<RectTransform>();
        Vector2 pos = nomRect.anchoredPosition;

        if (currentSpeaker == QuiParle.Ella)
        {
            pos.x = 70.1f;
        }
        else if (currentSpeaker == QuiParle.Nova)
        {
            pos.x = 49.7f;
        }


        nomRect.anchoredPosition = pos;

        nom.text = currentSpeaker.ToString();
        textComponent.text = "";

        isTyping = true;

        foreach (char c in currentText.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;

        if (autoNext && delaisParLigne != null && index < delaisParLigne.Length)
        {
            yield return new WaitForSeconds(delaisParLigne[index]);
            NextLine();
        }
    }


    IEnumerator AttendreLeviers()
    {
        isPaused = true;

        dialogueCanvas.SetActive(false);

        if (nova != null)
        nova.SetCanMove(true);

        while (!TousLeviersReussis())
        {
            yield return null;
        }

        if (nova != null)
            nova.SetCanMove(false);

        yield return null;

        dialogueCanvas.SetActive(true);

        isPaused = false;

        if (index >= lines.Length)
        {
            EndDialogue();
            yield break;
        }

        typeLineCoroutine = StartCoroutine(TypeLine());
    }

    //------------------------------------------*
    // Fonction NextLine()
    // Description : Cette fonction permet de passer à la prochaine ligne dans 
    // le tableau lines[] contenant toutes les lignes
    //------------------------------------------*
    void NextLine()
    {

        if (isPaused) return;

        StopTyping();

        int oldIndex = index;

        do
        {
            index++;

            if (index >= lines.Length)
            {
                EndDialogue();
                return;
            }

        } while (string.IsNullOrWhiteSpace(lines[index].text));

        if (oldIndex == 7) // ***********************************************************************************************************************************
        {
            StartCoroutine(AttendreLeviers());
            return;
        }

        if (TryGetPause(oldIndex, out float duree))
        {
            StartCoroutine(PauseDialogue(duree));
            return;
        }


        typeLineCoroutine = StartCoroutine(TypeLine());
    }

    //------------------------------------------*
    // Fonction NextButtonClicked()
    // Description : Cette fonction permet de détecter le click du bouton et de
    // lancer la fonction NextLine ou de finir d'écrire le texte qui est entrain de s'écrire
    //------------------------------------------*
    void NextButtonClicked()

    {
        if (isPaused) return;

        if (index >= lines.Length) return;

        if (isTyping)
        {
            if (typeLineCoroutine != null)
            {
                StopTyping();
            }
            textComponent.text = lines[index].text;
            isTyping = false;
            return; 
        }

        LignesDialogue currentLine = lines[index];


        if (textComponent.text == currentLine.text)
        {
            NextLine();
        }
        else
        {
            if (typeLineCoroutine != null)
            {
                StopTyping();
            }
            textComponent.text = currentLine.text;
        }
    }

    bool TryGetPause(int previousIndex, out float duree)
    {
        if (pauses != null)
        {
            foreach (var p in pauses)
            {
                if (p.entreElement == previousIndex)
                {
                    duree = p.duree;
                    return true;
                }
            }
        }

        duree = 0;
        return false;
    }

    IEnumerator PauseDialogue(float duree)
    {

        isPaused = true;

        dialogueCanvas.SetActive(false);

       if (nova != null)
         nova.SetCanMove(true);

            yield return new WaitForSeconds(duree);


        if (nova != null)
            nova.SetCanMove(false);

        dialogueCanvas.SetActive(true);

        isPaused = false;

        typeLineCoroutine = StartCoroutine(TypeLine());
    }
    //------------------------------------------*
    // Fonction EndDialogue()
    // Description : Cette fonction termine le dialogue en cours,
    // désactive le Canvas et redonne la possibilité de déplacer Nova
    //------------------------------------------
    void EndDialogue()
    {

        if (isPaused) return;

        dialogueActif = false;

        if (nova != null)
            nova.SetCanMove(true);

        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(false);
    }

}