// script pour gérer le puzzle du code
// auteur : sammuel
// date : 19 Mars 2026

// desc : on gère l'image actuelle du cube et valide
//        qu'elle est correcte selon le type de cube
//        puis on permet de changer la face active
//        tout en empêchant les valeurs invalides

using UnityEngine;

public class Cubes : MonoBehaviour
{

    // ** on déclare les variables **

        [Header("données du cube")]
        public int imageActuelle;

        [Header("type de cube")]
        public bool estCube1;

    public void ChangerImage(int nouvelleImage)
    {

        // ** cube 1 aura les images 1 à 6 
        // ** cube 2 aura les images 7 à 12
        if (estCube1)
        {
            if (nouvelleImage < 1 || nouvelleImage > 6) return;
        }
        else
        {
            if (nouvelleImage < 7 || nouvelleImage > 12) return;
        }

        imageActuelle = nouvelleImage;
       // Debug.Log(gameObject.name + " image = " + imageActuelle);
    }
}