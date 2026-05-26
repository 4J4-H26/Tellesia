using UnityEngine;
using UnityEngine.UI;

public class GestionClicImage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Récupère le composant Image
        Image img = GetComponent<Image>();

        // Définit le seuil de transparence (0.5f = 50% d'opacité)
        // Les clics sur des pixels plus transparents que cela seront ignorés.
        img.alphaHitTestMinimumThreshold = 0.5f;

        Debug.Log("caca");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
