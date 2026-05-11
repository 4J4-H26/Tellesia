// script pour gérer le puzzle du code
// auteur : sammuel
// date : 20 Mars 2026

// desc : ** on détecte quand un cube est placé sur son support
//        puis on informe le manager de puzzle pour vérifier la combinaison **

using UnityEngine;

public class SupportCubes : MonoBehaviour
{
    // ** on déclare les variables **

        [Header("réf gestionnaire du puzzle")]
        public Puzzle8Code puzzleGestionnaire;

    private void OnTriggerEnter(Collider supportDeCubes)
    {
        if (supportDeCubes.CompareTag("Cube1") || supportDeCubes.CompareTag("Cube2"))
        {
            puzzleGestionnaire.PlacerCube(supportDeCubes.gameObject, transform);
        }
    }
}