//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet de faire apparaître les puzzles à résoudre pour battre Kardia en cliquant sur l'icone correspondante
// Date: 
//------------------------------------------*

using System;
using UnityEngine;
using UnityEngine.UI;

public class apparitionUIBoss : MonoBehaviour
{
    [SerializeField] public GameObject UICode;
    [SerializeField] public GameObject UILeviers;
    [SerializeField] public GameObject UIQuestion;
    [SerializeField] public GameObject UIJigsaw;
    [SerializeField] public Image imgClick;

    private bool UIouvert;

    private void Start()
    {
        imgClick = GetComponent<Image>();

        imgClick.alphaHitTestMinimumThreshold = 0.5f;
    }

    public void OuvrirCode()
    {
        if (UIouvert)
        {
            UIouvert = false;
            UICode.SetActive(false);
        }
        else
        {
            UIouvert = true;
            UICode.SetActive(true);
        }

        Debug.Log("code ouvert)");
    }

    public void OuvrirLeviers()
    {
        if (UIouvert)
        {
            UIouvert = false;
            UILeviers.SetActive(false);
        }
        else
        {
            UIouvert = true;
            UILeviers.SetActive(true);
        }

        Debug.Log("leviers ouvert)");
    }

    public void OuvrieQuestion()
    {
        if (UIouvert)
        {
            UIouvert = false;
            UIQuestion.SetActive(false);
        }
        else
        {
            UIouvert = true;
            UIQuestion.SetActive(true);
        }

        Debug.Log("question ouvert");
    }

    public void OuvrirJigsaw()
    {
        if (UIouvert)
        {
            UIouvert = false;
            UIJigsaw.SetActive(false);
        }
        else
        {
            UIouvert = true;
            UIJigsaw.SetActive(true);
        }

        Debug.Log("jigsaw ouvert)");
    }

    public void Reset()
    {
        Debug.Log("reset");
    }
}
