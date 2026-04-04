// script pour gérer le puzzle du code
// auteur : sammuel
// date : 28 mars 2026

// desc : ** on fait face au boss avec possibilités de 2 cinématiques différents **


using UnityEngine;
using UnityEngine.UI;

public class Puzzle10Antagoniste : MonoBehaviour
{
    // ** on déclare les variables **

        [Header("vie de Nova")]
        public int vieMax = 5;
        public int vieActuelle;

        [Header("UI")]
        public Slider barreDeVie;

    void Start()
    {
        vieActuelle = vieMax;
        MettreAJourUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SubitAttaque(1);
        }
    }

    public void SubitAttaque(int degats)
    {
        vieActuelle -= degats;

        if (vieActuelle < 0)
            vieActuelle = 0;

        MettreAJourUI();

        if (vieActuelle == 0)
        {
            Mort();
        }
    }

    void MettreAJourUI()
    {
        if (barreDeVie != null)
        {
            barreDeVie.value = (float)vieActuelle / vieMax;
        }
    }

    void Mort()
    {
        //
    }

}
