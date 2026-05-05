// script pour gérer l'ouverture de la porte pour le prochain niveau
// auteur : sammuel
// date : 03 mai 2026

// desc : ** gestion de la porte du niveau 2 à la toute fin
//           qui permet au personnage d'aller au niveau 3 **

using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteFinNiveau2 : MonoBehaviour
{
    public Nova2 nova;

    bool finDeclenchee = false;

    public CameraQuiSuitNova cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova")
            && gameObject.CompareTag("porte-niveau2")
            && !finDeclenchee)
        {
            lancerFin();
        }
    }

    void lancerFin()
    {
        finDeclenchee = true;

        if (nova != null)
        {
            nova.ActiverAutoMove();
        }

        if (cam != null)
        {
            cam.StopSuivre();
        }

        GetComponent<Collider>().enabled = false;

        Invoke("chargerScene", 1f);
    }

    void chargerScene()
    {
        SceneManager.LoadScene("Niveau3");
    }
}