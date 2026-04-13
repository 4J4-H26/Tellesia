// script pour les leviers de commande dans le niveau 1
// auteur : sammuel
// date : 09 avril 2026

// desc : ** la zone détectée du levier quand Nova est proche -  LEVIER DE COMMANDE 1
//           **

using UnityEngine;

public class LevierZone : MonoBehaviour
{
    public Rotationleviertuto uiLevier; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            uiLevier.SetLevierActif(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            uiLevier.SetLevierActif(null);
        }
    }
}