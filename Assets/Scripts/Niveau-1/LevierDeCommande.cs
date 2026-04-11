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

    private float timer;
    private float delaiAvantOuverture = 2.5f;
    private bool enAttenteOuverture;
    private bool animationDejaTraitee;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (NovaDansLaZoneDeLevier && nova != null && nova.animationToucherTerminee && !enAttenteOuverture && !canvasOuvert && !animationDejaTraitee)
        {
            animationDejaTraitee = true;

            enAttenteOuverture = true;
            timer = 0f;
        }

        if (enAttenteOuverture)
        {
            timer += Time.deltaTime;

            if (timer >= delaiAvantOuverture)
            {
                enAttenteOuverture = false;
                timer = 0f;

                if (NovaDansLaZoneDeLevier)
                {
                    canvasOuvert = true;
                    Canvas.SetActive(true);

                    if (nova != null)
                    {
                        nova.SetCanMove(false);
                        nova.ResetToucher(); 
                    }
                }
            }
        }

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
            Invoke(nameof(OuvrirCanvas), 2f);
            canvasOuvert = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nova") && gameObject.tag != "reussit")
        {
            NovaDansLaZoneDeLevier = false;

            enAttenteOuverture = false;
            timer = 0f;

            animationDejaTraitee = false;
        }
    }

    private void OuvrirCanvas()
    {
        Canvas.SetActive(true);

        if (nova != null)
            nova.SetCanMove(false);
    }
}
