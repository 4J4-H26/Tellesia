// script pour gérer le résultat du tutoriel (niveau 1)
// auteur : sammuel
// date : 08 Mars 2026

// desc : ** un levier au début **

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultatTutoriel : MonoBehaviour
{
    [Header("booléens tuto")]
    bool reussiTuto = false;
    bool echecTuto = false;
    public bool levierActive = false;

    bool finDeclenchee = false;
    bool resultatFinal;

    [Header("Nova")]
    public Nova nova;

    [Header("Canvas UI Levier de commande")]
    public GameObject Canvas;

    void Update()
    {
        if (!finDeclenchee)
        {
            if (reussite())
            {
                reussiTuto = true;
                lancerFin(true);
            }

            if (echec())
            {
                echecTuto = true;
                lancerFin(false);
            }
        }
    }

    void lancerFin(bool tutoReussi)
    {
        finDeclenchee = true;
        resultatFinal = tutoReussi;

        if (nova != null)
            nova.enabled = false;

        Invoke("executerFin", 2f);
    }

    void executerFin()
    {
        if (resultatFinal)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    bool reussite()
    {
        return levierActive;
    }

    bool echec()
    {
        return false;
    }
}