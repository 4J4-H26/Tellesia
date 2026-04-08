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

    public float temps = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levierTuto = levierTuto.GetComponent<Button>();
        animRotation.enabled = false;
        Debug.Log(levierTuto.tag);
    }

    public void clickRotation()
    {
        animRotation.enabled = true;
        levierTuto.tag = "reussit";
        Debug.Log(levierTuto.tag);
        Invoke("disableUI", 1.5f);
        
    }

    void disableUI()
    {
        canvaLevierTuto.enabled = false;
    }
}
