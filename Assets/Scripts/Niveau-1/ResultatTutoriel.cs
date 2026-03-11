// script pour gérer le résultat du tutoriel (niveau 1)
// auteur : sammuel
// date : 08 Mars 2026

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultatTutoriel : MonoBehaviour
{
    // ** on déclare les variables **

        // booléens tuto
        bool reussiTuto = false;
        bool echecTuto = false;

    void Start()
    {
        //
    }

    void Update()
    {

        // ** on applique la condition de reussite **
        if (reussite())
        {
            reussiTuto = true;
            finTuto(true);
        }

        // ** on applique la condition d'échec **
        if (echec())
        {
            echecTuto = true;
            finTuto(false);
        }

    }

    void finTuto(bool tutoReussi)
    {
        if (tutoReussi)
        {
            // ** on charge le niveau suivant **
            SceneManager.LoadScene("Niveau2");
        }
        else
        {
            // ** on recharge la scène du tuto **
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    bool reussite()
    {
        // ** les leviers **
        return false; 
    }

    bool echec()
    {
        // ** les leviers **
        return false; 
    }

}
