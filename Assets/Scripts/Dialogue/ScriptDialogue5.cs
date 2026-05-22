//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet d'écrire progressivement les textes de dialogue et de détecter
// quand le joueur clique sur le bouton pour passer à la ligne suivante
//------------------------------------------*

using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public enum QuiParle5
{
    Nova,
    Ella,
    Kardia,
}

public enum ImagePerso5
{
    Ella1,
    Ella2,
    Ella3,
    Nova1,
    Nova2,
    Nova3,
    Kardia1,
    Kardia2,
    Kardia3,
    None
}

[System.Serializable]
public class LignesDialogue5
{
    public QuiParle5 speaker;
    public string text;
    public ImagePerso5 image;
}

[System.Serializable]
public class PauseEntreLignes5
{
    public int entreElement; 
    public float duree;
}

public class ScriptDialogue5 : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textComponent;
    public LignesDialogue5[] lines;
    public float[] delaisParLigne;
    public float textSpeed;
    public Button buttonNext;

    private int index;

    public TextMeshProUGUI nom;

    public Nova5 nova;

    private bool dialogueActif = false;

    bool isTyping = false;
    public bool autoNext = true;

    [Header("Images des Sprites pour qui qui parle")]
    public GameObject ImageSpriteElla1;
    public GameObject ImageSpriteNova1;
    public GameObject ImageSpriteKardia1;

    public GameObject ImageSpriteElla2;
    public GameObject ImageSpriteNova2;
    public GameObject ImageSpriteKardia2;

    public GameObject ImageSpriteElla3;
    public GameObject ImageSpriteNova3;
    public GameObject ImageSpriteKardia3;


    private ImagePerso5 currentImage = ImagePerso5.None;

    [Header("Pauses entre lignes")]
    public PauseEntreLignes5[] pauses;

    private Coroutine typeLineCoroutine;
    private bool isPaused = false;

    [Header("Les sons")]
    public AudioSource sonNova;
    public AudioSource sonElla;
    public AudioSource sonKardia;
    public AudioSource sonOuvertureDuUI;

    private bool attendreZoneSalle = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        dialogueCanvas.SetActive(true);
        if (sonOuvertureDuUI != null)
        {
            sonOuvertureDuUI.Play();
        }
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

    public void LancerDialogueApresChoix()
    {
        index = 1; 
        dialogueActif = true;

        if (nova != null) nova.SetCanMove(false);

        dialogueCanvas.SetActive(true);

        NextLine(); 
    }

    public void ReprendreDialogueDepuisZoneSalle()
    {
        if (!attendreZoneSalle)
            return;

        attendreZoneSalle = false;

        StopTyping();
        StopAllDialogueSounds();

        index = 2;
        dialogueActif = true;
        isPaused = false;
        isTyping = false;

        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(true);

        if (nova != null)
            nova.SetCanMove(false);

        typeLineCoroutine = StartCoroutine(TypeLine());
    }

    void StopTyping()
    {
        StopAllDialogueSounds();

        if (typeLineCoroutine != null)
        {
            StopCoroutine(typeLineCoroutine);
            typeLineCoroutine = null;
        }

        isTyping = false;
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
    void UpdateImage(ImagePerso5 img)
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

        ImageSpriteKardia1.SetActive(false);
        ImageSpriteKardia2.SetActive(false);
        ImageSpriteKardia3.SetActive(false);

        GameObject target = null;

        switch (img)
        {
            case ImagePerso5.Ella1:
                target = ImageSpriteElla1;
                break;
            case ImagePerso5.Ella2:
                target = ImageSpriteElla2;
                break;
            case ImagePerso5.Ella3:
                target = ImageSpriteElla3;
                break;

            case ImagePerso5.Nova1:
                target = ImageSpriteNova1;
                break;
            case ImagePerso5.Nova2:
                target = ImageSpriteNova2;
                break;
            case ImagePerso5.Nova3:
                target = ImageSpriteNova3;
                break;

            case ImagePerso5.Kardia1:
                target = ImageSpriteKardia1;
                break;
            case ImagePerso5.Kardia2:
                target = ImageSpriteKardia2;
                break;

            case ImagePerso5.Kardia3:
                target = ImageSpriteKardia3;
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
        StopAllDialogueSounds();

        if (nova != null)
            nova.SetCanMove(false);

        string currentText = lines[index].text;
        QuiParle5 currentSpeaker = lines[index].speaker;

        AudioSource voice = null;

        if (currentSpeaker == QuiParle5.Nova)
            voice = sonNova;
        else if (currentSpeaker == QuiParle5.Ella)
            voice = sonElla;
        else if (currentSpeaker == QuiParle5.Kardia)
            voice = sonKardia;

        UpdateImage(lines[index].image);

        textComponent.text = "";
        nom.text = "";

        dialogueCanvas.SetActive(true);

        RectTransform nomRect = nom.GetComponent<RectTransform>();
        Vector2 pos = nomRect.anchoredPosition;

        if (currentSpeaker == QuiParle5.Ella)
        {
            pos.x = 120f;
        }
        else if (currentSpeaker == QuiParle5.Kardia)
        {
            pos.x = 50f;
        }
        else if (currentSpeaker == QuiParle5.Nova)
        {
            pos.x = 74f;
        }


        nomRect.anchoredPosition = pos;

        nom.text = currentSpeaker.ToString();
        textComponent.text = "";

        isTyping = true;

        float soundTimer = 0f;
        float soundInterval = 0.08f;

        foreach (char c in currentText.ToCharArray())
        {
            textComponent.text += c;

            soundTimer += textSpeed;

            if (soundTimer >= soundInterval)
            {
                soundTimer = 0f;

                if (voice != null)
                {
                    voice.Stop();

                    voice.pitch = Random.Range(0.95f, 1.05f);
                    voice.Play();
                }
            }

            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;

        if (voice != null)
        {
            voice.Stop();
        }

        if (autoNext && delaisParLigne != null && index < delaisParLigne.Length)
        {
            yield return new WaitForSeconds(delaisParLigne[index]);
            NextLine();
        }
    }

    //------------------------------------------*
    // Fonction NextLine()
    // Description : Cette fonction permet de passer à la prochaine ligne dans 
    // le tableau lines[] contenant toutes les lignes
    //------------------------------------------*
    void NextLine()
    {
        StopAllDialogueSounds();

        if (isPaused) return;

        StopTyping();


        if (index == 1)
        {
            attendreZoneSalle = true;
            dialogueActif = false;

            if (dialogueCanvas != null)
                dialogueCanvas.SetActive(false);

            if (nova != null)
                nova.SetCanMove(true);

            return;
        }

        index++;

        if (index >= lines.Length)
        {
            EndDialogue();
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

        LignesDialogue5 currentLine = lines[index];


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

        StopTyping(); 

        dialogueActif = false;
        attendreZoneSalle = false;
        isTyping = false;

        StopAllDialogueSounds();

        if (nova != null)
            nova.SetCanMove(true);

        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(false);
    }
    void StopAllDialogueSounds()
    {
        if (sonNova != null) sonNova.Stop();
        if (sonElla != null) sonElla.Stop();
        if (sonKardia != null) sonKardia.Stop();
    }
}