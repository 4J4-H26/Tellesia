// script pour le perso de Nova 
// auteur : sammuel
// date : 21 Mars 2026

// desc : ** Nova **


using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nova : MonoBehaviour
{

    [Header("réf`à la carte")]
    public bool contientLaCarte = false;

    [Header("Déplacement")]
    public float vitesse = 2f;

    [Header("UI Puzzle")]

    [Header("Résultat du Tuto")]
    public ResultatTutoriel resultatTuto;

    [Header("Rotation")]
    public float vitesseRotation = 360f;

    [Header("Flèches")]
    public GameObject Flèche1;
    public GameObject Flèche2;
    public GameObject Flèche3;

    [Header("Les leviers")]
    public GameObject LevierDeCommande1;
    public GameObject LevierDeCommande2;
    public GameObject LevierDeCommande3;

    [Header("Le Canvas UI de Leviers")]
    public GameObject Canvas;

    [Header("LaPorte")]
    public GameObject Porte;

    private bool puzzleActif = false;
    private bool flecheActive = false;
    private bool canMove = true;
    private Vector3 direction;
    private GameObject carteProche;


    void Update()
    {
        if (!canMove) return;

        // ** on a le input clavier (flèches + WASD) **
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Transform cam = Camera.main.transform;

        // on récupère les directions de la caméra
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        // on enlève la composante Y pour rester au sol
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // direction basée sur la caméra
        direction = forward * vertical + right * horizontal;
        

        // déplacement 
        transform.Translate(direction * vitesse * Time.deltaTime, Space.World);

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                vitesseRotation * Time.deltaTime
            );
        }

        if (Input.GetKeyDown(KeyCode.E) && carteProche != null)
        {
            contientLaCarte = true;
            Destroy(carteProche);
            carteProche = null;

        }

        if (flecheActive)
        {
            // rotation continue
            Flèche1.transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
    }
    public void SetCanMove(bool value)
    {
        canMove = value;
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Carte"))
        {
            carteProche = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Carte"))
        {
            carteProche = null;
        }
    }


    



}
