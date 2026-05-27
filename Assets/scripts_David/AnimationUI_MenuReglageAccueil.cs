//------------------------------------------*
// Auteur : David Phung
// Description : Script qui gère l'animation du menu de réglage du menu d'accueil du jeu
//------------------------------------------*

using UnityEngine;

public class AnimationUI_MenuReglageAccueil : MonoBehaviour
{

    public GameObject MenuReglage;
    public Transform MenuReglagePosition;
    public Transform MenuReglageReferenceOuvert;
    public Transform MenuReglageReferenceFerme;
    [SerializeField] LeanTweenType easetype;

    public void BougerMenuReglages()
    {
        if (MenuReglagePosition.position.x == MenuReglageReferenceFerme.position.x)
        {
            LeanTween.moveX(MenuReglage, MenuReglageReferenceOuvert.position.x, 0.2f).setEase(easetype);
        }

        if (MenuReglagePosition.position.x == MenuReglageReferenceOuvert.position.x)
        {
            LeanTween.moveX(MenuReglage, MenuReglageReferenceFerme.position.x, 0.2f).setEase(easetype);
        }
    }
}
