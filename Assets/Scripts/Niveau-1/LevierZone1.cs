// script pour les leviers de commande dans le niveau 1
// auteur : sammuel
// date : 09 avril 2026

// desc : ** la zone détectée du levier quand Nova est proche -  LEVIER DE COMMANDE 2
//           **
using UnityEngine;

public class LevierZone1 : MonoBehaviour
{
    public Rotationleviertuto1 uiLevier; 

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