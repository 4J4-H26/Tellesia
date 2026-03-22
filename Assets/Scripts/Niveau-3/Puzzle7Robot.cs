// script pour gérer le robot
// auteur : sammuel
// date : 15 Mars 2026

// desc : Nova doit activer un levier pour désactiver le robot qui bloque la sortie du niveau 3
//        ce levier devient accessible seulement après
//        avoir connecté les câbles, ce qui libère le passage

 using UnityEngine;

public class Puzzle7Robot : MonoBehaviour
{

    // ** on déclare les variables **

        [Header("les réfs gameobjects")]
        public GameObject robot;    
        public GameObject levier;

        [Header("les états : cables + levier")]
        private bool cablesConnectes = false;
        private bool levierActive = false;

    void Start()
    {
        // au début, le levier est désactivé
        levier.SetActive(false);
    }

    void Update()
    {
        // si les câbles sont connectés
        // on active le levier
        if (cablesConnectes)
        {
            levier.SetActive(true);
        }

        // si le levier est activé
        // on désactive le robot
        if (levierActive)
        {
            robot.SetActive(false);
        }
    }

    // ** on appele la fonction quand les câbles sont finis **
    public void CablesConnectes()
    {
        cablesConnectes = true;
    }

    // ** on appele la fonction
    // quand le joueur active le levier **
    public void ActiverLevier()
    {
        levierActive = true;
    }

}
