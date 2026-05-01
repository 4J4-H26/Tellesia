// script pour gérer la porte barrée avec l'objet clé.
// auteur : sammuel
// date : 07 Mars 2026

// desc : ** le joueur avance, récupère la clé qui disparaît de la scène,
//        ce qui déclenche l’ouverture de la porte et fait apparaître une question historique **

using UnityEngine;

public class Puzzle2Bouton : MonoBehaviour
{
    [Header("Porte")]
    public Animator porteAnim;

    [Header("LeBouton du niv 2 son animation")]
    public Animator leBouton;

    void OnTriggerEnter(Collider objet)
    {
        if (objet.CompareTag("Nova"))
        {
            if (porteAnim != null)
                porteAnim.SetTrigger("Ouvrir");

            if (leBouton != null)
                leBouton.SetTrigger("Show");
        }
    }

}