// script pour la cam qui suit Nova
// auteur : sammuel
// date : 1er avril 2026

// desc : ** pour le pivot de la cam je lui donne
//           ce script pour suivre Nova **

using UnityEngine;

public class CameraQuiSuitNova : MonoBehaviour
{
    public Transform cible; // Nova
    private Vector3 offset;

    void Start()
    {
        // On garde EXACTEMENT la position actuelle de la caméra
        offset = transform.position - cible.position;
    }

    void LateUpdate()
    {
        // On suit Nova sans changer l’angle
        transform.position = cible.position + offset;
    }
}