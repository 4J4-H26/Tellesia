// script pour la gestion du canvas
// auteur : sammuel
// date : 06 avril 2026

// desc : 


using UnityEngine;

public class GestionDeCanvas : MonoBehaviour
{
    [Header("Références")]
    public GameObject canvasUI;
    public Nova nova;

    private bool canvasActif = false;

    public void ToggleCanvas()
    {
        canvasActif = !canvasActif;

        if (canvasUI != null)
            canvasUI.SetActive(canvasActif);

        if (nova != null)
            nova.enabled = !canvasActif;

        Time.timeScale = canvasActif ? 0f : 1f;
    }
}