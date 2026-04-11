//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de 
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
    public GameObject finalImage;

    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    //------------------------------------------*
    // Fonction PiecePlaced
    //------------------------------------------*
    public void PiecePlaced()
    {
        placedPieces++;

        if (placedPieces >= totalPieces)
        {
            Invoke("JigsawFin", 2f);
        }
    }

    void JigsawFin()
    {
        jigsawPieces.SetActive(false);

        finalImage.SetActive(true);

        Invoke("HideFinalImage", 3f);
    }

    void HideFinalImage()
    {
        finalImage.SetActive(false);
    }
}