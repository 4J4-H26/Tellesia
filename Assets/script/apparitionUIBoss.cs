//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet d'apparaître et faire disparaître le UI avec input de la touche E
//------------------------------------------*

using System;
using UnityEngine;
using UnityEngine.UI;

public class testApparaitreUi : MonoBehaviour
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
    }
}
