// script pour les leviers de commande dans le niveau 1
// auteur : sammuel
// date : 08 avril 2026

// desc : ** avec des tags (tag puzzle non résolu + tag puzzle résolu)
//           pour chacun des leviers, (détecte quand le levier est proche avec une collision
//           si le levier non résolu, le ui pourrait s'afficher, si résolu le ui ne s'affiche pas
//           **

using UnityEngine;

public class LevierDeCommande : MonoBehaviour
{
    [Header("Le Canvas UI de Leviers")]
    public GameObject Canvas;

    [Header("réf")]
    private bool NovaDansLaZoneDeLevier;

    [Header("état")]
    private bool canvasOuvert;

    [Header("Nova")]
    public Nova nova;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (NovaDansLaZoneDeLevier && Input.GetKeyDown(KeyCode.E))
        {
            canvasOuvert = !canvasOuvert;
            Canvas.SetActive(canvasOuvert);
            if (nova != null)
                nova.enabled = !canvasOuvert;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            NovaDansLaZoneDeLevier = true;

            canvasOuvert = true;
            Canvas.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            NovaDansLaZoneDeLevier = false;

            canvasOuvert = false;
            Canvas.SetActive(false);

        }
    }
}
