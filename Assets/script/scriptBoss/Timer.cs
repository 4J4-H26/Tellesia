using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Timer : MonoBehaviour
{
    public float TempsTimer = 60f;
    public TextMeshProUGUI TimerNombre;

    [SerializeField] private Image vieNova;
    public Canvas canva;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        }

    }

    void TimerUI()
    {
        TimerNombre.text = TempsTimer.ToString();
    }

    void fermerUI()
    {
        canva.enabled = false;
        Invoke("prendreDegats", 1f);
    }

    void prendreDegats()
    {
        vieNova.fillAmount -= 0.1f;
        Invoke("Reset", 0f);
    }

    private void Reset()
    {
        Debug.Log("RESET");
    }
}
