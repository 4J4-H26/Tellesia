// script pour la cam qui suit Nova
// auteur : sammuel
// date : 1er avril 2026

// desc : ** pour le pivot de la cam je lui donne
//           ce script pour suivre Nova **

using UnityEngine;

public class CameraQuiSuitNova : MonoBehaviour
{
    public Transform cible;
    private Vector3 offset;

    private bool suivre = true;

    void Start()
    {
        offset = transform.position - cible.position;
    }

    void LateUpdate()
    {
        if (!suivre) return; 

        transform.position = cible.position + offset;
    }

    public void StopSuivre()
    {
        suivre = false;
    }
}