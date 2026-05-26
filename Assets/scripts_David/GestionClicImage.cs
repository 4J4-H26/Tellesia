//------------------------------------------*
// Auteur : David Phung
// Description : Script qui permet de cliquer sur une image dans
// l'UI du jeu et de ne pas prendre en compte les clics sur les
// pixels transparents de l'image
//------------------------------------------*

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
