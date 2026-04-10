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

    // private void OnTriggerEnter(Collider other)
    // {
    //    if (other.CompareTag("Nova") && tuto.porteActive && !finDeclenchee)
    //    {
    //        lancerFin();
    //  }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nova") && tuto.porteActive && !finDeclenchee)
        {
            lancerFin();
        }
    }

    void lancerFin()
    {
        finDeclenchee = true;

        if (nova != null)
            nova.enabled = false;

        Invoke("chargerScene", 2f);
    }

    void chargerScene()
    {
        SceneManager.LoadScene("SceneNiveau2");
    }
}