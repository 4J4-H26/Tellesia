// script pour gérer la caméra
// auteur : sammuel
// date : 09 Mars 2026

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionCamera : MonoBehaviour
{
    // ** on déclare les variables **

        // vitesse de la caméra
        public float vitesseCam = 5f;

        // controle de la cam
        bool cameraCtrl = false;

        // position initiale 
        Vector3 pI;

        // rotation initiale
        Quaternion rI;


    void Start()
    {
        // ** on mémoire la pos et rotation de départ **
        pI = transform.position;
        rI = transform.rotation;
    }
    
    void Update()
    {
        // ** on active la cam avec la touche 1 **
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraCtrl = true;
        }

        // ** on désactive la cam avec la touche 0 **
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cameraCtrl = false;

            transform.position = pI;
            transform.rotation = rI;
        }

        // ** on manipule avec les flèches les mouvements de la cam **
        if (cameraCtrl)
        {
            // ** on déclare les variables qui stockent le mouvement de la cam **

                // X = gauche (left) / droite (right)
                float mouvtX = 0;
                // Z = avant (forward) / arrière (backward)
                float mouvtZ = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
                mouvtX = -1;
            if (Input.GetKey(KeyCode.RightArrow))
                mouvtX = 1;
            if (Input.GetKey(KeyCode.UpArrow))
                mouvtZ = 1;
            if (Input.GetKey(KeyCode.DownArrow))
                mouvtZ = -1;

            // ** on déplace la cam selon les touches directionnelles à la vitesse définie **
            Vector3 mouvement = new Vector3(mouvtX, 0, mouvtZ);
            transform.Translate(mouvement * vitesseCam * Time.deltaTime, Space.World);
        }
    }
}
