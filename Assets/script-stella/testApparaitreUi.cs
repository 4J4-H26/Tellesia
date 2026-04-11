//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet d'apparaître et faire disparaître le UI avec input de la touche E
//------------------------------------------*

using System;
using UnityEngine;

public class testApparaitreUi : MonoBehaviour
{

    [SerializeField] public GameObject interfaceUItest;
    public KeyCode UIInputKey = KeyCode.E;

    private bool UIouvert;

    // Start is called on the first frame
    private void Start()
    {
        UIouvert = interfaceUItest.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(UIInputKey))
        {
            if (UIouvert)
            {
                UIouvert = false;
                interfaceUItest.SetActive(false);
            }
            else
            {
                UIouvert = true;
                interfaceUItest.SetActive(true);
            }
        }
    }
}
