//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de mettre l'image finale quand
// toute les pièces sont au bon emplacement et de faire disparaître
// le puzzle ensuite.
//------------------------------------------*

using UnityEngine;

public class ScriptJigsawFin : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public int totalPieces = 6;
    private int placedPieces = 0;

    public GameObject jigsawPieces;
    public GameObject jigsawEmplacements;
    public GameObject finalImage;

    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    //------------------------------------------*
    // Fonction PiecePlaced
    // Description : Cette fonction incrémente le nombre de pièces
    // complétées et lance la fonction JigsawFin une fois qu'elles
    // sont toutes au bon endroit
    //------------------------------------------*
    public void PiecePlaced()
    {
        placedPieces++;

        if(placedPieces >= totalPieces)
        {
            Invoke("JigsawFin", 2f);
        }
    }

    //------------------------------------------*
    // Fonction JigsawFin
    // Description : Cette fonction enlève les pièces et
    // les emplacements pour afficher l'image finale
    //------------------------------------------*
    void JigsawFin()
    {
        jigsawPieces.SetActive(false);

        jigsawEmplacements.SetActive(false);

        finalImage.SetActive(true);

        Invoke("HideFinalImage", 3f);
    }

    //------------------------------------------*
    // Fonction PiecePlaced
    // Description : Cette fonction permet de laisser d'afficher
    // l'image quelques secondes avant de la faire disparaître avec Invoke
    //------------------------------------------*
    void HideFinalImage()
    {
        finalImage.SetActive(false);
    }
}
