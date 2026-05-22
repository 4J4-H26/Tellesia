// script pour gérer la question sur l'histoire niveau 2
// auteur : stella & david
// date : 20 mai 2026

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    public float TempsTimer = 60f;
    public TextMeshProUGUI TimerNombre;

    [SerializeField] private Image vieNova;
    [SerializeField] private Image vieKardia;
    public int maxVie = 100;
    public int currentVie = 100;


    public Canvas canva;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vieNova.fillAmount = maxVie;
    }

    // Update is called once per frame
    void Update()
    {
        
        TimerUI();
        if(TempsTimer >0)
        {
            TempsTimer -= Time.deltaTime;
            TempsTimer = Mathf.Round(TempsTimer * 100.0f) * 0.01f;

        }
        if(TempsTimer <= 0){
            TempsTimer = 0f;
            Invoke("fermerUI", 1f);
            Invoke("prendreDegats", 2f);
        }

        if(canva.tag == "reussit")
        {
            Invoke("faireDegats", 1f);
        }

    }

    void TimerUI()
    {
        TimerNombre.text = TempsTimer.ToString();
    }

    void fermerUI()
    {
        canva.enabled = false;
    }

    void prendreDegats()
    {
        vieNova.fillAmount -= 0.1f;
        Invoke("Reset", 0f);
        Debug.Log(vieNova.fillAmount);
    }

    private void Reset()
    {
        Debug.Log("RESET");
    }

    void faireDegats()
    {
        vieKardia.fillAmount -= 0.1f;
        Invoke("Reset", 0f);
        Debug.Log(vieNova.fillAmount);
    }
}
