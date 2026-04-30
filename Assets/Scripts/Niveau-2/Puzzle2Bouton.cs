// script pour gérer la porte barrée avec l'objet clé.
// auteur : sammuel
// date : 07 Mars 2026

// desc : ** le joueur avance, récupère la clé qui disparaît de la scène,
//        ce qui déclenche l’ouverture de la porte et fait apparaître une question historique **

using UnityEngine;

public class Puzzle2Bouton : MonoBehaviour
{
    public Animator porteAnim;

    void OnTriggerEnter(Collider objet)
    {
        if (objet.CompareTag("Nova"))
        {
            porteAnim.SetTrigger("Ouvrir");
        }
    }
}