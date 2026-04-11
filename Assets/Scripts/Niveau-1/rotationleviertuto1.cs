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

    [Header("Les leviers de commande 3D")]

    public GameObject levierActif;

    public Nova nova;

    private bool interactionEnCours = false;

    [Header("Les flèches")]
    public GameObject fleche2;

    [Header("Le son")]
    public AudioSource sonLevier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levierTuto = levierTuto.GetComponent<Button>();
        animRotation.enabled = false;

        Debug.Log(levierTuto.tag);
    }

    public void SetLevierActif(GameObject levier)
    {
        if (interactionEnCours) return;

        levierActif = levier;

        if (levierActif != null && levierActif.tag != "reussit")
        {
            canvaLevierTuto.enabled = true;
            interactionEnCours = true;

            if (nova != null)
                nova.SetCanMove(false);
        }
    }

    public void clickRotation()
    {
        if (levierActif == null)
        {
            Debug.LogWarning("Aucun levier actif !");
            return;
        }

        animRotation.enabled = true;

        if (sonLevier != null)
            sonLevier.Play();

        Invoke("StopSon", 0.6f);

        levierActif.tag = "reussit";

        levierTuto.tag = "reussit";

        if (fleche2 != null)
            fleche2.SetActive(false);

        Invoke("disableUI", 1.5f);
    }
    void disableUI()
    {
        canvaLevierTuto.enabled = false;

        if (nova != null)
            nova.SetCanMove(true);
    }

    public void FermerUI()
    {
        canvaLevierTuto.enabled = false;

        levierActif = null;
        interactionEnCours = false;

        if (nova != null)
            nova.SetCanMove(true);
    }
    void StopSon()
    {
        sonLevier.Stop();
    }
}