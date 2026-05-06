// script pour gérer le levier
// auteur : sammuel
// date : 15 Mars 2026

// desc : ** Nova doit activer un levier pour désactiver le robot qui bloque la sortie du niveau 3
//        ce levier devient accessible seulement après
//        avoir connecté les câbles, ce qui libère le passage **

using UnityEngine;

public class Levier : MonoBehaviour
{
    void OnTriggerEnter(Collider levier)
    {
        if (levier.CompareTag("Nova"))
        {
            FindObjectOfType<Puzzle7Robot>().ActiverLevier();
        }
    }
}