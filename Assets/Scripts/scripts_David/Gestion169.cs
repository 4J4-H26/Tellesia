//------------------------------------------*
// Auteur : David Phung
// Description : Script qui lock le ratio d'aspect du jeu à 16:9 peu importe la résolution de l'écran du joueur
//------------------------------------------*

using UnityEngine;
public class Gestion169 : MonoBehaviour
{
    void Awake()
    {
        float RapportCible = 16f / 9f;
        float RapportFenetre = (float)Screen.width / (float)Screen.height;
        float echelleHauteur = RapportFenetre / RapportCible;

        Camera camera = GetComponent<Camera>();

        if (echelleHauteur < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = echelleHauteur;
            rect.x = 0;
            rect.y = (1.0f - echelleHauteur) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            float largeurEchelle = 1.0f / echelleHauteur;
            Rect rect = camera.rect;
            rect.width = largeurEchelle;
            rect.height = 1.0f;
            rect.x = (1.0f - largeurEchelle) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
}