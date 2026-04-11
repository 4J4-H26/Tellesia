//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet d'ouvrir les portes du niveau lorsque les puzzles sont complétés
//------------------------------------------*

using UnityEngine;
using UnityEngine.UI;

public class ouverturePorte : MonoBehaviour
{

    public Canvas levier1;
    public Canvas levier2;
    public Canvas levier3;

    public Animator animPorte;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (levier1.CompareTag("reussit") && levier2.CompareTag("reussit") && levier3.CompareTag("reussit"))
        {
            animPorte.Play("animPorteG");
        }
    }
}
