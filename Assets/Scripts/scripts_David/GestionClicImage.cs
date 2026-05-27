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
    void Start()
    {
        Image img = GetComponent<Image>(); // Récupère l'image

        img.alphaHitTestMinimumThreshold = 0.5f;
    }
}
