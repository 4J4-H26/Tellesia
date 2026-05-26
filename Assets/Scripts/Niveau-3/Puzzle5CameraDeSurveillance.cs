// script pour gérer les caméras de surveillance
// auteur : sammuel
// date : 12 Mars 2026

// desc : ** Nova doit éviter l'angle de la caméra de surveillance
//        si Nova entre dans la zone de lumière,
//        le niveau recommence depuis le début **

//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Puzzle5CameraDeSurveillance : MonoBehaviour
//{

//    // ** on déclare les variables **

//        [Header("vitesse mouvt de la cam")]
//        public float vitesse = 50f;


//    void Update()
//    {
//        // ** on fait bouger la cam de surveillance **
//        transform.Rotate(0, vitesse * Time.deltaTime, 0);
//    }

//    // ** on recharge le niv 3 si nova est détecter par la cam **
//    private void OnTriggerEnter(Collider perso)
//    {
//        if (perso.CompareTag("Nova"))
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//    }

//}



using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle5CameraDeSurveillance : MonoBehaviour
{
    public AudioClip sonAttraperCam;
    private AudioSource audioSource;

    [Header("Nova")]
    public Nova3 nova;

    [Header("Dialogue")]
    public ScriptDialogue3 dialogue;

    private bool dejaAttrape = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dejaAttrape) return;

        if (other.CompareTag("Nova"))
        {
            dejaAttrape = true;

            if (nova != null)
                nova.SetCanMove(false);

            if (audioSource != null)
                audioSource.PlayOneShot(sonAttraperCam, 1f);

            StartCoroutine(CameraCaughtSequence());
        }
    }

    private System.Collections.IEnumerator CameraCaughtSequence()
    {
        if (dialogue != null)
        {
            dialogue.JouerElement4Temporaire(5f);
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}