using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Script_dialogue : MonoBehaviour
{
    // VARIABLES
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
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            textSpeed = 0f;
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Écrire les lettres une par une
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

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

    void NextButtonClicked()
{
    Debug.Log("changer de dialogue");

     // sécurité
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
