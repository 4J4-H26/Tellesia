using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cooldownText;
    [SerializeField] float tempsRestant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (tempsRestant > 0 )
        {
            tempsRestant -= Time.deltaTime;
        }
        else
        {
            Debug.Log("fin timer");
        }

    }
}
