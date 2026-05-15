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


using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle5CameraDeSurveillance : MonoBehaviour
{
    public AudioClip sonAttraperCam;
    AudioSource AudioSource;

    [Header("Nova")]
    public Nova3 nova;


    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider Nova)
    {
        if (Nova.gameObject.tag == "Nova")
        {
            Debug.Log("AHSJDHA)");
            AudioSource.PlayOneShot(sonAttraperCam, 1f);
            Invoke("ReloadScene", 1f);
            if (nova != null)
                nova.SetCanMove(false);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
