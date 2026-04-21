// script pour changer la cam à la fin du niveau
// auteur : sammuel
// date : 12 avril 2026

// desc : ** Nova **

using UnityEngine;
public class ChangementCam : MonoBehaviour
{
    [Header("Main Cam")]
    public Camera cameraJeu;

    [Header("Cam cinématique Fin")]
    public Camera cameraCinematique;
    public CameraQuiSuitNova scriptCameraSuivi;

    [Header("Follow cinématique")]
    public Transform cibleCinematique;
    public float vitesse = 0.5f;

    void LateUpdate()
    {
        if (cameraCinematique.enabled)
        {
            Vector3 targetPos = cibleCinematique.position;
            cameraCinematique.transform.position = Vector3.Lerp(
                cameraCinematique.transform.position,
                targetPos,
                vitesse * Time.deltaTime
            );
        }
    }

    public void ActiverCameraCinematique()
    {
        if (cameraCinematique == null || cameraJeu == null)
        {
            return;
        }
        scriptCameraSuivi.StopSuivre();
        cameraJeu.gameObject.SetActive(false);
        cameraCinematique.gameObject.SetActive(true);
    }
}