using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TempsTimer = 60f;
    public TextMeshProUGUI TimerNombre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TempsTimer -= Time.deltaTime;
        TimerUI();
    }

    void TimerUI() 
    { 
        TimerNombre.text = TempsTimer.ToString();
    }

}
