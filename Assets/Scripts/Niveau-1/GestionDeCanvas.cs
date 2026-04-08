// script pour la gestion du canvas
// auteur : sammuel
// date : 06 avril 2026

// desc : 


using UnityEngine;
using System.Collections;

public class GestionDeCanvas : MonoBehaviour
{
    [Header("Références")]
    public GameObject canvasUI;  
    public Nova nova;            
         

    [Header("Paramètres")]
    public float dureeAffichage = 5f;

    private bool canvasActif = false;
    public void AfficherCanvas()
    {
        if (canvasActif) return;

        canvasActif = true;
        Time.timeScale = 0f;

  
        if (nova != null) nova.enabled = false;


        if (canvasUI != null) canvasUI.SetActive(true);

        StartCoroutine(CacherCanvasAprèsDelay(dureeAffichage));
    }

    private IEnumerator CacherCanvasAprèsDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        if (canvasUI != null) canvasUI.SetActive(false);

        if (nova != null) nova.enabled = true;

        Time.timeScale = 1f;

        canvasActif = false;
    }
}