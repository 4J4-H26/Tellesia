// script pour Nova et les cartes
// auteur : sammuel
// date : 21 Mars 2026

// desc : ** Nova **

using UnityEngine;

public class Nova : MonoBehaviour
{

    [Header("réf`à la carte")]
    public bool contientLaCarte = false;

    [Header("Déplacement")]
    public float vitesse = 5f;

    private Vector3 direction;

    void Update()
    {
        // on a le input clavier (flèches + WASD)
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");     

        // le mouvt isométrique (adapté caméra 3/4)
        direction = new Vector3(horizontal, 0, vertical);

        // ensuite le normaliser pour éviter mouvement plus rapide en diagonale
        direction = direction.normalized;

        // et le déplacement
        transform.Translate(direction * vitesse * Time.deltaTime, Space.World);
    }


    void OnTriggerEnter(Collider joueur)
    {
        // ** si Nova touche la carte
        if (joueur.CompareTag("Carte"))
        {
            contientLaCarte = true; 
            Destroy(joueur.gameObject); 
        }
    }
}