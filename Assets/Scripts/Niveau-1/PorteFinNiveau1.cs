// script pour gérer l'ouverture de la porte pour le prochain niveau
// auteur : sammuel
// date : 09 avril 2026

// desc : ** un levier au début **

using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteFinNiveau1 : MonoBehaviour
{
    public ResultatTutoriel tuto;
    public Nova nova;

    bool finDeclenchee = false;

    public CameraQuiSuitNova cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova")
            && gameObject.CompareTag("porte-niveau1")
            && tuto.porteActive
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

        Invoke("chargerScene", 3f);
    }

    void chargerScene()
    {
        SceneManager.LoadScene("SceneNiveau2");
    }
}