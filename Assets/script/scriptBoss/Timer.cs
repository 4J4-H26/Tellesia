// script pour gérer le timer, la barre de vie de Nova et la barre de vie de Kardia
// auteur : stella & david
// date : 20 - 26 mai 2026

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;

public class Timer : MonoBehaviour
{
    public float TempsTimer;
    public float timer;
    public TextMeshProUGUI TimerNombre;

    public bool temps0;

    public GameObject gameObjectUI;
    public Canvas canvasUI;

    public GameObject barreVieKardia;
    public GameObject barreVieNova;
    public GameObject UIchoixFin;
    public GameObject UIchoixAttaque;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TempsTimer = timer;
        temps0 = false;
        TimerNombre.text = Math.Round(TempsTimer, 2).ToString();
        //TempsTimer = timerTest.tempsOriginal;
    }

    // Update is called once per frame
    void Update()
    {
        if (TempsTimer > 0)
        {
            TempsTimer -= Time.deltaTime;
        }
        TimerUI();
    }
    
    // fonction pour le timer
    void TimerUI()
    {
        TimerNombre.text = Math.Round(TempsTimer, 2).ToString();

        if (TempsTimer <= 0 && !temps0)
        {
            temps0 = true;
            TempsTimer = 0f;
            Invoke("fermerUI", 1f);
            Invoke("prendreDegats", 2f);

        }

        if (gameObjectUI.tag == "reussit" && !temps0)
        {
            
            temps0 = true;
            Invoke("fermerUItoujours", 1f);
            Invoke("faireDegats", 2f);
        }

        // va laisser un petit montant de vie pour laisser le choix au joueur de la tuer ou de l'épargner
        if(vieKardia.imgHealthbar.fillAmount <= 0.2)
        {
            vieKardia.imgHealthbar.fillAmount = 0.05f;
            Invoke("chargerSceneChoix", 2f);
        }
    }
    // permet de fermer visuellement le UI, peut être réouvert par la suite
    void fermerUI()
    {
        gameObjectUI.SetActive(false);
        temps0 = false;
    }
    // permet de fermer complètement, de désactiver le UI, ne peut pas être réouvert par la suite
    void fermerUItoujours()
    {
        canvasUI.enabled = false;

    }

    //fonction pour que Nova prend des dégâts lorsqu'elle rate de réussir un puzzle, maximum de 4 chances
    public void prendreDegats()
    {
        vieNova.imgHealthbar.fillAmount -= 0.25f;
        Debug.Log(vieNova.imgHealthbar.fillAmount);

        if (vieNova.imgHealthbar.fillAmount <= 0f)
        {
            Invoke("chargerSceneMort", 2f);
        }

        Invoke("Reset", 0f);
    }

    //fonction pour que Kardia prend des dégâts
    public void faireDegats()
    {
        vieKardia.imgHealthbar.fillAmount -= 0.25f;
        Debug.Log(vieKardia.imgHealthbar.fillAmount);
        Invoke("Reset", 0f);
    }

    void chargerSceneMort()
    {
        SceneManager.LoadScene(4);
    }


    private void Reset()
    {
        Debug.Log("RESET");
        TempsTimer = timer;
    }

    public void chargerSceneChoix()
    {

        // va seulement désactiver le reste des UI et va aactiver le UI de choix de la fin de la cinématique
        UIchoixFin.active = true;
        barreVieKardia.active = false;
        barreVieNova.active = false;
        UIchoixAttaque.active = false;
    }
}
