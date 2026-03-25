// script pour gérer le puzzle du code
// auteur : sammuel
// date : 19 Mars 2026

// desc : ** on gère le placement des deux cubes et vérifie leur combinaison correcte
//        puis ça ouvre la porte quand le puzzle est résolu **


using UnityEngine;

public class Puzzle8Code : MonoBehaviour
{

    // ** on déclare les variables **

        // les emplacements que Nova
        // doit poser les cubes
        [Header("les supports")]
        public Transform supportCube1;
        public Transform supportCube2;

        private GameObject Cube1;
        private GameObject Cube2;

        [Header("les solutions: pour l'image 3 et l'image 10")]
        public int bonneImageCube1 = 3;
        public int bonneImageCube2 = 10;

        [Header("la porte du puzzle 8")]
        public GameObject portePuzzle8;

    public void PlacerCube(GameObject cube, Transform support)
    {
        // ** on évite que cube1 et 2 ont les mauvais supports **
        if (cube.CompareTag("Cube1") && support != supportCube1) return;
        if (cube.CompareTag("Cube2") && support != supportCube2) return;

        if (cube.CompareTag("Cube1") && support == supportCube1)
        {
            Cube1 = cube;
        }
        else if (cube.CompareTag("Cube2") && support == supportCube2)
        {
            Cube2 = cube;
        }

        // ** on place le cube sur le bon support et on 
        //    évite que Nova le laisse flotter ou l'assigne incorrectement **
        cube.transform.position = support.position;
        cube.transform.rotation = support.rotation;

        VerifierLesCombos();
    }

    void VerifierLesCombos()
    {
        if (Cube1 == null || Cube2 == null)
            return;

        Cubes info1 = Cube1.GetComponent<Cubes>();
        Cubes info2 = Cube2.GetComponent<Cubes>();

        if (info1 == null || info2 == null)
            return;

        // ** on permet d'ouvrir la porte is on a la bonne combinaison (images)
        //    pour les 2 cubes **
        if (info1.img == bonneImageCube1 &&
            info2.img == bonneImageCube2)
        {
            OuvrirPorte();
        }
        else
        {
            // 
        }
    }

    void OuvrirPorte()
    {
        portePuzzle8.SetActive(false);
    }
}
