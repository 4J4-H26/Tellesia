//------------------------------------------*
// Auteur : David Phung
// Description : Script qui gère le changement de résolution du jeu
//------------------------------------------*

using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GestionResolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private struct ResolutionCustom
    {
        public int largeur;
        public int hauteur;
        public ResolutionCustom(int w, int h) { largeur = w; hauteur = h; }
    }                                                                                               //Création d'une liste pour stocker
                                                                                                    //les résolutions personnalisées du jeu
    private readonly List<ResolutionCustom> ResolutionsDuJeu = new List<ResolutionCustom>()
    {
        new ResolutionCustom(1280, 720),
        new ResolutionCustom(1920, 1080),
        new ResolutionCustom(2560, 1440),
        new ResolutionCustom(3840, 2160)
    };

    private const string RESOLUTION = "IndexResolutionSaved";

    void Start()
    {
        Application.targetFrameRate = 60;     //Force le jeu à tourner à 60fps peu importe l'appareil 

        SetupDropdown();                      //Initialisation du dropdown avec les résolutions personnalisées du jeu

        int IndexJoueur = PlayerPrefs.GetInt(RESOLUTION, 1);      

        resolutionDropdown.value = IndexJoueur;
        resolutionDropdown.RefreshShownValue();                  //lorsque le jeu démarre,
                                                                 //appliquer la résolution sauvegarder du joueur ou la résolution par défaut (index 1 = 1920x1080)
        AppliquerResolution(IndexJoueur);

        resolutionDropdown.onValueChanged.AddListener(ChangementResolution); 
    }

    void SetupDropdown()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach (var res in ResolutionsDuJeu)
        {
            options.Add($"{res.largeur} x {res.hauteur}");     //Ajout des options dans le dropdown 
        }

        resolutionDropdown.AddOptions(options);
    }

    private void ChangementResolution(int index)
    {
        AppliquerResolution(index);
        PlayerPrefs.SetInt(RESOLUTION, index);              //Lorsque la résolution change, appliquer la resolution demander + sauvegarder la resolution choisie 
        PlayerPrefs.Save();
    }

    private void AppliquerResolution(int index)
    {
        ResolutionCustom resolutionChoisie = ResolutionsDuJeu[index];   //Appliquer la résolution choisie par le joueur
        Screen.SetResolution(resolutionChoisie.largeur, resolutionChoisie.hauteur, Screen.fullScreenMode, new RefreshRate { numerator = 60, denominator = 1 });
    }
}