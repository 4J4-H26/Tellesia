//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de jouer
// les animations du loaging screen et de 
// charger la prochaine scène
//------------------------------------------*
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptLoadingScreen1 : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
   // public Animator anim; 

    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    // Start
    void Start()
    {
       // anim = GetComponent<Animator>();
        Invoke ("LoadNext", 5f);
    }

    // Update
    void Update()
    {
       // anim.Play("animLogoElla");
        //anim.Play("animLogoNova");
        //anim.Play("animLogoKardia");
    }

    //------------------------------------------*
    // Fonction LoadNext
    // Description : Cette fonction permet de lancer
    // la scène suivante avec un délai (5s) pour laisser
    // l'animation jouer
    //------------------------------------------*
    public void LoadNext()
    {
        Debug.Log("Charger scène");
        SceneManager.LoadScene("Niveau3");
    }
}
