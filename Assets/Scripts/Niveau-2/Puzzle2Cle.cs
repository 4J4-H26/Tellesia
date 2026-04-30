// script pour gérer la porte barrée avec l'objet clé.
// auteur : sammuel
// date : 07 Mars 2026

// desc : ** le joueur avance, récupère la clé qui disparaît de la scène,
//        ce qui déclenche l’ouverture de la porte et fait apparaître une question historique **

using UnityEngine;

public class Puzzle2Cle : MonoBehaviour
{
    private bool dansZone = false;

    public static bool cleRamassee = false;

    private void OnTriggerEnter(Collider objet)
    {
        if (objet.CompareTag("Nova"))
        {
            dansZone = true;
        }
    }

    private void OnTriggerExit(Collider objet)
    {
        if (objet.CompareTag("Nova"))
        {
            dansZone = false;
        }
    }

    private void Update()
    {
        if (dansZone && Input.GetKeyDown(KeyCode.E))
        {
            cleRamassee = true;
            Destroy(gameObject);
        }
    }
}