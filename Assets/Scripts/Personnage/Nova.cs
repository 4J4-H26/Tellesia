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


    private Vector3 direction;

    private GameObject carteProche;

    [Header("UI Puzzle")]
    public GameObject uiLevier;
    public GameObject porte;
    public GameObject uiSphere;


    private bool puzzleActif = false;

    public ResultatTutoriel resultatTuto;

    [Header("Rotation")]
    public float vitesseRotation = 360f;

    [Header("Fleche")]
    public GameObject fleche;  
    private bool flecheActive = false;

    public GameObject levierCourant;
    public GameObject Porte;

    void Update()
    {


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
            fleche.transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LevierDeCommande"))
        {
            levierCourant = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Sphere"))
        {
            flecheActive = false;

            if (fleche != null)
            {
                fleche.SetActive(false); 
            }

            StartCoroutine(AfficherUI(5f));
        }
        if (collision.gameObject.CompareTag("porte-niveau1"))
        {
            Porte = collision.gameObject;
            if (resultatTuto != null)
            {
                resultatTuto.levierActive = true;
            }
        }

    }

    private IEnumerator AfficherUI(float duree)
    {
        yield return new WaitForSeconds(1f);

        uiSphere.SetActive(true);

        yield return new WaitForSeconds(duree);

        uiSphere.SetActive(false);

        if (levierCourant != null)
        {
            Renderer rend = levierCourant.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = new Material(rend.material); 
                mat.color = Color.purple;
                rend.material = mat;
            }
        }
    }



}
