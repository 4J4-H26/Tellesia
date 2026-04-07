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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levierTuto = levierTuto.GetComponent<Button>();
        animRotation.enabled = false;
    }

    public void clickRotation()
    {
        animRotation.enabled = true;
    }
}
