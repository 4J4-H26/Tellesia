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
                nova.SetCanMove(!canvasOuvert);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nova") && gameObject.tag != "reussit")
        {
            NovaDansLaZoneDeLevier = true;

            canvasOuvert = true;
            Canvas.SetActive(true);

            if (nova != null)
                nova.SetCanMove(false);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nova") && gameObject.tag != "reussit")
        {
            NovaDansLaZoneDeLevier = false;

            canvasOuvert = false;
            Canvas.SetActive(false);

            if (nova != null)
                nova.SetCanMove(true);
        }
    }
}
