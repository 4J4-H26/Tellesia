// script pour le perso de Nova 
// auteur : sammuel
// date : 21 Mars 2026

// desc : ** Nova **

using UnityEngine;

public class Nova : MonoBehaviour
{

    [Header("réf`à la carte")]
    public bool contientLaCarte = false;

    [Header("Déplacement")]
    public float vitesse = 2f;

    private Vector3 direction;

    private GameObject carteProche;


    void Update()
    {
        // ** on a le input clavier (flèches + WASD) **
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

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
        direction = direction.normalized;

        // déplacement 
        transform.Translate(direction * vitesse * Time.deltaTime, Space.World);

        // ** on ajuste la manière dont le perso fait la rotation
        // dépendement de sa direction **
        // if (direction.magnitude > 0.1f)
        // {
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
        //}


        if (Input.GetKeyDown(KeyCode.E) && carteProche != null)
        {
            contientLaCarte = true;
            Destroy(carteProche);
            carteProche = null;

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
}