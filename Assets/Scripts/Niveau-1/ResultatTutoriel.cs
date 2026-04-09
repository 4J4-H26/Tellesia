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

    [Header("Porte")]
    public GameObject Porte;

    [Header("Les leviers")]
    public GameObject LevierDeCommande1;
    public GameObject LevierDeCommande2;
    public GameObject LevierDeCommande3;

    bool messageAffiche = false;

    void Update()
    {
        if (!finDeclenchee && levierActive) 
        {
            if (reussite())
            {
                lancerFin(true);
            }
            else if (!messageAffiche)
            {
                Debug.Log("pas encore complet faut activer tous les leviers");
                messageAffiche = true;
            }
        }

        if (!levierActive)
        {
            messageAffiche = false;
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
            SceneManager.LoadScene("SceneNiveau2");
        }
    }

    bool reussite()
    {
        return LevierDeCommande1.CompareTag("reussit") &&
               LevierDeCommande2.CompareTag("reussit") &&
               LevierDeCommande3.CompareTag("reussit");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            levierActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            levierActive = false;
        }
    }
}