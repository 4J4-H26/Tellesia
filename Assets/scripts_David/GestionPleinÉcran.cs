//------------------------------------------*
// Auteur : David Phung
// Description : Script qui gère le changement de mode d'affichage du jeu (plein écran ou fenêtré) 
//------------------------------------------*

using UnityEngine;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown DropdownModeEcran;

    void Start()
    {
        if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
        {
            DropdownModeEcran.value = 0;                                 //Montre le bon choix de fenetre dans le dropdown des le debut du jeu
        }
        else
        {
            DropdownModeEcran.value = 1;
        }

        DropdownModeEcran.onValueChanged.AddListener(ChangementModeEcran);
    }

    public void ChangementModeEcran(int index)
    {
        if (index == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;  //Lorsque le joueur change le mode d'affichage, appliquer le mode d'affichage demander
        }
        else if (index == 1)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    void OnDestroy()
    {
        if (DropdownModeEcran != null)
        {
            DropdownModeEcran.onValueChanged.RemoveListener(ChangementModeEcran);  //enleve le listener quand l'objet n'est plus utilisé
        }
    }
}
