//------------------------------------------*
// Auteur : David Phung
// Description : Script qui gère l'animation du menu de bouttons sur l'écran d'accueil du jeu
//------------------------------------------*
using UnityEngine;


public class AnimationUI_Accueil : MonoBehaviour
{
    public GameObject Menu;
    public Transform MenuReference;

    //public GameObject MenuReglage;
    //public Transform MenuReglagePosition;
    //public Transform MenuReglageReferenceOuvert;
    //public Transform MenuReglageReferenceFerme;


    [SerializeField] LeanTweenType easetype;

    void Awake()
    {
        
        LeanTween.init(2000);
    }

    void Start()
    {

    }


    void Update()
    {
        BougerMenu();
    }



    public void BougerMenu()
    {
        LeanTween.moveX(Menu, MenuReference.position.x, 1f).setEase(easetype);
    }

    //public void BougerMenuReglages()
    //{
    //    if (MenuReglagePosition.position.x == MenuReglageReferenceFerme.position.x)
    //    {
    //        LeanTween.moveX(MenuReglage, MenuReglageReferenceOuvert.position.x, 0.2f).setEase(easetype);
    //    }

    //    if (MenuReglagePosition.position.x == MenuReglageReferenceOuvert.position.x)
    //    {
    //        LeanTween.moveX(MenuReglage, MenuReglageReferenceFerme.position.x, 0.2f).setEase(easetype);
    //    }
    //}

}