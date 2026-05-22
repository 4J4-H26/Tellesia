//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet d'activer (activer l'animation) le levier lors d'un click
//------------------------------------------*

using UnityEngine;
using UnityEngine.UI;

public class rotationLevierTUto : MonoBehaviour
{
    public Canvas canvaLevierTuto;
    public Button levierTuto;
    public Animator animRotation;

    public GameObject levierActif;

    [Header("Le son")]
    public AudioSource sonLevier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levierTuto = levierTuto.GetComponent<Button>();
        animRotation.enabled = false;
    }

    public void clickRotation()
    {
        animRotation.enabled = true;

        if (sonLevier != null)
            sonLevier.Play();
        Invoke("StopSon", 0.6f);

        levierActif.tag = "reussit";

        levierTuto.tag = "reussit";

        canvaLevierTuto.tag = "reussit";
    }
}
