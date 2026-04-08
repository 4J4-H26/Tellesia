// script pour les leviers de commande dans le niveau 1
// auteur : sammuel
// date : 08 avril 2026

// desc : ** avec des tags (tag puzzle non résolu + tag puzzle résolu)
//           pour chacun des leviers, (détecte quand le levier est proche avec une collision
//           si le levier non résolu, le ui pourrait s'afficher, si résolu le ui ne s'affiche pas
//           **

using UnityEngine;

public class GestionLevierDeCommande : MonoBehaviour
{
    [Header("états booléens (tags)")]
    public bool resolu;
    public bool nonResolu;

    [Header("Les leviers")]
    public GameObject LevierDeCommande1;
    public GameObject LevierDeCommande2;
    public GameObject LevierDeCommande3;

    [Header("Les flèche")]
    public GameObject Flèche1;
    public GameObject Flèche2;
    public GameObject Flèche3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
