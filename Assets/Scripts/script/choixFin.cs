//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet de changer la scène d'une de nos 2 cinématiques dépendamment du choix du joueur en cliquant sur l'option correspondnates
// Date: 
//------------------------------------------*


using UnityEngine;
using UnityEngine.SceneManagement;

public class choixFin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finDetruire()
    {
        Invoke("delaiPasDrtuire", 1f);
    }

    public void finPasDetruire()
    {
        Invoke("DelaiDetruire", 1f);
    }

    void DelaiDetruire()
    {
        SceneManager.LoadScene("Cinematique1");
    }

    void delaiPasDrtuire()
    {
        SceneManager.LoadScene("Cinematique2");
    }
}
