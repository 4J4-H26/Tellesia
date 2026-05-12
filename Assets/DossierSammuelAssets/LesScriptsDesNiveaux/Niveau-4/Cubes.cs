// script pour gérer le puzzle du code
// auteur : sammuel
// date : 19 Mars 2026

// desc : ** on gère l'image actuelle du cube et valide
//        qu'elle est correcte selon le type de cube
//        puis on permet de changer la face active
//        tout en empêchant les valeurs invalides **

using UnityEngine;

public class Cubes : MonoBehaviour
{

    // ** on déclare les variables **

        [Header("on a les données du cube")]
        public int img;

        [Header("état pour le type de cube")]
        public bool estCube1;

    public void ChangerImage(int lesImgs)
    {

        // ** cube 1 images 1 à 6 
        // ** cube 2 images 7 à 12
        if (estCube1)
        {
            if (lesImgs < 1 || lesImgs > 6) return;
        }
        else
        {
            if (lesImgs < 7 || lesImgs > 12) return;
        }

        img = lesImgs;
        // Debug.Log(gameObject.name + " image = " + img);
    }
}