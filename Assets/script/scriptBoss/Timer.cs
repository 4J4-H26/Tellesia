// script pour gérer la question sur l'histoire niveau 2
// auteur : stella & david
// date : 20 mai 2026

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
    public TextMeshProUGUI TimerNombre;

    public bool temps0;

    public Canvas canva;

    public GameObject barreVieKardia;
    public GameObject barreVieNova;
    public GameObject UIchoixFin;
    public GameObject UIchoixAttaque;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        temps0 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (TempsTimer >0)
        {
            TempsTimer -= Time.deltaTime;

        }

        TimerUI();


    }

    void TimerUI()
    {
        //TimerNombre.text = TempsTimer.ToString();
        //TempsTimer = Mathf.Round(TempsTimer * 100f) * 0.01f;
        TimerNombre.text = Math.Round(TempsTimer, 2).ToString();

        if (TempsTimer <= 0 && !temps0)
        {
            temps0 = true;
            TempsTimer = 0f;
            Invoke("fermerUI", 1f);
            Invoke("prendreDegats", 2f);

        }

        if (canva.tag == "reussit" && !temps0)
        {
            
            temps0 = true;
            Invoke("fermerUI", 1f);
            Invoke("faireDegats", 2f);
        }

        if(vieKardia.imgHealthbar.fillAmount <= 0.2)
        {
            vieKardia.imgHealthbar.fillAmount = 0.1f;
            Invoke("chargerSceneChoix", 2f);
        }
    }

    void fermerUI()
    {
        canva.enabled = false;
    }

    public void prendreDegats()
    {
        vieNova.imgHealthbar.fillAmount -= 0.25f;
        Debug.Log(vieNova.imgHealthbar.fillAmount);

        if (vieNova.imgHealthbar.fillAmount <= 0f)
        {
            Invoke("chargerSceneMort", 2f);
        }

        //Invoke("Reset", 0f);
    }

    void chargerSceneMort()
    {
        SceneManager.LoadScene(4);
    }

    public void faireDegats()
    {
        vieKardia.imgHealthbar.fillAmount -= 0.25f;
        Debug.Log(vieKardia.imgHealthbar.fillAmount);
        Invoke("Reset", 0f);
    }

    private void Reset()
    {

        Debug.Log("RESET");
    }

    public void chargerSceneChoix()
    {
        UIchoixFin.active = true;
        barreVieKardia.active = false;
        barreVieNova.active = false;
        UIchoixAttaque.active = false;
    }
}
