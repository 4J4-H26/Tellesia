//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet d'activer (activer l'animation) le levier lors d'un click
//------------------------------------------*

using UnityEngine;
using UnityEngine.UI;

public class rotationleviertuto1 : MonoBehaviour
{
    public Canvas canvaLevierTuto;
    public Button levierTuto;
    public Animator animRotation;
    public float temps = 1f;

    [Header("Nova")]
    public Nova nova;

    [Header("Les leviers de commande 3D")]

    public GameObject levierActif;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levierTuto = levierTuto.GetComponent<Button>();
        animRotation.enabled = false;

        Debug.Log(levierTuto.tag);
    }

    public void SetLevierActif(GameObject levier)
    {
        levierActif = levier;

        if (levierActif != null)
            canvaLevierTuto.enabled = true;
        else
            canvaLevierTuto.enabled = false;
    }

    public void clickRotation()
    {
        if (levierActif == null)
        {
            Debug.LogWarning("Aucun levier actif !");
            return;
        }

        animRotation.enabled = true;

        levierActif.tag = "reussit";

        Debug.Log(levierActif.name + " est reussi !");

        levierTuto.tag = "reussit";
    }
}